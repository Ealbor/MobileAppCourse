using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokeApp.Models
{
    public class Joke
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string JokeName{ get; set; }
        public string JokeDetails { get; set; }
        public bool JokeTold { get; set; }
    }
}
