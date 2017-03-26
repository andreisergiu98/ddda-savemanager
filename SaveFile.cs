using System;
using System.IO;
using System.Security.Cryptography;

namespace ddda_savemanager
{
    class SaveFile
    {   
        public SaveFile()
        {

        }

        public SaveFile(string location)
        {
            Load(location);
        }

        public string name, location;
        private DateTime timeStamp;

        public void Load(string location)
        {
            this.location = location;
            timeStamp = File.GetLastWriteTime(this.location);
            name = Path.GetFileNameWithoutExtension(this.location);
        }

        public void Reload()
        {
            timeStamp = File.GetLastWriteTime(location);
        }

        public string GetChecksum()
        {   
            var md5 = MD5.Create();
            var stream = File.OpenRead(location);
            string checksum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
            stream.Close();
            return checksum;
        }

        public string GetLastChangedDate()
        {
            return File.GetLastWriteTime(location).ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string GetTimeCode()
        {
            return File.GetLastWriteTime(location).ToString("ddMMyyyyHHmmss");
        }

        public DateTime GetTimeStamp()
        {
            return File.GetLastWriteTime(location);
        }

        public void SetTimeStamp(DateTime time)
        {
            File.SetCreationTime(location, time);
            File.SetLastWriteTime(location, time);
            File.SetLastAccessTime(location, time);
            timeStamp = time;
        }

        public string GetFileSize()
        {
            FileInfo f = new FileInfo(location);
         
            return (f.Length / 1024).ToString() + " KB";
        }
    }
}
