﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Objects
    {
    }
    public class Student
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Student()
        {

        }

        public Student(int _i, string name)
        {
            this.Id = _i;
            this.Name = name;
        }

    }
}
