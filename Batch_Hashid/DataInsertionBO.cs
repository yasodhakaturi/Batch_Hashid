using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Hashid
{
    class DataInsertionBO
    {
        public void UpdateHashid(int pk_uid, string hashid)
        {
            using (var dc = new shortenURLEntities())
            {
                var res = dc.UIDDATAs.SingleOrDefault(x => x.PK_Uid == pk_uid);
                if (res != null)
                {
                    res.UniqueNumber = hashid;
                    dc.SaveChanges();
                }
            }
        }
        public void UpdateBatchStatus(int? batchid, string status)
        {
            using (var dc = new shortenURLEntities())
            {
                var res = dc.BatchUploadDatas.SingleOrDefault(x => x.PK_Batchid == batchid);
                if (res != null)
                {
                    res.Status = status;
                    dc.SaveChanges();
                }
            }
        }
    }
}
