using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BankingSystem.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BankingSystem.domian.Entities;

namespace BankingSystem.infrastructure.Services
{
    public class AccountStatusBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AccountStatusBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckAndUpdateAccountStatus();
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);  // Run daily
            }
        }

        private async Task CheckAndUpdateAccountStatus()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var currentDate = DateTime.UtcNow;
                var inactiveThreshold = currentDate.AddMonths(-6);
                var overdueLoanThreshold = currentDate.AddMonths(-3);
                // Retrieve all customers including their accounts and loans
                var customers = dbContext.Customers
                                         .Include(c => c.Accounts)
                                         .Include(c => c.Loans)
                                         .ToList();

                foreach (var customer in customers)
                {
                    // Check if all accounts are inactive
                    bool allAccountsInactive = customer.Accounts.All(a => a.LastTransactionDate <= inactiveThreshold);

                    // Check if any loans are overdue
                    bool hasOverdueLoans = customer.Loans.Any(l => l.DueDate < overdueLoanThreshold && l.Status == "Active");

                    if (allAccountsInactive || hasOverdueLoans)
                    {
                        customer.Status = "INACTIVE"; // Update customer status to INACTIVE
                        foreach (var account in customer.Accounts)
                        {
                            account.AccountStatus = "INACTIVE"; // Update account status to INACTIVE
                        }
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }

}
