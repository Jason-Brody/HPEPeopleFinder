using System;
using System.Collections.Generic;
using System.Reflection;

namespace Utils
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class PropSkipAttribute:Attribute
    {

    }

    public static class ClassToDicHelper
    {
        public static Dictionary<string,string> ToDic(this object Obj)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach(var prop in Obj.GetType().GetProperties())
            {
                var ti = prop.PropertyType.GetTypeInfo();
                
                
                if(prop.GetCustomAttribute<PropSkipAttribute>()==null)
                {
                    if (ti.IsPrimitive || prop.PropertyType == typeof(string))
                    {
                        dic.Add(prop.Name, prop.GetValue(Obj)?.ToString());
                    }
                }
                
            }
            return dic;
        }
    }
}
