namespace Biss.DailyCashFlow.Domain.Entities;

public class Entry
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public float Value { get; set; }
    public DateTime EntryDate { get; set; }
    public bool Active { get; set; }
}
