namespace ToDoListApp.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
    }
}
