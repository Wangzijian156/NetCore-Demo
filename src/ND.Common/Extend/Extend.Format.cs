using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ND.Common
{
    /// <summary>
    /// 基本工具类（字符格式化展部分）
    /// </summary>
    public static partial class Extend
    {
        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string Format(this int number, string defaultValue = "")
        {
            if (number == 0)
                return defaultValue;
            return number.ToString();
        }
        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string Format(this int? number, string defaultValue = "")
        {
            return Format(number.SafeValue(), defaultValue);
        }
        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string Format(this decimal number, string defaultValue = "")
        {
            if (number == 0)
                return defaultValue;
            return string.Format("{0:0.##}", number);
        }
        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string Format(this decimal? number, string defaultValue = "")
        {
            return Format(number.SafeValue(), defaultValue);
        }
        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string Format(this double number, string defaultValue = "")
        {
            if (number == 0)
                return defaultValue;
            return string.Format("{0:0.##}", number);
        }
        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string Format(this double? number, string defaultValue = "")
        {
            return Format(number.SafeValue(), defaultValue);
        }
        /// <summary>
        /// 获取格式化字符串,带￥
        /// </summary>
        /// <param name="number">数值</param>
        public static string FormatRmb(this decimal number)
        {
            if (number == 0)
                return "￥0";
            return string.Format("￥{0:0.##}", number);
        }
        /// <summary>
        /// 获取格式化字符串,带￥
        /// </summary>
        /// <param name="number">数值</param>
        public static string FormatRmb(this decimal? number)
        {
            return FormatRmb(number.SafeValue());
        }
        /// <summary>
        /// 获取格式化字符串,带%
        /// </summary>
        /// <param name="number">数值</param>
        public static string FormatPercent(this decimal number)
        {
            if (number == 0)
                return string.Empty;
            return string.Format("{0:0.##}%", number);
        }
        /// <summary>
        /// 获取格式化字符串,带%
        /// </summary>
        /// <param name="number">数值</param>
        public static string FormatPercent(this decimal? number)
        {
            return FormatPercent(number.SafeValue());
        }
        /// <summary>
        /// 获取格式化字符串,带%
        /// </summary>
        /// <param name="number">数值</param>
        public static string FormatPercent(this double number)
        {
            if (number == 0)
                return string.Empty;
            return string.Format("{0:0.##}%", number);
        }
        /// <summary>
        /// 获取格式化字符串,带%
        /// </summary>
        /// <param name="number">数值</param>
        public static string FormatPercent(this double? number)
        {
            return FormatPercent(number.SafeValue());
        }


    }
}
