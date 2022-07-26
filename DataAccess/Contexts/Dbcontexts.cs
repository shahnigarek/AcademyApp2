using Core.Entities;
using Core.Helpers;
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
            Admins=new List<Admin> ();
            Teacher=new List<Teacher> ();   

            string password = "academyapp";
            var hashedPassword = PasswordHasher.Encrypt(password);
            Admin admin1=new Admin("admin1",hashedPassword);
            Admins.Add(admin1);

            string password1 = "chaand";
            var hashedPassword1=PasswordHasher.Encrypt(password1);
            Admin admin2 = new Admin("admin2", hashedPassword1);
            Admins.Add(admin2);



        }

        public static List<Student> Students { get; set; }
        public static List<Group> Groups { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Teacher> Teacher { get; set; }


    }




}

