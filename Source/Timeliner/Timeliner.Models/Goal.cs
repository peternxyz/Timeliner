using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeliner.Models
{
    public class Goal
    {
        public string Name { get; private set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; internal set; }

        public TimeSpan Duration { get; set; }

        public string Predecessor { get; set; }
        public bool Completed { get; set; }

        public Goal(string name)
        {
            Name = name;
        }
    }
}
