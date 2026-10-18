

using System;

namespace task_cli.Core
{
    public class Todo
    {
        /// <summary>
        /// A Unique identifier for the task.
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// A short description of the task.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The status of the task (todo, in-progress, done).
        /// </summary>
        public string Status { get; set; } = "todo";

        /// <summary>
        /// The date and time when the task was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// The date and time when the task was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}