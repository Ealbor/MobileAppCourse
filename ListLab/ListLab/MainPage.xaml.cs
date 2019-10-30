using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListLab
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public IList<Questions> Question { get; private set; }
        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }
        public ICommand Restart { get; }

        public MainPage()
        {
            InitializeComponent();

            YesCommand = new Command(IncreasePoints);
            NoCommand = new Command(LeavePoints);
            Restart = new Command(RestartApp);

            Question = new List<Questions>();
            Question.Add(new Questions
            {
                Ques = "Do you like SCIFI?",
            });

            Question.Add(new Questions
            {
                Ques = "Would you drink slurm?",
            });

            Question.Add(new Questions
            {
                Ques = "Do you like oney/cigars?",
            });

            Question.Add(new Questions
            {
                Ques = "Do you like science and good news?",
            });

            Question.Add(new Questions
            {
                Ques = "Do you like zoidberg?",
            });



            BindingContext = this;
        }


        



        //Points that use determine user character. 
        int points = 0;

        //Keeps track of question number
        int questionSequence = 0;

        //A test
        string currentQuestion = "Do you like SciFi?";

        //Going to hold the image URL set to the source of the image element
        string imageUrl = "";





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
            else
            {
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
            }
            else
            {
                CharacterResult();
                OnPointsChanged(nameof(DisplayCharacter));
            }
        }


        public string DisplayNextQuestion => $"{currentQuestion}";

        public string DisplayPoints => $"You clicked {points} times(s).";

        public string DisplayCharacter => $"{imageUrl}";


        public void CharacterResult()
        {

            switch (points)
            {
                case 1:
                    imageUrl = "fry.gif";
                    break;
                case 2:
                    imageUrl = "fry.gif";
                    break;
                case 3:
                    imageUrl = "prof.jpg";
                    break;
                case 4:
                    imageUrl = "bender.jpg";
                    break;
                case 5:
                    imageUrl = "zoidberg.jpg";
                    break;
                default:
                    imageUrl = "zoidberg.jpg";
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