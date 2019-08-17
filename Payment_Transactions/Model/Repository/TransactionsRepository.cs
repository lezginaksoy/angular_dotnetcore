
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment_Transactions.Model.Interface;

namespace Payment_Transactions.Model.Repository
{
    public class TransactionsRepository : Repository<Transaction>, ITransactionsRepository
    {



        public TransactionsRepository(TransactionContext Context) : base(Context)
        {
        }



        public IEnumerable<Transaction> FindWithCardBrand(Func<Transaction, bool> predicate)
        {
            return _context.Transactions
                  .Include(a => a.CardBrand)
                  .Where(predicate);
        }

        public IEnumerable<Transaction> FindWithRRN(Func<Transaction, bool> predicate)
        {
            return _context.Transactions
                 .Include(a => a.Rrn)
                 .Where(predicate);
        }

        public IEnumerable<Transaction> FindWithTxnCode(Func<Transaction, bool> predicate)
        {
            return _context.Transactions
                 .Include(a => a.TxnCode)
                 .Where(predicate);
        }

        public IEnumerable<Transaction> GetAllWithTermCode(Func<Transaction, bool> predicate)
        {
            return _context.Transactions
                 .Include(a => a.TermId)
                 .Where(predicate);
        }

        public override int Update(Transaction entity)
        {
            int RetVal = 0;
            var ExistTxn = _context.Transactions.Find(entity.ID);
            if (ExistTxn != null)
            {
                ExistTxn.ReqDateTime = entity.ReqDateTime;
                ExistTxn.Lastupdate = entity.Lastupdate;
                RetVal = _context.SaveChanges();
            }
            return RetVal;
        }

        public override int Delete(Transaction entity)
        {
            int RetVal = 0;
            var ExistTxn = _context.Transactions.FirstOrDefault(b => b.ID == entity.ID);
            if (ExistTxn != null)
            {
                _context.Transactions.Remove(entity);
                RetVal = _context.SaveChanges();
            }
            return RetVal;

        }

    }
}
