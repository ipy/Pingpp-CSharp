using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Pingpp.Lib.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Pingpp.Lib.Param
{
    public class BaseParam
    {
        public Dictionary<string, string> ToDictionary()
        {
            var paramType = this.GetType();
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(paramType), paramType);
            bool valid = Validator.TryValidateObject(this, new ValidationContext(this, null, null), new List<ValidationResult>(), true);
            if (!valid)
            {
                throw new ValidationException();
            }

            var dict = new Dictionary<string, string>();
            var props = this.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                var name = prop.Name.ToSnakeCase();
                var value = prop.GetMethod.Invoke(this, new object[] { });
                var valueType = prop.PropertyType;

                if (value == null)
                {
                }
                else if (valueType == typeof(Dictionary<string, string>))
                {
                    var valueDict = (Dictionary<string, string>)value;
                    foreach (var pair in valueDict)
                    {
                        dict.Add(name + "[" + pair.Key.ToSnakeCase() + "]", pair.Value);
                    }
                }
                else
                {
                    dict.Add(name, value.ToString());
                }
            }
            return dict;
        }
    }
}
