using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {

            InitializeComponent();
        }

        private Person _person;

        public Person Person
        {
            get
            {
                _person.FirstName = firstNameTextBox.Text;
                _person.LastName = lastNameTextBox.Text;
                _person.Age = Convert.ToInt32(ageTextBox.Text);
                return _person;
            }
            set
            {
                firstNameTextBox.Text = value.FirstName;
                lastNameTextBox.Text = value.LastName;
                ageTextBox.Text = value.Age.ToString();
                _person = value;
            }

        }
    }
}
