namespace ProjectFlow.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal InitialBalance { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public List<Transaction> Transactions { get; set; } = new();
}