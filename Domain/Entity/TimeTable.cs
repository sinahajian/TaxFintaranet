using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public static class Timestatic
    {
        public static TimeTable TimeTables = new TimeTable();
    }

    public class TimeTable
    {
        public List<Time> Times { get; set; } = new List<Time>();
        public TimeTable()
        {

        }
    }
    public class Time
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Tax { get; set; }
        public Time()
        {

        }
    }
}
