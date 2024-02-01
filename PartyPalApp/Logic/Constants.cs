using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.Logic
{
    public static class Constants
    {
        public const string JOKE_RANDOM = "https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,racist";
        private const string DBFileName = "PartyPaldb";

        public const SQLiteOpenFlags flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
