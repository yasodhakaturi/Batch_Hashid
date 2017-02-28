
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HashidsNet;
using Batch_Hashid;
namespace Batch_Hashid
{
    public partial class Batch_Hashid : ServiceBase
    {

        shortenURLEntities dc = new shortenURLEntities();
        System.Threading.Timer _timer;
        public Batch_Hashid()
        {
            //_timer = new System.Threading.Timer(
            //new TimerCallback(OnTimerCallBack), null, Timeout.Infinite, Timeout.Infinite);
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MSYNC();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 10000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            // _timer.Change(0, 2000);
        }
        protected void timer_Elapsed(object source, System.Timers.ElapsedEventArgs aa)
        {
            MSYNC();
        }
        protected override void OnStop()
        {
            // LogMessage("Service Stopped - ");
        }
        //public void OnTimerCallBack(object state)
        //{
        //    //LogMessage("Timer Tick - ");
        //    MSYNC();
        //}
        public void MSYNC()
        {
            List<BatchUploadModel> batchids = new List<BatchUploadModel>();
            try
            {
                batchids = (from b in dc.BatchUploadDatas
                            .AsEnumerable()
                            where b.Status == "Insertion Completed"
                            select new BatchUploadModel()
                            {
                                Batchid = b.PK_Batchid,
                                CreatedDate = b.CreatedDate.Value.Date,
                                fk_rid = b.FK_RID,
                                fk_cid = b.FK_ClientID,
                                status = b.Status
                            }).ToList();
                //if batchdata available
                if (batchids.Count != 0)
                {
                    List<BatchData> batchdata = (from u in dc.UIDDATAs
                                                 .AsNoTracking()
                                                 .AsEnumerable()
                                                 join b in batchids on u.FK_Batchid equals b.Batchid
                                                 where DateTime.Compare(u.CreatedDate.GetValueOrDefault().Date, b.CreatedDate.GetValueOrDefault().Date) == 0 && u.FK_RID == b.fk_rid && u.FK_ClientID == b.fk_cid && u.UniqueNumber == null && u.FK_Batchid!=null
                                                 select new BatchData()
                                                 {
                                                     pk_uid = u.PK_Uid

                                                 }).ToList();
                    if (batchdata.Count != 0)
                    {
                        List<BatchData> hashids = (from lb in batchdata
                                                   select new BatchData()
                                                   {
                                                       pk_uid = lb.pk_uid,
                                                       hashid = GetHashID(lb.pk_uid)
                                                   }).ToList();
                        foreach (BatchData i in hashids)
                        {
                            new DataInsertionBO().UpdateHashid(i.pk_uid, i.hashid);
                        }
                        foreach (BatchUploadModel b in batchids)
                        {
                            new DataInsertionBO().UpdateBatchStatus(b.Batchid, "Completed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                foreach (BatchUploadModel b in batchids)
                {
                    new DataInsertionBO().UpdateBatchStatus(b.Batchid, "Error Occured");
                }
            }



        }
        public string GetHashID(int Pk_uid)
        {
            var salt = new HashidsNet.Hashids("this is my salt", 5);
            string hashid = salt.Encode(Pk_uid);
            return hashid;
        }
       
    }
}