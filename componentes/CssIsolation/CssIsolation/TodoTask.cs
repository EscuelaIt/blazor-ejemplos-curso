namespace CssIsolation;


public enum TaskType
{
    Important,
    Normal,
    NotImportant
}

public record TodoTask(int Id, string Text, TaskType TaskType = TaskType.Normal)
{
    public DateTime? DoneDate { get; set; } = null;
    public bool IsDone => DoneDate is not null;
    public void MarkDone() => DoneDate = DateTime.UtcNow;
}