namespace ProjectFlow.Api.Models;

public class ProjectTask {
    public int Id {get; set;}
    public required string Title {get; set;}
    public string? Description {get; set;}
    public TasksStatus Status {get; set;}
    public DateTime ProjectDate {get; set;}
    public int ProjectId {get; set;}
    public int? AssignedUserId {get; set;}
}

