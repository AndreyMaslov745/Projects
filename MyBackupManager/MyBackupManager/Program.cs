using System;
using MyBackupManager.Common;
using MyBackupManager;
using System.Text.Json;
using System.Reflection;
namespace MyBackuper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PathTracker pathTracker = null;
            var config_path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
            Console.WriteLine(config_path);
            try
            {
                using (FileStream sw = new FileStream(config_path, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    pathTracker = JsonSerializer.Deserialize<PathTracker>(sw);
                }
                Logger logger = new Logger(Path.Combine(pathTracker.Path_ToLog));
                BackupManager bm = new BackupManager(pathTracker);
                bm.Notify += logger.AppendLog;
                bm.InitializeBackup();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogDir");
                string log_file = Path.Combine(path, $"ErrorLog [{DateTime.Now.ToString("hh.mm.ss, yy.MM.dd")}].txt");
                DirectoryInfo errorinfo = new DirectoryInfo(path);
                if (!errorinfo.Exists)
                {
                    errorinfo.Create();
                }
                Logger l = new Logger(log_file);
                l.AppendLog($"Error occuered: {ex.Message}");
            }

        }
    }
}
