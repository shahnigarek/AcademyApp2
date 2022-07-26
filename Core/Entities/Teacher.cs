using Core.Abstarctions;
using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Teacher:Person,IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public byte Age { get; set; }

        public List<Group> Groups { get; set; } 
    }
}
