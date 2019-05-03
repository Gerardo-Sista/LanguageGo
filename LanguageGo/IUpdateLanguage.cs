using System;

namespace LanguageGo
{
    /// <summary>
    /// update language interface
    /// </summary>
    public interface IUpdateLanguage
    {
        /// <summary>
        /// key language like UserNameTitle in language json file
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// target of language element like TextBlock
        /// </summary>
        object Target { get; set; }
        /// <summary>
        /// property of language element like Text
        /// </summary>
        object Property { get; set; }
        /// <summary>
        /// update language value
        /// </summary>
        /// <param name="value">new value</param>
        void UpdateValue(object value);
    }
}
