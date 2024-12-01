namespace ISCC.Domain.Models;

public class CreateProject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly PlannedEndDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public decimal TotalActualPriceMaterial { get; set; }
    public decimal TotalActualPriceWork { get; set; }
    public decimal TotalActualPrice { get; set; }

    public decimal TotalCostPriceMaterial { get; set; }
    public decimal TotalCostPriceWork { get; set; }
    public decimal TotalCostPrice { get; set; }

    public decimal TotalPriceExpense { get; set; }
    public double TotalLabor { get; set; }
    

    public CreateProject(string name, DateOnly startDate, DateOnly plannedEndDate, DateOnly? endDate,
        List<CreateProjectPlan> projectPlans)
    {
        Name = name;
        StartDate = startDate;
        PlannedEndDate = plannedEndDate;
        EndDate = endDate;

        TotalActualPriceMaterial = projectPlans.Sum(p => p.TotalActualPriceMaterial);
        TotalActualPriceWork = projectPlans.Sum(p => p.TotalActualPriceWork);
        TotalActualPrice = TotalActualPriceMaterial + TotalActualPriceWork;

        TotalCostPriceMaterial = projectPlans.Sum(p => p.TotalCostPriceMaterial);
        TotalCostPriceWork = projectPlans.Sum(p => p.TotalCostPriceWork);
        TotalCostPrice = TotalCostPriceMaterial + TotalCostPriceWork;

        TotalLabor = projectPlans.Sum(p => p.TotalLabor);
    }
}