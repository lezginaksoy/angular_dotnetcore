using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Transactions.Model.Interface
{
    public interface ITerminalRepository:IRepository<Terminal>
    {
        IEnumerable<Terminal> GetAllWithCode();
        IEnumerable<Terminal> FindWithCode(Func<Terminal, bool> predicate);
        IEnumerable<Terminal> FindWithBrand(Func<Terminal, bool> predicate);

    }
}
