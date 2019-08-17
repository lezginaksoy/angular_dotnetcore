using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment_Transactions.Model.Interface;

namespace Payment_Transactions.Model.Repository
{
    public class TerminalRepository :Repository<Terminal>,ITerminalRepository
    {


        public TerminalRepository(TransactionContext Context) : base(Context)
        {
        }

        public IEnumerable<Terminal> FindWithBrand(Func<Terminal, bool> predicate)
        {
            return _context.Terminal
                .Include(a => a.BrandId)
                .Where(predicate);
        }

        public IEnumerable<Terminal> FindWithCode(Func<Terminal, bool> predicate)
        {
            return _context.Terminal
                .Include(a => a.TerminalCode)
                .Where(predicate);
        }

        public IEnumerable<Terminal> GetAllWithCode()
        {
            return _context.Terminal.Include(a => a.TerminalCode);
        }


        public override int Delete(Terminal term)
        {
            int RetVal = 0;
            var ExistTerm = _context.Terminal.FirstOrDefault(b => b.TerminalCode == term.TerminalCode);
            if (ExistTerm != null)
            {
                _context.Terminal.Remove(term);
                RetVal = _context.SaveChanges();
            }
            return RetVal;
        }

        public override int Update(Terminal term)
        {
            int RetVal = 0;
            var ExistTerm = _context.Terminal.Find(term.TerminalCode);
            if (ExistTerm != null)
            {
                term.Desc = term.Desc;
                term.BrandId = term.BrandId;
                RetVal = _context.SaveChanges();
            }
            return RetVal;
        }

    }
}
