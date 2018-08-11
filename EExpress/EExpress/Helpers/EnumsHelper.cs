using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EExpress.Helpers
{
    public static class EnumsHelper
    {
        public static SelectList GetSelectedListItem<T>() where T : struct
        {
            T t = default(T);

            if (!t.GetType().IsEnum)
                throw new Exception();

            var values = t.GetType().GetEnumValues();

            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            if(values != null && values.Length > 0)
            {
                foreach (var value in values)
                {
                    string description = GetEnumDescription(value as Enum);

                    if (!myDictionary.ContainsKey((int)value))
                        myDictionary.Add((int)value, description);
                }

                return new SelectList(myDictionary, "Key", "Value");

            }

            return null;
        }

        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;
        }
    }
}