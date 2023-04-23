using System;
using System.Collections.Generic;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            ListBoxItem franco = new ListBoxItem();
            franco.Content = "Franco";
            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(franco);
            peopleListBox.SelectedItem = james;

        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length <= 2)
            {
                MessageBox.Show("Name should be more than 2 characters!");
            }
            else
            {
                MessageBox.Show("Hello, " + txtName.Text + "! Thanks for pressing the button");
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("This is Windows Presentation Foundation!");]
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
            textBlock1.Text = DateTime.Now.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show(greetingMsg);
        }
    }
}
