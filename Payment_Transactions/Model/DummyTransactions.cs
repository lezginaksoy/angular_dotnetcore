using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Transactions.Model
{
    public class DummyTransactions
    {
        static string GenerateRrn()
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            int JDate = (dt.Year % 10) * 1000 + dt.DayOfYear;
            int TimeForRrn = (DateTime.Now.Hour * 10000 + DateTime.Now.Minute * 100 + DateTime.Now.Second) / 10000;

            Random Rndm = new Random();
            int RandNum = Rndm.Next(1000000);
            string SixDigitNumber = RandNum.ToString("D6");

            string Rrn = JDate.ToString() + TimeForRrn.ToString() + SixDigitNumber;


            return Rrn;
        }
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TransactionContext(serviceProvider.GetRequiredService<DbContextOptions<TransactionContext>>()))
            {
                if (context.Transactions.Any())
                {
                    return;   // DB has been seeded     }
                }

                context.Transactions.AddRange(
                    new Transaction
                    {
                        TermId = "ATM00001",
                        Lastupdate = DateTime.Now.ToString("yyyymmddHHmmss"),
                        CardBrand= CardBrand.MasterCard.ToString(),
                        AccountNo=921312123,
                        TxnCode=1012,
                        TxnSubCode=40,
                        Rrn= GenerateRrn(),
                        ReqDateTime = DateTime.Now.ToString("yyyymmddHHmmss")
                    },
                    new Transaction
                    {
                        TermId = "ATM00002",
                        Lastupdate = DateTime.Now.ToString("yyyymmddHHmmss"),
                        CardBrand = CardBrand.MasterCard.ToString(),
                        AccountNo = 921312123,
                        TxnCode = 1012,
                        TxnSubCode = 60,
                        Rrn = GenerateRrn(),
                        ReqDateTime = DateTime.Now.ToString("yyyymmddHHmmss")
                    },
                    new Transaction
                    {
                        TermId = "ATM00003",
                        Lastupdate = DateTime.Now.ToString("yyyymmddHHmmss"),
                        CardBrand = CardBrand.Visa.ToString(),
                        AccountNo = 921312123,
                        TxnCode = 1011,
                        TxnSubCode = 60,
                        Rrn = GenerateRrn(),
                        ReqDateTime = DateTime.Now.ToString("yyyymmddHHmmss")
                    },
                     new Transaction
                     {
                         TermId = "ATM00004",
                         Lastupdate = DateTime.Now.ToString("yyyymmddHHmmss"),
                         CardBrand = CardBrand.Visa.ToString(),
                         AccountNo = 921312198,
                         TxnCode = 1011,
                         TxnSubCode = 60,
                         Rrn = GenerateRrn(),
                         ReqDateTime = DateTime.Now.ToString("yyyymmddHHmmss")
                     },
                      new Transaction
                      {
                          TermId = "ATM00005",
                          Lastupdate = DateTime.Now.ToString("yyyymmddHHmmss"),
                          CardBrand = CardBrand.MasterCard.ToString(),
                          AccountNo = 921312673,
                          TxnCode = 1011,
                          TxnSubCode = 60,
                          Rrn = GenerateRrn(),
                          ReqDateTime = DateTime.Now.ToString("yyyymmddHHmmss")
                      }

                  );

                context.SaveChanges();
            }

        }

    

        enum CardBrand
        {
            MasterCard=1,
            Visa=2
        }

    }
}
