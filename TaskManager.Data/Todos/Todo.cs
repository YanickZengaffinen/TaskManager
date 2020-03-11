namespace TaskManager.Data.Todos
{
    public class Todo : ITodo
    {
        public long Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Todo(long id)
        {
            this.Id = id;
        }
    }
}
