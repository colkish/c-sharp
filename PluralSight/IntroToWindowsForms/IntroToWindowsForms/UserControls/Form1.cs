﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var p = new Person
            {
                FirstName = "Colin",
                LastName = "Kish",
                Age = 21
            };

            personControl1.Person = p;
        }

    }
}
