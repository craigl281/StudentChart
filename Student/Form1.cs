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

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StudentInfo _AddStudent = new StudentInfo(StudentList.Max(x => x.Id) + 1);
            if (_AddStudent.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                studentBindingSource.Add(_AddStudent._Student);
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StudentInfo _AddStudent = new StudentInfo((Student)studentBindingSource.Current);
            if (_AddStudent.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                studentBindingSource[studentBindingSource.Position] = _AddStudent._Student;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentBindingSource.RemoveCurrent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseProgram();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void CloseProgram()
        {
            SaveData();
            this.Close();
        }

        void SaveData()
        {
            ///First lets alpha sort our contacts list.  Or we can sort by something else if wanted
            //StudentList.Sort((l, r) => l * l.Name.CompareTo(r.Name));
            ///Create a Json text representation with indents for easy reading.  Of our list of objects
            var File = JsonConvert.SerializeObject(StudentList, Formatting.Indented);
            ///Write that text into a file
            ///I could always error handle for permissions
            System.IO.File.WriteAllText(@"C:\Student.txt", File);
        }
    }
}
