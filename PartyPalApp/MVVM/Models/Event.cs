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
    }
}
