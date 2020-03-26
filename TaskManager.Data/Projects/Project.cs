namespace TaskManager.Data.Projects
{
    public class Project : IProject
    {
        public long Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Project(long id)
        {
            this.Id = id;
        }

        public IData CloneUsingId(long id)
        {
            return new Project(id) {
                Name = Name,
                Description = Description
            };
        }
    }
}
