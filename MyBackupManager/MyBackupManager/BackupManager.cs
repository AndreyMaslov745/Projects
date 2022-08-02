using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MyBackupManager.Common;
namespace MyBackupManager
{
    internal class BackupManager
    {
        public event Action<string>? Notify;
        private PathTracker? _tracker;
        public BackupManager(PathTracker tracker)
        {
            this._tracker = tracker;
        }

        public void CreateBackupFolder()
        {
            DirectoryInfo backup_dir = new DirectoryInfo(_tracker.Backup_Path);
            if (!backup_dir.Exists)
            {
                backup_dir.Create();
            }
        }
        public void CopyDirectoryes(string sourceDir, string destinationDir)
        {

            var dir = new DirectoryInfo(sourceDir);
            var destdir = new DirectoryInfo(destinationDir);
            DirectoryInfo[] dirs = dir.GetDirectories().Where(x => !x.Name.Contains("Backup")).ToArray();

            if (!destdir.Exists)
            {
                Directory.CreateDirectory(destinationDir);
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectoryes(subDir.FullName, newDestinationDir);
            }
            Notify?.Invoke($"Directory {dir.Name} backuped to {destdir.FullName}");
        }
        public void InitializeBackup()
        {
            try
            {
                CreateBackupFolder();
                foreach (var directory in _tracker.TargetDirs)
                {
                    var dir_info = new DirectoryInfo(directory);
                    CopyDirectoryes(directory, Path.Combine(_tracker.Backup_Path, dir_info.Name));
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Notify?.Invoke("Something went wrong: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Notify?.Invoke("Something went wrong: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Notify?.Invoke("Something went wrong: " + ex.Message);
            }
            catch (IOException ex)
            {
                Notify?.Invoke("Something went wrong: " + ex.Message);
            }
        }

    }
}