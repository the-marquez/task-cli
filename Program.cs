namespace task_cli;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length == 0 || args.Contains("-h") || args.Contains("--help") || args.Contains("help") )
        {
            PrintHelp();
            return;
        }

        if(args.Contains("-v") || args.Contains("--version") || args.Contains("version"))
        {
            PrintVersion();
            return;
        }

        // var taskManager = new TaskManager();
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
        Console.WriteLine("Author: Crack Night");
        Console.WriteLine("GitHub: https://github.com/cracknight/task-cli");
    }
}
