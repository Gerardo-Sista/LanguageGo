using LanguageGo;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace LanguageGoWPF
{
    public class Language : MarkupExtension, IUpdateLanguage
    {

        /// <summary>
        /// key language like UserNameTitle in language json file
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// target of language element like TextBlock
        /// </summary>
        public object Target { get; set; }
        /// <summary>
        /// property of language element like Text
        /// </summary>
        public object Property { get; set; }
        /// <summary>
        /// when element want to get her value from extension
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (target != null)
            {
                Target = target.TargetObject;
                Property = target.TargetProperty;
            }
            LanguageMapper.AddElement(this);
            return GetValue(target.TargetProperty.ToString(), LanguageMapper.GetValue(Key));
        }

        private object GetValue(string name, object value)
        {
            if (name == "FontFamily")
            {
                var fontName = value.ToString();
                if (Application.Current.TryFindResource(fontName) is FontFamily font)
                {
                    return font;
                }
                else
                    return new FontFamily(fontName);
            }
            else
                return value;
        }

        public static void UpdateAll()
        {

        }
        /// <summary>
        /// update language value
        /// </summary>
        /// <param name="value">new value</param>
        public void UpdateValue(object value)
        {
            if (Target != null)
            {
                if (Property is DependencyProperty)
                {
                    DependencyObject obj = Target as DependencyObject;
                    DependencyProperty prop = Property as DependencyProperty;

                    void updateAction() => obj.SetValue(prop, GetValue(prop.Name, value));

                    // Check whether the target object can be accessed from the
                    // current thread, and use Dispatcher.Invoke if it can't

                    if (obj.CheckAccess())
                        updateAction();
                    else
                        obj.Dispatcher.Invoke(updateAction);
                }
                else // _targetProperty is PropertyInfo
                {
                    PropertyInfo prop = Property as PropertyInfo;
                    prop.SetValue(Target, value, null);
                }
            }
        }
    }
}
