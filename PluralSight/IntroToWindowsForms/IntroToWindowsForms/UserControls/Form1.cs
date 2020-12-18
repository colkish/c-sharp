using System;
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
            //per is a public class, so p is a new instance of person and here I have initialed it's values
            var p = new Person
            {
                FirstName = "Colin",
                LastName = "Kish",
                Age = 21
            };

            //set person instance in the user control to p
            personControl1.Person = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This proves we are getting and setting the values in the USer control person instance when we update the text boxes.
            MessageBox.Show(personControl1.Person.LastName);
        }
    }
}
