using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment_Transactions.Model;
using Payment_Transactions.Model.Interface;

namespace Payment_Transactions.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {

        private readonly ITransactionsRepository _TxnRepo;

        public TransactionController(ITransactionsRepository Repository)
        {
            _TxnRepo = Repository;
        }
        

        // GET: api/Transaction
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var Txn = _TxnRepo.GetAll();
            return Txn;
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public IActionResult GetTerminal([FromRoute] string term_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            var term = _TxnRepo.GetAllWithTermCode(t=>t.TermId==term_id);
            if (term == null)
            {
                return NotFound();
            }
            return Ok(term);
        }
        
        // POST: api/Transaction
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
