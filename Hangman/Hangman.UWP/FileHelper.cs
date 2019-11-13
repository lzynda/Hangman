using System;
using System.IO;
using Xamarin.Forms;
using Hangman.Services;
using Hangman.UWP;

[assembly: Dependency(typeof(FileHelper))]
namespace Hangman.UWP
{
    public class FileHelper : IFileReadWrite
    {
        public bool IsExist(string fileName)
        {
            var documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var filePath = Path.Combine(documentsPath, fileName);
            if (File.Exists(filePath)) return true;

            return false;

        }
        public void WriteData(string fileName, string data)
        {
            var documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var filePath = Path.Combine(documentsPath, fileName);
            File.WriteAllText(filePath, data);
        }
        public string ReadData(string fileName)
        {
            var documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var filePath = Path.Combine(documentsPath, fileName);
            return File.ReadAllText(filePath);
        }
    }
}
