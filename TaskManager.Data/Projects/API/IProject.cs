namespace TaskManager.Data.Projects
{
    public interface IProject : IData
    {
        string Name { get; }
        string Description { get; }
    }
}
