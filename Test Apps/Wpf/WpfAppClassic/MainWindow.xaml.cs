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

namespace WpfAppClassic
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> ListStuff = new List<string>();
            ListStuff.Add("House");
            ListStuff.Add("Sea");
            ListStuff.Add("Cat");
            ListStuff.Add("Dog");
            ListStuff.Add("Bread");
            ListStuff.Add("Mushroom");
            ListStuff.Add("Car");
            ListStuff.Add("Pencil");
            ListStuff.Add("Road");

            cbo.ItemsSource = ListStuff;
            cbo.SelectedIndex = 0;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            tblock_result.Text = "You clicked!";
        }
    }
}
