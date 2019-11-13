using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Models
{
    public class Word
    {
        public string Text { get; set; }
        public string TextGuess { get; set; }       
        public List<string> UsedLetters { get; set; }
        public int Chances { get; set; }
    }
}
