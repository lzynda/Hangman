using System;
using System.Collections.Generic;
using System.Text;
using Hangman.Models;
using Xamarin.Forms;
using System.Linq;

namespace Hangman.Services
{
    public class LoadData
    {
        const string fileName = "WordsTest2";
        public Word word;
       

        public LoadData()
        {
            word = new Word();
            word.UsedLetters = new List<string>();
            CreateWordsBase();

        }

        public void CreateWordsBase()
        {
            if (!DependencyService.Get<IFileReadWrite>().IsExist(fileName))
            {
                string Words = "KIEROWNICA\nAKORDEON\nKSIĄŻKA\nBUTELKA\nPAJĘCZYNA\nTRAMPOLINA\nSANDAŁY\nSŁUCHAWKI\nLAMPA\nKALENDARZ\nSAMOCHÓD\nZASŁONY\n";

                DependencyService.Get<IFileReadWrite>().WriteData(fileName, Words);
            }
        }

        public void RandomWord()
        {
            Random rnd = new Random();
            string data = DependencyService.Get<IFileReadWrite>().ReadData(fileName);
            string[] words = data.Split('\n');
            int r = rnd.Next(0, words.Length-1);
            word.Text = words[r];
        }

        public int GetChancesFromFile()
        {
            if (!DependencyService.Get<IFileReadWrite>().IsExist("difficulty.txt"))
            {
                return 6;
            }

            string d = DependencyService.Get<IFileReadWrite>().ReadData("difficulty.txt");

            if (d.Contains("0")) return 32;
            if (d.Contains("1")) return 10;
            if (d.Contains("2")) return 6;
            if (d.Contains("3")) return 3;

            return 6;

        }

        public string GetWordText()
        {
            return word.Text;
        }

        public void SetChances(int value)
        {
            word.Chances = value;
        }

        public int GetChances()
        {
            return word.Chances;
        }

        public string GetChancesString()
        {
            return word.Chances.ToString();
        }

        public void SubtractChances()
        {
           
             word.Chances--;
           
        }

        public bool AddUsedLetter(string letter)
        {
            if (!word.UsedLetters.Contains(letter))
            {
                word.UsedLetters.Add(letter);
                word.UsedLetters.Sort();
                return true;
            }

            return false;
        }

        public string GetGuessText()
        {
            bool x = true;
            string t = "";

            string w = GetWordText();
            string used = UsedLetterToString();

            for (int i = 0; i < w.Length; i++)
            {
               for (int j=0; j < used.Length; j++)
                {
                    if(w[i] == used[j])
                    {
                        t += w[i];
                        x = false;
                    }
                }

                if (x)  t += "_";                
                
                x = true;
            }                       
            
            return t;

        }

        public string UsedLetterToString()
        {
            
            string t = "";

            for (int i = 0; i < word.UsedLetters.Count; i++) t += word.UsedLetters[i];

            return t;
        }

        public void ClearUsedLetters()
        {
            word.UsedLetters.Clear();
        }

    }
}
     

   
