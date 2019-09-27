using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }


        public void setScore(int score)
        {
            Score = score;
        }

    }


}
