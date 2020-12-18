using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{

    //person control is a new public class
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {

            InitializeComponent();
        }

        //declare _person instance of type person

        private Person _person;

        public Person Person
        { // Person is a public class within the User control and here I get it's values from the user control text box
            get
            {
                _person.FirstName = firstNameTextBox.Text;
                _person.LastName = lastNameTextBox.Text;
                _person.Age = Convert.ToInt32(ageTextBox.Text);
                return _person;
            } // here I display the values from the _person instance
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
