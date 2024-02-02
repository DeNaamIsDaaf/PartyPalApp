using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.Models
{
    [Table("Events")]
    public class Event : TableData
    {
        public string? Title { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime Date { get; set; }

        [OneToMany]
        public List<Activity>? Activities { get; set; }

        public int AttendanceCount { get; set; } = 0;

        public double AttendanceProgress
        {
            get { return (double)AttendanceCount / 20; } // Alle events hebben een maximum van 20 Aangezien dit later is toegevoegd.
        }
    }
}
