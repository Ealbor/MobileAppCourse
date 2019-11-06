using JokeApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp.Data
{
    public class JokeDatabase
    {

        readonly SQLiteAsyncConnection database;

        public JokeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Joke>().Wait();
        }


        public Task<List<Joke>> GetJokesAsync()
        {
            return database.Table<Joke>().ToListAsync();
        }

        public Task<List<Joke>> GetJokesNotToldAsync()
        {
            return database.QueryAsync<Joke>("SELECT * FROM [Joke] WHERE [JokeTold] = 0");
        }

        public Task<Joke> GetJokeAsync(int id)
        {
            return database.Table<Joke>().Where(i =>i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveJokeAsync (Joke aJoke)
        {
            if(aJoke.ID != 0)
            {
                return database.UpdateAsync(aJoke);
            } else
            {
                return database.InsertAsync(aJoke);
            }
        }


        public Task<int> DeleteJokeAsync(Joke aJoke)
        {
            return database.DeleteAsync(aJoke);
        }

    }
}
