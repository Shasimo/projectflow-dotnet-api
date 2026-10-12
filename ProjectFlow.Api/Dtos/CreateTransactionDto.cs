namespace ProjectFlow.Dtos;

public class CreateTransactionDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
}