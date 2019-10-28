using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lasy.Utility
{
    /// <summary>
    /// WebControl工具类
    /// </summary>
    public sealed class WebControlUtility
    {
        /// <summary>
        /// 获取服务器端控件的值
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static object GetValue(Control control)
        {
            if (control is ITextControl)
                return ((ITextControl)control).Text;
            else if (control is HiddenField)
                return ((HiddenField)control).Value;
            else if (control is ICheckBoxControl)
                return ((ICheckBoxControl)control).Checked;
            return null;
        }

        /// <summary>
        /// 设置服务器端控件的值
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetValue(Control control, string value)
        {
            if (control is ITextControl)
                ((ITextControl)control).Text = value;
            else if (control is HiddenField)
                ((HiddenField)control).Value = value;
            else if (control is ICheckBoxControl)
                ((ICheckBoxControl)control).Checked = ConvertUtility.ToBoolean(value, false);
        }

        /// <summary>
        /// 提取控件名称和值
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static IDictionary<string, object> GetAllValue(params Control[] controls)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if (controls == null || controls.Length == 0)
                return result;

            foreach (Control control in controls)
            {
                result.Add(control.ID, GetValue(control));
            }

            return result;
        }

        /// <summary>
        /// 提取控件名称和值
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static IDictionary<string, object> GetAllValue(ControlCollection controls)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if (controls == null || controls.Count == 0)
                return result;

            foreach (Control control in controls)
            {
                if (!string.IsNullOrEmpty(control.ID))
                    result.Add(control.ID, GetValue(control));
            }

            return result;
        }

    }
}
