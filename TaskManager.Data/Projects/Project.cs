namespace TaskManager.Data.Projects
{
    //TODO: remove public modifier as external access should be forbidden
    public class Project : IProject
    {
        public long Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; } = true;

        public Project(long id)
        {
            this.Id = id;
        }

        public IData CloneUsingId(long id)
        {
            return new Project(id) {
                Name = Name,
                Description = Description,
                Active = Active
            };
        }
    }
}
