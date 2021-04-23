using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoHW.Model
{
    public class Agreement
    {
        public long id { get; set; }
        public long ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LockDate { get; set; } = null;
        public string ScanUrl { get; set; }
        public short TemplateId { get; set; }
        public string Type { get; set; }
        public decimal CurrentSum { get; set; }
    }
}
