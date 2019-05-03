using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppLanguages
{
    public class EnglishLanguage : ILanguage
    {
        public string FontName { get; set; } = "Broadway";

        public string Select_something_from_combobox_Title { get; set; } = "Select something from combobox ...";

        public string House_Title { get; set; } = "House";
        public string Sea_Title { get; set; } = "Sea";
        public string Cat_Title { get; set; } = "Cat";
        public string Dog_Title { get; set; } = "Dog";
        public string Bread_Title { get; set; } = "Bread";
        public string Mushroom_Title { get; set; } = "Mushroom";
        public string Car_Title { get; set; } = "Car";
        public string Pencil_Title { get; set; } = "Pencil";
        public string Road_Title { get; set; } = "Road";
        public string Clicked_Title { get; set; } = "You clicked!";
        public string ClickMe_Title { get; set; } = "Click Me";
    }
}
