using Lab6.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Data
{
    public class PlayerDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public PlayerDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Player>().Wait();
        }

        public Task<List<Player>> GetPlayerAsync()
        {
            return _database.Table<Player>().ToListAsync();
        }

        public Task<Player> GetPlayerAsync(int id)
        {
            return _database.Table<Player>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePlayerAsync(Player player)
        {
            if (player.ID != 0)
            {
                return _database.UpdateAsync(player);
            } else
            {
                return _database.InsertAsync(player);
            }
        }

        public Task<int> DeletePlayerAsync(Player player)
        {
            return _database.DeleteAsync(player);
        }

    }
}
