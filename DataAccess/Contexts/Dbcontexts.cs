using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Core.Entities.Group;

namespace DataAccess.Contexts
{
    public static class Dbcontexts
    {
        static Dbcontexts()
        {
            Students = new List<Student>();
            Groups=new List<Group> (); 

        }

        public static List<Student> Students { get; set; }
        public static List<Group> Groups { get; set; }
    }




}

