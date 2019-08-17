using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Transactions.Model
{
    public class Transaction
    {
        public int ID { get; set; }
        public string TermId { get; set; }
        public string Lastupdate { get; set; }
        public string CardBrand { get; set; }
        public int AccountNo { get; set; }
        public int TxnCode { get; set; }
        public int TxnSubCode { get; set; }
        public string Rrn { get; set; }
        public string ReqDateTime { get; set; }

    }
}
