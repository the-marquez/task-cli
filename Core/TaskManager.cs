
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using task_cli.Helpers;

namespace task_cli.Core
{
    public class TaskManager
    {
        public TaskManager()
        {

            if( !File.Exists( GetTaskFilePath() ) )
            {
                File.Create( GetTaskFilePath() ).Dispose();
                Console.WriteLine("Created tasks.json file.");
            }
        }

        public List<Todo> GetTasks()
        {
            string json = File.ReadAllText( GetTaskFilePath() );

            if(string.IsNullOrEmpty(json))
            {
                return new List<Todo>();
            }

            return JsonSerializer.Deserialize<List<Todo>>( json ) ?? new List<Todo>();
        }

        public bool AddTask(string task)
        {
            List<Todo> tasks = new List<Todo>();
            try
            {
                tasks = GetTasks();
            }catch (Exception)
            {
                Log.Error($"Error reading tasks!");
                return false;
            }

            try
            {
                int nextTaskId = 1;
                if( tasks.Count >= 1)
                {
                    Todo? lastTask = tasks.OrderByDescending(t => t.Id).FirstOrDefault();
                    if( lastTask is not null)
                    {
                        nextTaskId = lastTask.Id + 1;
                    }
                }

                var newTask = new Todo
                {
                    Id = nextTaskId,
                    Description = task,
                    Status = "todo",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now 
                };

                tasks.Add(newTask);

                string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(GetTaskFilePath(), json);

                return true;
            }
            catch (Exception)
            {
                Log.Error($"Error adding task!");
                return false;
            }            
            
        }

        public bool UpdateTask(int id, string description)
        {
            List<Todo> tasks = new List<Todo>();
            try
            {
                tasks = GetTasks();
            }
            catch (Exception)
            {
                Log.Error($"Error reading tasks!");
                return false;
            }

            try
            {
                Todo? task = tasks.FirstOrDefault( t => t.Id == id );

                if( task is null)
                {
                    Log.Warning($"Task with ID {id} not found!");
                    return false;
                }

                task.Description = description;
                task.UpdatedAt = DateTime.Now;
                
                string json = JsonSerializer.Serialize(
                        tasks, 
                        new JsonSerializerOptions { WriteIndented = true }
                    );

                File.WriteAllText( GetTaskFilePath(), json);

                return true;
            }
            catch (Exception)
            {
                Log.Error("Error updating the task");
                return false;
            }
        }

        private string GetTaskFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");
        }
    }
}