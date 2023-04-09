namespace ToDoListApp.Data.Models
{
    public class TaskWithCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Status { get; set; }
        public string Category { get; set; }
    }
}
