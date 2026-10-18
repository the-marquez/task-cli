
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

        switch( args[0] )
        {
            case "add":
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

                bool result = taskManager.AddTask(task);

                if( result)
                {
                  Log.Info($"Task added successfully: {task}");
                }
                else
                {
                    Log.Error($"Failed to add task: {task}");
                }
                break;
            
            case "update":
                // Handle update command
                break;
            
            case "delete":
                // Handle delete command
                break;
            case "list":

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
}
