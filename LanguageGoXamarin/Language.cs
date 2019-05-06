using LanguageGo;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageGoXamarin
{
    public class Language : IMarkupExtension, IUpdateLanguage
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
        public object ProvideValue(IServiceProvider serviceProvider)
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
            if (Application.Current.Resources.TryGetValue(value.ToString(), out object fontFamily))
            {
                return fontFamily;
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
                if (Property is BindableProperty)
                {
                    BindableObject obj = Target as BindableObject;
                    BindableProperty prop = Property as BindableProperty;

                    obj.SetValue(prop, GetValue(prop.PropertyName, value));
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
