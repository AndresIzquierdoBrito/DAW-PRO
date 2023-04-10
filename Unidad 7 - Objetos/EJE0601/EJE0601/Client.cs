using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Client
    {
        private string name;

        private string firstSurname;

        private string lastSurname;

        private int id;

        private static int lastId = 0;

        public Client(string name, string firstSurname, string lastSurname)
         {
            this.name = name;
            this.firstSurname = firstSurname;
            this.lastSurname = lastSurname;
            this.id = ++lastId;
        }


        public string Name
        {
            get => name;
            set => name = value;
        }

        public string FirstSurname
        {
            get => firstSurname;
            set => firstSurname = value;
        }

        public string LastSurname
        {
            get => lastSurname; 
            set => lastSurname = value;
        }

        public int Id
        {
            get => id; 
        }
    }
}
