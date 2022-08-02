using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackupManager.Common
{
    internal class PathTracker
    {
        public string[] TargetDirs { get; init; }
        public string Backup_Path { get; init; }
        public string? Path_ToLog { get; init; }
        public PathTracker(string[] targetdirs, string backup_path, string path_tolog)
        {
            this.TargetDirs = targetdirs;
            this.Backup_Path = Path.Combine(backup_path, $"Backup [{DateTime.Now.ToString("hh.mm.ss, yy.MM.dd")}]");
            this.Path_ToLog = Path.Combine(path_tolog, $"log [{DateTime.Now.ToString("hh.mm.ss, yy.MM.dd")}].txt");
        }

    }
}
