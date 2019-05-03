using LanguageGo;

namespace MyAppLanguages
{
    public class MyLanguage
    {
        private static ILanguage _Current;

        public static ILanguage Current
        {
            get
            {
                return _Current;
            }
            set
            {
                _Current = value;
                LanguageMapper.ChangeLanguage(value);
            }
        }
    }
}
