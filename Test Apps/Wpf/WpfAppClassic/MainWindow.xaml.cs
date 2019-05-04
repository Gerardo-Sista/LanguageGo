using LanguageGo;
using LanguageGoWPF;
using MyAppLanguages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace WpfAppClassic
{
    public class StuffItem : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MyLanguage.Current = new EnglishLanguage();
            InitializeComponent();

            List<StuffItem> ListStuff = new List<StuffItem>();
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.House_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Sea_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Cat_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Car_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Bread_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Mushroom_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Car_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Pencil_Title }.AddToLanguage());
            ListStuff.Add(new StuffItem() { Name = MyLanguage.Current.Road_Title }.AddToLanguage());

            cbo.ItemsSource = ListStuff;
            cbo.SelectedIndex = 0;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            //bind it in language in code behind
            tblock_result.AddToLanguageProperty(nameof(tblock_result.Text)).Text = MyLanguage.Current.Clicked_Title;
            //tblock_result.Text = "You clicked!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyLanguage.Current = new EnglishLanguage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyLanguage.Current = new PersianLanguage();
        }
    }
}
