using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Speaker(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }

}
