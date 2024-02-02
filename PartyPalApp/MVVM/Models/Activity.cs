using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PartyPalApp.MVVM.Models
{
    [Table("Activities")]
    public class Activity : TableData
    {
        public string? Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        
        [ForeignKey(typeof(Event))]
        public int? EventId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Event ParentEvent { get; set; }
    }
}
