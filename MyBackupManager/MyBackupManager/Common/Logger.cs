using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MyBackupManager.Common
{
    internal class Logger
    {
        public string? Path { get; init; }

        public Logger(string? path)
        {
            Path = path;
            this.LogInitializer();
        }

        public void LogInitializer()
        {
            DirectoryInfo log_dir = new DirectoryInfo(Directory.GetParent(Path).FullName);
            if (!log_dir.Exists)
            {
                log_dir.Create();
            }
            using (StreamWriter writer = new(new FileStream(Path, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine("New log session appeared" + Environment.NewLine + "-------------------");
            }


        }
        public void AppendLog(string message)
        {
            using (StreamWriter writer = new(new FileStream(Path, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine(message + Environment.NewLine);
            }
        }
    }
}
