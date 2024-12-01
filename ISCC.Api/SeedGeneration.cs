using ISCC.Storage;
using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Api;

public static class SeedGeneration
{
    public static async Task<WebApplication> AddSeed(this WebApplication app)
    {
        var provider = app.Services.GetRequiredService<IServiceProvider>();

        var scope = provider.CreateScope();
        provider = scope.ServiceProvider;
        var dbContext = provider.GetRequiredService<MainDbContext>();

        await dbContext.Database.MigrateAsync();
        
        var unitTypeId = Guid.Parse("F82901E1-7E54-4FB7-82C7-130D76E9FAA4");
        if (!await dbContext.UnitTypes.AnyAsync(u => u.Id == unitTypeId))
        {
            var unitType = new UnitTypeEntity()
            {
                Id = Guid.Parse("F82901E1-7E54-4FB7-82C7-130D76E9FAA4"),
                Name = "шт"
            };
            await dbContext.UnitTypes.AddAsync(unitType);
        }
            
        
        
        // Guid projectId = Guid.Parse("2B50E3A9-4092-427C-9866-7FEBE8D397EC");
        // await dbContext.Projects.Where(p => p.Id == projectId).ExecuteDeleteAsync();
        //
        // var project = new ProjectEntity()
        // {
        //     Id = projectId,
        //     Name = "Плановые работы",
        //     StartDate = new DateOnly(2024, 1, 1),
        //     PlannedEndDate = new DateOnly(2024, 2, 2),
        //     EndDate = new DateOnly(2024, 3, 3)
        // };
        //
        // List<ProjectPlanEntity> projectPlans =
        // [
        //     new ProjectPlanEntity()
        //     {
        //         Id = Guid.Parse("EF8617F1-EA8A-4D0C-9F64-3930B7A04D7A"),
        //         Name = "Суммарная задача \"установка унитазов\"\n",
        //         StartDate = new DateOnly(2024, 1, 1),
        //         PlannedEndDate = new DateOnly(2024, 2, 2),
        //         EndDate = new DateOnly(2024, 3, 3),
        //         ProjectId = projectId,
        //         Quantity = 100,
        //     }
        // ];
        //
        // List<ResourceEntity> resources =
        // [
        //     new ResourceEntity
        //     {
        //         Id = Guid.Parse("0F119D87-3418-44FD-82EA-AA2EE2C8A688"),
        //         Name = "Унитаз с бачком и системой слива",
        //         Quantity = 100,
        //         Surcharge = 3750.00m,
        //         CostPricePerUnitMaterial = 100000.00m,
        //         CostPricePerUnitWork = 3750.00m,
        //         TotalCostPriceMaterial = 10000000.00m,
        //         TotalCostPriceWork = 375000.00m,
        //         TotalCostPrice = 10375000.00m,
        //         ActualPricePerUnitMaterial = 80000.00m,
        //         ActualPricePerUnitWork = 3000.00m,
        //         TotalActualPriceMaterial = 8000000.00m,
        //         TotalActualPriceWork = 300000.00m,
        //         TotalActualPrice = 8300000.00m,
        //         UnitTypeId = unitTypeId,
        //         ProjectPlanId = projectPlans[0].Id,
        //     },
        //     new ResourceEntity
        //     {
        //         Id = Guid.Parse("CFF6B784-E0D0-486C-9EEF-2EBB63B83D66"),
        //         Name = "Гибкая подводкаа 0,5 м",
        //         Quantity = 100,
        //         Surcharge = 0.00m,
        //         CostPricePerUnitMaterial = 625.00m,
        //         CostPricePerUnitWork = 0.00m,
        //         TotalCostPriceMaterial = 62500.00m,
        //         TotalCostPriceWork = 0.00m,
        //         TotalCostPrice = 62500.00m,
        //         ActualPricePerUnitMaterial = 500.00m,
        //         ActualPricePerUnitWork = 0.00m,
        //         TotalActualPriceMaterial = 50000.00m,
        //         TotalActualPriceWork = 0.00m,
        //         TotalActualPrice = 50000.00m,
        //         UnitTypeId = unitTypeId,
        //         ProjectPlanId = projectPlans[0].Id,
        //     },
        //     new ResourceEntity
        //     {
        //         Id = Guid.Parse("1BE048E5-6076-4A20-837C-672AB6AB30C6"),
        //         Name = "Рукомойник без смесителя",
        //         Quantity = 100,
        //         Surcharge = 3125.00m,
        //         CostPricePerUnitMaterial = 62500.00m,
        //         CostPricePerUnitWork = 3125.00m,
        //         TotalCostPriceMaterial = 6250000.00m,
        //         TotalCostPriceWork = 312500.00m,
        //         TotalCostPrice = 6562500.00m,
        //         ActualPricePerUnitMaterial = 50000.00m,
        //         ActualPricePerUnitWork = 2500.00m,
        //         TotalActualPriceMaterial = 5000000.00m,
        //         TotalActualPriceWork = 250000.00m,
        //         TotalActualPrice = 5250000.00m,
        //         UnitTypeId = unitTypeId,
        //         ProjectPlanId = projectPlans[0].Id,
        //     },
        //     new ResourceEntity
        //     {
        //         Id = Guid.Parse("3DB8FC60-515B-49E9-828F-81FA3452740E"),
        //         Name = "Смеситель для рукомойника",
        //         Quantity = 100,
        //         Surcharge = 1875.00m,
        //         CostPricePerUnitMaterial = 43750.00m,
        //         CostPricePerUnitWork = 1875.00m,
        //         TotalCostPriceMaterial = 4375000.00m,
        //         TotalCostPriceWork = 187500.00m,
        //         TotalCostPrice = 4562500.00m,
        //         ActualPricePerUnitMaterial = 35000.00m,
        //         ActualPricePerUnitWork = 1500.00m,
        //         TotalActualPriceMaterial = 3500000.00m,
        //         TotalActualPriceWork = 150000.00m,
        //         TotalActualPrice = 3650000.00m,
        //         UnitTypeId = unitTypeId,
        //         ProjectPlanId = projectPlans[0].Id,
        //     },
        //     new ResourceEntity
        //     {
        //         Id = Guid.Parse("8036A220-DA71-4586-B88D-FBB21FC98EF0"),
        //         Name = "Гибкая подводка 0,5 м",
        //         Quantity = 200,
        //         Surcharge = 0.00m,
        //         CostPricePerUnitMaterial = 625.00m,
        //         CostPricePerUnitWork = 0.00m,
        //         TotalCostPriceMaterial = 125000.00m,
        //         TotalCostPriceWork = 0.00m,
        //         TotalCostPrice = 125000.00m,
        //         ActualPricePerUnitMaterial = 500.00m,
        //         ActualPricePerUnitWork = 0.00m,
        //         TotalActualPriceMaterial = 100000.00m,
        //         TotalActualPriceWork = 0.00m,
        //         TotalActualPrice = 100000.00m,
        //         UnitTypeId = unitTypeId,
        //         ProjectPlanId = projectPlans[0].Id,
        //     }
        // ];
        //
        //
        // await dbContext.Projects.AddAsync(project);
        //
        // await dbContext.ProjectPlans.AddRangeAsync(projectPlans);
        //
        // await dbContext.Resources.AddRangeAsync(resources);
        //
        // await dbContext.SaveChangesAsync();
        //
        // scope.Dispose();

        return app;
    }
}