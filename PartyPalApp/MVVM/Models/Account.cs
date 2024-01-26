using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.Models
{
    [Table("Accounts")]
    public class Account
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
