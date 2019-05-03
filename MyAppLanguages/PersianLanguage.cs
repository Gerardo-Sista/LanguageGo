namespace MyAppLanguages
{
    public class PersianLanguage : ILanguage
    {
        public string FontName { get; set; } = "Tahoma";

        public string Select_something_from_combobox_Title { get; set; } = "لطفا از کمبوباکس یک گزینه را انتخاب کنید...";
        public string House_Title { get; set; } = "خانه";
        public string Sea_Title { get; set; } = "دریا";
        public string Cat_Title { get; set; } = "گربه";
        public string Dog_Title { get; set; } = "سگ";
        public string Bread_Title { get; set; } = "نان";
        public string Mushroom_Title { get; set; } = "قارچ";
        public string Car_Title { get; set; } = "ماشین";
        public string Pencil_Title { get; set; } = "مداد";
        public string Road_Title { get; set; } = "جاده";
        public string Clicked_Title { get; set; } = "شما کلیک کردید!";
        public string ClickMe_Title { get; set; } = "کیلیک کنید";
    }
}
