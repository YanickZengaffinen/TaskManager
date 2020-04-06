namespace TaskManager.Data.Projects
{
    public interface IProject : IData
    {
        string Name { get; set; }

        string Description { get; set; }

        bool Active { get; set; }
    }
}
