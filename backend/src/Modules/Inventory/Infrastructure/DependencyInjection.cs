using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WarehouseManagement.Modules.Inventory.Domain;
using WarehouseManagement.Modules.Inventory.Infrastructure.Database;
using WarehouseManagement.Modules.Inventory.Infrastructure.Database.Repositories;

namespace WarehouseManagement.Modules.Inventory.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInventoryInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<InventoryDbContext>(options =>
        {
            options.UseNpgsql(connectionString);

            options.EnableSensitiveDataLogging(); // Verileri (şifre hariç) logda gösterir
            options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information); // SQL'i konsola basar
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IReceiptRepository, ReceiptRepository>();

        return services;
    }
}