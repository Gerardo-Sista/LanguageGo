using LanguageGo;

namespace MyAppLanguages
{
    public interface ILanguage : ILanguageBase
    {
        string Select_something_from_combobox_Title { get; set; }
        string House_Title { get; set; }
        string Sea_Title { get; set; }
        string Cat_Title { get; set; }
        string Dog_Title { get; set; }
        string Bread_Title { get; set; }
        string Mushroom_Title { get; set; }
        string Car_Title { get; set; }
        string Pencil_Title { get; set; }
        string Road_Title { get; set; }
        string Clicked_Title { get; set; }
        string ClickMe_Title { get; set; }
    }
}
