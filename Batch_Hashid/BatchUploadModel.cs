using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Hashid
{
    class BatchUploadModel
    {
        public int? Batchid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? fk_rid { get; set; }
        public int? fk_cid { get; set; }
        public string status { get; set; }
    }
    class BatchData
    {
        public int pk_uid { get; set; }
        public string hashid { get; set; }
    }
}
