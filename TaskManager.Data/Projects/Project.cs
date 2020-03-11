namespace TaskManager.Data.Projects
{
    class Project : IProject
    {
        public long Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Project(int id)
        {
            this.Id = id;
        }
    }
}
