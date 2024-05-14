using Microsoft.Extensions.DependencyInjection;
using BankingSystem.infrastructure.Data;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.application.Services
{
    public class FineApplicationService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public FineApplicationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var loans = dbContext.Loans.Where(l => l.DueDate < DateTime.UtcNow && l.Status == "Active").ToList();

                    foreach (var loan in loans)
                    {
                        if (DateTime.UtcNow > loan.DueDate.AddDays((double)(7 * (loan.Fine / (0.05m * loan.LoanAmount) + 1))))
                        {
                            loan.Fine += loan.RepaymentAmount * 0.05m;  // 5% of the loan amount
                            loan.RepaymentAmount += loan.Fine;
                            dbContext.Update(loan);
                        }
                    }

                    await dbContext.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);  // Run once a day
            }
        }
    }
}
