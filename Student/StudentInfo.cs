using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class StudentInfo : Form
    {
        public Student _Student;

        public StudentInfo(Student _S)
        {
            InitializeComponent();
            _Student = _S;
        }

        public StudentInfo(int id)
        {
            InitializeComponent();
            _Student = new Student();
            _Student.Id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Student.Name = txt_Name.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
