using System;
using System.ComponentModel;
using System.Linq;

namespace Sistema.Bico.Domain.Generics.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if(value != null)
            {
                var fi = value.GetType().GetField(value.ToString());
                var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                return attributes != null && attributes.Any() ? attributes.First().Description : value.ToString();
            }

            return "";
          
        }
    }
}
