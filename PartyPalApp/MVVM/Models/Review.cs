using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.Models
{
    [Table("Reviews")]
    public class Review : TableData
    {
        [Column("name"), Indexed, NotNull]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public int Score { get; set; }
    }
}
