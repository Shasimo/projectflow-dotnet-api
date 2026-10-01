namespace ProjectFlow.Api.Models;

public class Comment {
    public int Id {get; set;}
    public required string Comment {get; set;}
    public DateTime CreatedAt {get; set;}
    public int TaskId {get; set;}
    public int UserId {get; set}
}