namespace ToDoItem2.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public List<ToDoItem> toDoItems { get; set; }


    }
}
