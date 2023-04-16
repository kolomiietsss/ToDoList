namespace ToDoListApp.Models
{
    public class TaskViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Status { get; set; }
        public string CategoryName { get; set; }
    }
}
