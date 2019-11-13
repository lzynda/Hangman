
using System;
using System.IO;
using Xamarin.Forms;
using Hangman.Services;
using Hangman.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace Hangman.Droid
{
    public class FileHelper : IFileReadWrite
    {
        public bool IsExist(string fileName)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);

            if (File.Exists(filePath)) return true;

            return false;

        }
        public void WriteData(string fileName, string data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
            File.WriteAllText(filePath, data);
        }
        public string ReadData(string fileName)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
            return File.ReadAllText(filePath);
        }
    }
}