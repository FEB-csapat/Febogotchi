using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Febogotchi_administration
{
    public class Pets
    {
        public int id { get; set; }
        public Types type { get; set; }
        public Statuses status { get; set; }
        public string status_start { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int happiness { get; set; }
        public int wellbeing { get; set; }
        public int fittness { get; set; }
        public int sate { get; set; }
        public int energy { get; set; }
        public string birth_date { get; set; }
        public bool is_alive { get; set; }


    }
}
