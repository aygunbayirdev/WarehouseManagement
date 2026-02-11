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
            options.UseNpgsql(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}