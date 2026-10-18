
using System;
using System.Collections.Generic;
using System.Linq;
using task_cli.Core;
using task_cli.Helpers;

namespace task_cli;

class Program
{

    static void Main(string[] args)
    {
        var taskManager = new TaskManager();

        if(args.Length == 0 || args.Contains("-h") || args.Contains("--help") || args.Contains("help") )
        {
            PrintHelp();
            return;
        }

        if(args.Length > 0 && (args.Contains("-v") || args.Contains("--version") || args.Contains("version")))
        {
            PrintVersion();
            return;
        }

        string command = args[0].Trim().ToLower();

        switch( command )
        {
            case "add":
                AddTask(args, taskManager);
                break;
            
            case "update":
                UpdateTask(args, taskManager);
                break;
            
            case "delete":
                DeleteTask(args, taskManager);
                break;

            case "list":
                // list, list todo, list in-progress, list done
                ListTasks(args, taskManager);
                break;

            case "mark-in-progress":
                MarkTaskAsInProgress(args, taskManager);
                break;
            
            case "mark-done":
                MarkTaskAsDone(args, taskManager);
                break;
            
            default:
                Log.Error($"Unknown command: {args[0]}\n");
                PrintHelp();
                return;
        }

    }

    static void PrintHelp()
    {
        Console.WriteLine("Usage: task_cli [options]");
        Console.WriteLine("Options:");
        Console.WriteLine("  -h, --help, help             Show this help message");
        Console.WriteLine("  -v, --version, version       Show version information");
        Console.WriteLine("  add <task>                   Add a new task");
        Console.WriteLine("  update <task_id> <new_task>  Update an existing task");
        Console.WriteLine("  delete <task_id>             Delete a task");
        Console.WriteLine("  mark-in-progress <task_id>   Mark a task as in progress");
        Console.WriteLine("  mark-done <task_id>          Mark a task as done");
        Console.WriteLine("  list                         List all tasks");
        Console.WriteLine("  list todo                    List all todo tasks");
        Console.WriteLine("  list in-progress             List all in-progress tasks");
        Console.WriteLine("  list done                    List all done tasks");
        Console.WriteLine("");
    }

    static void PrintVersion()
    {
        Console.WriteLine("task_cli version 1.0.0");
        Console.WriteLine("> Author: Elmer Marquez <cracknight>");
        Console.WriteLine("> GitHub: https://github.com/the-marquez/task-cli");
    }

    static void AddTask(string[] args, TaskManager taskManager)
    {
        if(args.Length < 2)
        {
            Log.Error("No task provided. Usage: add <task>");
            return;
        }

        string task = args[1].Trim();

        if(string.IsNullOrEmpty( task ))
        {
            Log.Error("Task cannot be empty. Usage: add <task>");
            return;
        }

        var result = taskManager.AddTask(task);

        if( result.Success )
        {
            Log.Info($"Task added successfully (ID: {result.TaskId})");
        }
        else
        {
            Log.Error($"Failed to add task!");
        }
    }

    static void UpdateTask(string[] args, TaskManager taskManager)
    {
        if( args.Length < 3)
        {
            Log.Error("No task provided. Usage: update <task_id> <new_task>");
            return;
        }

        int taskId = Convert.ToInt32( args[1] );
        string taskDescription = args[2].Trim();

        bool result = taskManager.UpdateTask( taskId,  taskDescription );

        if( result )
        {
            Log.Info($"Task updated successfully: {taskId} - {taskDescription}");
        }
        else
        {
            Log.Error($"Failed to update task: {taskId} - {taskDescription}");
        }
    }

    static void DeleteTask(string[] args, TaskManager taskManager)
    {
        if( args.Length < 2)
        {
            Log.Error("No task provided. Usage: delete <task_id>");
            return;
        }

        int taskId = Convert.ToInt32( args[1] );

        bool result = taskManager.DeleteTask( taskId );

        if( result )
        {
            Log.Info($"Task delete successfully: {taskId}");
        }
        else
        {
            Log.Error($"Failed to delete task: {taskId}");
        }
                
    }

    static void ListTasks(string[] args, TaskManager taskManager)
    {
        List<Todo> tasks = taskManager.GetTasks();

        if( args.Length == 1)
        {
            Console.WriteLine("All tasks:");
            foreach (var t in tasks)
            {
                Console.WriteLine($" * {t.Id} {t.Description} ({t.Status}) - Created At: {t.CreatedAt} - Updated At: {t.UpdatedAt}");
            }
            return;
        }

        string statusFilter = args[1].Trim().ToLower();

        string[] validStatuses = ["todo", "in-progress", "done"];
    
        if ( !validStatuses.Contains(statusFilter) )
        {
            Log.Error($"Unknown status filter: {statusFilter}");
            return;
        }

        List<Todo> filteredTasks = tasks.Where(task =>
            task.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)
        ).ToList();

        Console.WriteLine($"Tasks with status {statusFilter}:");
        if( filteredTasks.Count > 0)
        {
            foreach (var t in filteredTasks)
            {
                Console.WriteLine($" * {t.Id} {t.Description} ({t.Status}) - Created At: {t.CreatedAt} - Updated At: {t.UpdatedAt}");
            }
        }
        else
        {
            Console.WriteLine(" * Empty................");
        }
    }

    static void MarkTaskAsInProgress(string[] args, TaskManager taskManager)
    {
        if( args.Length < 2)
        {
            Log.Error("Missing required parameter. Usage: task-cli mark-in-progress <task_id>");
            return;
        }

        int taskId = Convert.ToInt32( args[1] );

        bool result = taskManager.MarkTaskAsInProgress( taskId );

        if( result)
        {
            Log.Info($"Task {taskId} marked as in-progress successfully.");
        }
        else
        {
            Log.Error($"Failed to mark task {taskId} as in-progress.");
        }
    }

    static void MarkTaskAsDone(string[] args, TaskManager taskManager)
    {
        if( args.Length < 2)
        {
            Log.Error("Missing required parameter. Usage: task-cli mark-done <task_id>");
            return;
        }

        int taskId = Convert.ToInt32( args[1] );

        bool result = taskManager.MarkTaskAsDone( taskId );

        if( result )
        {
            Log.Info($"Task {taskId} marked as done successfully.");
        }
        else
        {
            Log.Error($"Failed to mark task {taskId} as done.");
        }
    }
}
