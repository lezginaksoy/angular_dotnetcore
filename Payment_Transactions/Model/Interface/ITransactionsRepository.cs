using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Transactions.Model.Interface
{
    public interface ITransactionsRepository:IRepository<Transaction>
    {
        IEnumerable<Transaction> GetAllWithTermCode(Func<Transaction, bool> predicate);
        IEnumerable<Transaction> FindWithRRN(Func<Transaction, bool> predicate);
        IEnumerable<Transaction> FindWithCardBrand(Func<Transaction, bool> predicate);
        IEnumerable<Transaction> FindWithTxnCode(Func<Transaction, bool> predicate);


    }
}
