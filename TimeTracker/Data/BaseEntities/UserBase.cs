using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.BaseEntities
{
    public abstract class UserBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }

        protected UserBase()
        {
            FullName = Name + " " + Surname;
        }
    }
}
