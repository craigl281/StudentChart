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
            this.txt_Id.Text = _Student.Id.ToString();
            this.txt_Name.Text = _Student.Name;
        }

        public StudentInfo(int id)
        {
            InitializeComponent();
            _Student = new Student();
            _Student.Id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveMethod();
        }

        private void SaveMethod()
        {
            _Student.Name = txt_Name.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveMethod();
        }
    }
}
