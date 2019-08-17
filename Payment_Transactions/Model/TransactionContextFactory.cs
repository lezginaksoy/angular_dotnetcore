using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Transactions.Model
{
    public class TransactionContextFactory : IDesignTimeDbContextFactory<TransactionContext>
    {
        public TransactionContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TransactionContext>();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("paymentconnection"));

        
            return new TransactionContext(optionsBuilder.Options);
        }
    }
}
