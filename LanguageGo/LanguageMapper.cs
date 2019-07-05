using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LanguageGo
{
    public static class AppLanguageExtension
    {
        public static T AddToLanguage<T>(this T obj)
        {
            if (!(obj is INotifyPropertyChanged))
                throw new Exception("Your class doesn't inherit from INotifyPropertyChanged");
            if (!LanguageMapper.CustomObjects.Contains(obj))
                LanguageMapper.CustomObjects.Add(obj);
            return obj;
        }

        public static T AddToLanguageProperty<T>(this T obj, string property)
        {
            if (LanguageMapper.CustomObjectProperties.TryGetValue(obj, out List<string> properties))
            {
                if (!properties.Contains(property))
                    properties.Add(property);
            }
            else
                LanguageMapper.CustomObjectProperties.Add(obj, new List<string>() { property });
            return obj;
        }
    }

    /// <summary>
    /// base of language mapper
    /// </summary>
    public static class LanguageMapper
    {
        internal static List<object> CustomObjects { get; set; } = new List<object>();
        internal static Dictionary<object, List<string>> CustomObjectProperties { get; set; } = new Dictionary<object, List<string>>();

        public static ILanguageBase Current { get; set; }
        public static ILanguageBase PreviousLanguage { get; set; }
        /// <summary>
        /// all element binded to language mapper
        /// </summary>
        public static List<IUpdateLanguage> LanguagesElements { get; set; } = new List<IUpdateLanguage>();

        /// <summary>
        /// load language from resource file
        /// </summary>
        private static void LoadLanguage(ILanguageBase language)
        {
            PreviousLanguage = Current;
            Current = language;
        }
        /// <summary>
        /// add new element to binding elements
        /// </summary>
        /// <param name="updateLanguage"></param>
        public static void AddElement(IUpdateLanguage updateLanguage)
        {
            LanguagesElements.Remove(updateLanguage);
            LanguagesElements.Add(updateLanguage);
        }
        /// <summary>
        /// get value from language resource
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            if (Current != null)
                return (string)Current.GetType().GetProperty(key).GetValue(Current);
            return "**Language value not found!";

        }
        /// <summary>
        /// update all in UI
        /// </summary>
        public static void UpdateAll()
        {
            foreach (IUpdateLanguage item in LanguagesElements)
            {
                string newValue = GetValue(item.Key);
                item.UpdateValue(newValue);
            }

            if (PreviousLanguage != null)
            {
                foreach (object item in CustomObjects)
                {
                    foreach (PropertyInfo property in item.GetType().GetProperties())
                    {
                        try
                        {
                            object value = property.GetValue(item);
                            if (value is string)
                            {
                                string newValue = FindProperyValueInPreviousLanguage(value);
                                if (newValue != null)
                                    property.SetValue(item, newValue);
                                if (item is INotifyPropertyChanged changed)
                                {
                                    FieldInfo field = changed.GetType().GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
                                    MulticastDelegate multicastDelegate = field.GetValue(changed) as MulticastDelegate;
                                    if (multicastDelegate == null)
                                        continue;

                                    Delegate[] invocationList = multicastDelegate.GetInvocationList();

                                    foreach (Delegate invocationMethod in invocationList)
                                        invocationMethod.DynamicInvoke(new[] { item, new PropertyChangedEventArgs(property.Name) });
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                foreach (KeyValuePair<object, List<string>> keyValue in CustomObjectProperties)
                {
                    object item = keyValue.Key;
                    List<string> properties = keyValue.Value;

                    foreach (PropertyInfo property in item.GetType().GetProperties().Where(x => properties.Contains(x.Name)))
                    {
                        try
                        {
                            object value = property.GetValue(item);
                            if (value is string)
                            {
                                string newValue = FindProperyValueInPreviousLanguage(value);
                                if (newValue != null)
                                    property.SetValue(item, newValue);
                                if (item is INotifyPropertyChanged changed)
                                {
                                    FieldInfo field = changed.GetType().GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
                                    MulticastDelegate multicastDelegate = field.GetValue(changed) as MulticastDelegate;
                                    if (multicastDelegate == null)
                                        return;

                                    Delegate[] invocationList = multicastDelegate.GetInvocationList();

                                    foreach (Delegate invocationMethod in invocationList)
                                        invocationMethod.DynamicInvoke(new[] { item, new PropertyChangedEventArgs(property.Name) });
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        private static string FindProperyValueInPreviousLanguage(object value)
        {
            foreach (PropertyInfo property in PreviousLanguage.GetType().GetProperties())
            {
                object val = property.GetValue(PreviousLanguage);
                if (val == value)
                {
                    return (string)Current.GetType().GetProperty(property.Name).GetValue(Current);
                }
            }
            return null;
        }

        /// <summary>
        /// change application language
        /// </summary>
        /// <param name="fileName"></param>
        public static void ChangeLanguage(ILanguageBase language)
        {
            LoadLanguage(language);
            UpdateAll();
        }
    }
}
