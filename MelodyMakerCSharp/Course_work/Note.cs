using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_work
{
    public class Note: MusicalUnit
    {
        string name;

        public Note(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { name = value; }

        }

    }

    
}
