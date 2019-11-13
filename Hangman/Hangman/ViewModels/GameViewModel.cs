using System;
using System.Collections;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using Hangman.Models;
using Xamarin.Forms;
using Hangman.Services;


namespace Hangman.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
               
        string _startNextText = "START";
        string _displayChances = "";
        string _displayText = "";
        string _displayLetters = "";
        string _displayWinLose = "";
        bool _isCharEnabled = false;
        bool _isNextVisible = true;
        bool _isWinLoseVisible = false;        

        public LoadData data = new LoadData();

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCharCommand { protected set; get; }
        public ICommand StartCommand { protected set; get; }
       

        public GameViewModel()
        {
              

            AddCharCommand = new Command<string>((key) =>
            {
                string temp = data.GetGuessText();                
                if (data.AddUsedLetter(key))
                {
                    if(data.GetGuessText() == temp)
                    {                        
                        data.SubtractChances();
                    }

                    DisplayText = data.GetGuessText();                    
                   
                }
               

                if(data.GetGuessText() == data.GetWordText())
                {
                                        
                    DisplayWinLose = "WYGRAŁEŚ!";
                    data.ClearUsedLetters();
                    IsCharEnabled = false;
                    IsNextVisible = true;
                    IsWinLoseVisible = true;
                }

                if(data.GetChances() == 0)
                {
                    
                    DisplayText = data.GetWordText();
                    data.ClearUsedLetters();
                    DisplayWinLose = "PRZEGRAŁEŚ";
                    IsCharEnabled = false;
                    IsNextVisible = true;
                    IsWinLoseVisible = true;

                }

                DisplayChances = data.GetChancesString();
                DisplayUsedLetters = data.UsedLetterToString();
            });

            StartCommand = new Command(() =>
            {
                data.SetChances(data.GetChancesFromFile());
                data.RandomWord();                
                DisplayChances = data.GetChancesString();
                DisplayText = data.GetGuessText();
                StartNextText = "NASTĘPNE";                
                IsNextVisible = false;                
                IsCharEnabled = true;
                IsWinLoseVisible = false;

            });
            
        }

        public string StartNextText
        {
            get
            {
                return _startNextText;
            }
            set
            {
                _startNextText = value;
                OnPropertyChanged("StartNextText");
            }
        }

        public bool IsNextVisible
        {
            get
            {
                return _isNextVisible;
            }
            set
            {
                _isNextVisible = value;
                OnPropertyChanged("IsNextVisible");
            }
        }

        public bool IsWinLoseVisible
        {
            get
            {
                return _isWinLoseVisible;
            }
            set
            {
                _isWinLoseVisible = value;
                OnPropertyChanged("IsWinLoseVisible");
            }
        }

        public bool IsCharEnabled
        {
            get
            {
                return _isCharEnabled;
            }
            set
            {
                _isCharEnabled = value;
                OnPropertyChanged("IsCharEnabled");
            }
        }


        public string DisplayChances
        {
            set
            {

                _displayChances = "SZANSE: " + value;
                OnPropertyChanged("DisplayChances");

            }
            get { return _displayChances; }
        }

        public string DisplayWinLose
        {
            set
            {
                _displayWinLose = value;
                OnPropertyChanged("DisplayWinLose");

            }
            get { return _displayWinLose; }
        }

        public void ShowWord()
        {
            DisplayText = "tekst";

        }
  

        public string DisplayText
        {
            set
            {
                if (_displayText != value)
                {
                    _displayText = Format(value);
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return _displayText; }
        }

        public string DisplayUsedLetters
        {
            set
            {
                if (_displayLetters != value)
                {
                    _displayLetters = "UŻYTE LITERY: " + Format(value);
                    OnPropertyChanged("DisplayUsedLetters");
                }
            }
            get { return _displayLetters; }
        }


        string Format(string str)
        {
            string format = "";

            foreach (char c in str)
            {
                 format += c + " ";
            }

            return format;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
