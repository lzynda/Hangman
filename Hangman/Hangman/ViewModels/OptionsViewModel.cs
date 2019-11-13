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
    public class OptionsViewModel : INotifyPropertyChanged
    {

        string[] difficultyNames = { "PREZENTACJA", "ŁATWY", "SREDNI", "TRUDNY"};
        public int _difficultyId = 0;
        string _displayDifficulty = "";
        const string fileName = "difficulty.txt";

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DifficultyCommand { protected set; get; }

        public OptionsViewModel()
        {
            DisplayDifficulty = difficultyNames[_difficultyId];

            DifficultyCommand = new Command(() =>
            {
                int temp = _difficultyId++;
                DifficultyId=1;
                DisplayDifficulty = difficultyNames[_difficultyId];                          
                                
                string diff = DifficultyId.ToString();
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, diff);
                

            });
        }
        

        public string DisplayDifficulty
        {
            set
            {
                _displayDifficulty = value;
                OnPropertyChanged("DisplayDifficulty");

            }
            get { return _displayDifficulty; }
        }

        public int DifficultyId
        {
            set
            {
                int temp = _difficultyId++;
                _difficultyId = temp % 4;
               
            }
            get { return _difficultyId; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
