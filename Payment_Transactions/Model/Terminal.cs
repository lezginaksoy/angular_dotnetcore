using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Transactions.Model
{
    public class Terminal
    {
        public int ID { get; set; }
        public string Desc { get; set; }
        public string TerminalCode { get; set; }
        public int? BrandId { get; set; }
    }
}
