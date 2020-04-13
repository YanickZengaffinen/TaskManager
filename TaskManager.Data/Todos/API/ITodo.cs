using System;

namespace TaskManager.Data.Todos
{
    public interface ITodo : IData
    {
        /// <summary>
        /// The project this todo belongs to
        /// </summary>
        long? ProjectId { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        DateTime? DueDate { get; set; }
    }
}
