using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.Models
{
    public class EventFlyer
    {
        public string ImageUrl { get; }
        public string Name { get; }
        public DateTime Date { get; }
        public DateTime StartTime { get; }
        public string Price { get; }
        public string Details { get; }
        public List<Lounge> Lounges { get; }
    }
}
