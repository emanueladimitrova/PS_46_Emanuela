using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string ConnectionString = "Data Source=GAS-LAPTOP;Initial Catalog = StudentsInfoDatabase; Integrated Security = True";
        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in MainGrid.Children)
            {
                if(item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            StudentValidation validate = new StudentValidation();
            if (validate.TestStudentsIfEmpty())
            {
                StudentData studentData = new StudentData();
                studentData.copyTestStudents();
            }

            if (UserData.checkIfPresentUsers())
            {
                UserData.copyTestUsers();
            }

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents.First(); //our test student
            txtFirstName.Text = student.Name;
            txtMiddleName.Text = student.MiddleName;
            txtLastName.Text = student.FamilyName;
            txtFaculty.Text = student.Faculty;
            txtSpecialty.Text = student.Specialty;
            txtEducationLevel.Text = student.EducationLevel;
            txtStatus.Text = student.Status;
            txtFakNum.Text = student.FacultyNumber;
            txtCourse.Text = student.Course;
            txtFacultyGroup.Text = student.FacultyGroup;
            txtLocalizedGroup.Text = student.LocalizedGroup;
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            //Debug.WriteLine(ConnectionString);
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlquery = "SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
    }
}
