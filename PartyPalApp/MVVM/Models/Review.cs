using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.Models
{
    public class Review
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Score { get; set; }

        public Review(string name, string description, int score)
        {
            Name = name;
            Description = description;
            Score = score;
        }
    }
}
