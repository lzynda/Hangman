using System;
using Xamarin.Forms;

namespace Hangman.Services
{
    public interface IFileReadWrite
    {
        bool IsExist(string fileName);
        void WriteData(string fileName, string data);
        string ReadData(string filename);
    }
}