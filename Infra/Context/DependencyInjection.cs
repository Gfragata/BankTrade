using CategoryBankTrades.Model;
using CategoryBankTrades.Model.Interface;
using CategoryBankTrades.Repository;
using CategoryBankTrades.Repository.Interface;
using CategoryBankTrades.Service;
using CategoryBankTrades.Service.Interface;

namespace CategoryBankTrades.Infra.Context
{
    public class DependencyInjection
    {
        public static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IBankTradeRepository, BankTradeRepository>();
            services.AddScoped<IBankTradeService, BankTradeService>();
            services.AddScoped<ContextDb>();
        }
    }
}
