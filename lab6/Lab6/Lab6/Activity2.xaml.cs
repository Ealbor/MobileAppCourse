
using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Activity2 : ContentPage
    {


        Random random1 = new Random();
        Random random2= new Random();
        Random random3 = new Random();
        Random random4 = new Random();
        public int x;
        public int knownVariable;
        public int dummyNum;
        public int buttonRandomize;
        public int solution;
        Player player;

        public Activity2(Player player)
        {
            //Upon initialization, display is produced. 
            InitializeComponent();
            ReRandomize();
            this.player = player;
            
        }

        async void ToPlayerRecords(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerRecords());
        }

        public async void OnButton1(object sender, EventArgs e)
        {
            
            if (Btn1.Text.Equals(x.ToString()))
            {
            player.Score++;
            }else{
            player.Score--;
            }

            Console.WriteLine(player.Score);
            ReRandomize();
        }

         public async void OnButton2(object sender, EventArgs e)
        {
            
            if (Btn2.Text.Equals(x.ToString()))
            {
                player.Score++;
            }else
            {
                player.Score--;
            }

            Console.WriteLine(player.Score);
           ReRandomize();
        }

        public void ReRandomize()
        {

            //Randomize again
            x = random1.Next(5, 22);
            knownVariable = random2.Next(5, 22);
            dummyNum = random3.Next(5, 22);
            solution = x * knownVariable;

            //Determines which button will have answer
            buttonRandomize = random4.Next(1, 3);
            if (buttonRandomize > 1)
            {

                Display.Text = knownVariable.ToString() + " * X = " + solution.ToString();
                Btn1.Text = x.ToString();
                Btn2.Text = (dummyNum-1).ToString();
               
            }else
            {
                Display.Text = knownVariable.ToString() + " * X = " + solution.ToString();
                Btn2.Text = x.ToString();
                Btn1.Text = (dummyNum+1).ToString();
               
            }
        }
    }
}