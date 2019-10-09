using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace PersonalityQuiz
{
    class MainViewModel : INotifyPropertyChanged
    {

        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }
        public ICommand Restart { get; }

       
        
        //Points that use determine user character. 
        int points = 0;

        //Keeps track of question number
        int questionSequence = 0;

        //A test
        string currentQuestion = "Do you like SciFi?";

        //Going to hold the image URL set to the source of the image element
        string imageUrl = "";


        public MainViewModel()
        {
            YesCommand = new Command(IncreasePoints);
            NoCommand = new Command(LeavePoints);
            Restart = new Command(RestartApp);
        }

       

        void RestartApp()
        {
            (Application.Current).MainPage = new MainPage();
        }


        //1 of 2 methods called by commands
        void IncreasePoints()
        {
            if (questionSequence < 5)
            {
                questionSequence++;
                points++;
                QuestionSelect();
                OnPointsChanged(nameof(DisplayPoints));
                OnQuestionChanged(nameof(DisplayNextQuestion));
            }
            else {
                CharacterResult();
                OnPointsChanged(nameof(DisplayCharacter));
            }
            

        }

        //2 of 2 methods called by commands
        void LeavePoints()
        {
            if (questionSequence < 5)
            {
                questionSequence++;
                QuestionSelect();
                OnPointsChanged(nameof(DisplayPoints));
                OnQuestionChanged(nameof(DisplayNextQuestion));
            } else
            {
                CharacterResult();
                OnPointsChanged(nameof(DisplayCharacter));
            }
        }


        public string DisplayNextQuestion => $"{currentQuestion}";

        public string DisplayPoints => $"You clicked {points} times(s).";

        public string DisplayCharacter => $"{imageUrl}";


        public void CharacterResult() {

            switch (points)
            {
                case 1:
                    imageUrl = "https://m.media-amazon.com/images/M/MV5BMzczZTUzNjMtM2JjOC00ODkzLTgyYzItMWExODYxMmQyODE4XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg";
                    break;
                case 2:
                    imageUrl = "https://m.media-amazon.com/images/M/MV5BMzczZTUzNjMtM2JjOC00ODkzLTgyYzItMWExODYxMmQyODE4XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg";
                    break;
                case 3:
                    imageUrl = "https://alchetron.com/cdn/professor-farnsworth-5b93d9b6-ef12-4cc9-9563-d46ef3e5dfe-resize-750.jpeg";
                    break;
                case 4:
                    imageUrl = "https://imgix.ranker.com/user_node_img/50060/1001188616/original/bender-turns-into-a-criminal-in-the-first-episode-photo-u1?w=650&q=50&fm=pjpg&fit=crop&crop=faces";
                    break;
                case 5:
                    imageUrl = "https://superawesomevectors.com/wp-content/uploads/2017/05/zoidberg-futurama-free-vector-800x566.jpg";
                    break;
                default:
                    imageUrl = "https://superawesomevectors.com/wp-content/uploads/2017/05/zoidberg-futurama-free-vector-800x566.jpg";
                    break;
            }

        }


        public void QuestionSelect()
        {

            string question = "";

            switch (questionSequence)
            {
                case 1:
                    question = "Would you drink slurm?";
                    break;
                case 2:
                    question = "Do you like science and good news?";
                    break;
                case 3:
                    question = "Do you like money/cigars?";
                    break;
                case 4:
                    question = "Do you like zoidberg?";
                    break;
                case 5:
                    question = "Do you think you know which character you are?";
                    break;

                default: break;
            }

            currentQuestion = question;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPointsChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void OnQuestionChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}

