using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Student
{
    public partial class Form1 : Form
    {
        List<Student> StudentList;
        public Form1()
        {
            InitializeComponent();

            ///Tries to load in the addressbook file
            ///If it doesn't exist or errors out, creates a dummy 
            ///Then if it does load in to our variable, it'll plant that into our list of objects
            try
            {
                var File = System.IO.File.ReadAllText(@"C:\Student.txt");
                StudentList = JsonConvert.DeserializeObject<List<Student>>(File);
            }
            catch
            {
                StudentList = new List<Student>();
                StudentList.Add(new Student());
            }
            studentBindingSource.DataSource = StudentList;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StudentInfo _AddStudent = new StudentInfo(StudentList.Max(x => x.Id) + 1);
            if (_AddStudent.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                studentBindingSource.Add(_AddStudent._Student);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            StudentInfo _AddStudent = new StudentInfo((Student)studentBindingSource.Current);
            if (_AddStudent.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                studentBindingSource[studentBindingSource.Position] = _AddStudent._Student;
        }


    }
}
