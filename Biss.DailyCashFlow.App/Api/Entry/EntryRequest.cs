namespace Biss.DailyCashFlow.App.Api.Entry;

public class EntryRequest
{
    public string Description { get; set; }
    public float Value { get; set; }
    public DateTime EntryDate { get; set; }
}
public static class EntryRequestExtension
{
    public static Domain.Entities.Entry ToEntity(this EntryRequest request)
    {
        return new Domain.Entities.Entry()
        {
            Active = true,
            Value = request.Value,
            Description = request.Description,
            EntryDate = request.EntryDate,
        };
    }
}
