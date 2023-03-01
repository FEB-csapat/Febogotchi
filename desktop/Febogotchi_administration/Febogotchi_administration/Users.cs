using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Febogotchi_administration
{
    public class Users
    {
        public int id { get; set; }
        public Pets[] pets { get; set; }
        public string name { get; set; }
        public string[] roles { get; set; }

        public override string ToString()
        {
            return "id: " + id + "\n" + "name:" + name +"\n"+ "pets: " + pets + "\n" + "roles" + roles;
        }
    }
    

}
