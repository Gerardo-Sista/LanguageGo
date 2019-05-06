using LanguageGo;
using MyAppLanguages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAppClassic
{
    public class StuffItem : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //bind it in language in code behind
            tblock_result.AddToLanguageProperty(nameof(tblock_result.Text)).Text = MyLanguage.Current.Clicked_Title;
            //tblock_result.Text = "You clicked!";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MyLanguage.Current = new EnglishLanguage();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            MyLanguage.Current = new PersianLanguage();
        }
    }
}
