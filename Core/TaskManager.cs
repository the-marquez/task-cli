
using System;
using System.IO;

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

        private string GetTaskFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");
        }
    }
}