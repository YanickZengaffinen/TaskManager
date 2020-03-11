namespace TaskManager.Data.Todos
{
    public interface ITodo : IData
    {
        string Title { get; set; }
        string Description { get; set; }
    }
}
