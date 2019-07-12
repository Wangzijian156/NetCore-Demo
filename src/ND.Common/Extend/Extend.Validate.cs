using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ND.Common
{
    /// <summary>
    /// 基本工具类（字符串验证扩展）
    /// </summary>
    public static partial class Extend
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return IsEmpty(value.Value);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                return true;
            return false;
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 正则是否匹配
        /// </summary>
        public static bool IsMatch(this string param, string regexStr)
        {
            if (IsEmpty(param)) return false;
            Regex rgx = new Regex(regexStr);
            return rgx.IsMatch(param);
        }

        /// <summary>
        /// 验证手机号格式
        /// </summary>
        public static bool IsPhoneNum(this string param) =>
            param.IsMatch(@"^((13[0-9])|(14[5,7])|(15[0-3,5-9])|(17[0,3,5-8])|(18[0-9])|166|198|199|(147))\d{8}$");

        /// <summary>
        /// 验证Email格式
        /// </summary>
        public static bool IsEmail(this string param) =>
            param.IsMatch(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+[\.][a-zA-Z0-9_-]+$");

        /// <summary>
        /// 验证ip地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(this string param) =>
            param.IsMatch(@"^(?:(?:25[0-5]|2[0-4]\d|(?:(?:1\d{2})|(?:[1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|(?:(?:1\d{2})|(?:[1-9]?\d)))$");


    }
}
