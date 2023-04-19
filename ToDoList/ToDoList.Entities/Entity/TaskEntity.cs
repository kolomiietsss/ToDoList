﻿namespace ToDoList.Entities.Entity;

public class TaskEntity
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public int CategoryId { get; set; }
}