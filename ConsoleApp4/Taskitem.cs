using System;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(int id, string title)
    {
        Id = id;
        Title = title;
        CreatedAt = DateTime.Now;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"[{Id}] {Title} (создана: {CreatedAt:yyyy-MM-dd HH:mm}, выполнена: {(IsCompleted ? "да" : "нет")})";
    }
}