﻿namespace TaskManager.Data.Todos
{
    public class Todo : ITodo
    {
        public long Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? ProjectId { get; set; }

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
                Description = Description
            };
        }
    }
}