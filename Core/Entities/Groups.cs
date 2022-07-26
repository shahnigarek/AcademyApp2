﻿using Core.Abstarctions;
using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Group:Person,IEntity
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxSize{ get; set; }
        public int CurrentSize { get; set; }
        public Teacher Teacher { get; set; }  

    }
}
