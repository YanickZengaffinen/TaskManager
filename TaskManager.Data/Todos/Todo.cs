using System;

namespace TaskManager.Data.Todos
{
    //TODO: remove public modifier as external access should be forbidden
    public class Todo : ITodo
    {
        public long Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? ProjectId { get; set; }

        public DateTime? DueDate { get; set; }

        public Todo(long id)
        {
            this.Id = id;
        }

        public IData CloneUsingId(long id)
        {
            return new Todo(id)
            {
                ProjectId = ProjectId,
                Title = Title,
                Description = Description,
                DueDate = DueDate
            };
        }
    }
}
