using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Warehousing.Utilities
{
    public static class EnumExtensions
    {
        public static void PopulateComboBoxWithEnum<T>(ComboBox comboBox) where T : Enum
        {
            comboBox.Items.Clear(); // پاک کردن مقادیر قبلی

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                comboBox.Items.Add(new { Text = GetDescription(value), Value = value });
            }

            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
        }
        public static string GetDescription<T>(this T value) where T : Enum
        {
            FieldInfo field = typeof(T).GetField(value.ToString());
            DescriptionAttribute attribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : value.ToString();
        }
    }

}
