﻿namespace CJLUDormWifi.Utils
{
    public class Helper
    {
        public static string GetMiddleStr(string oldStr, string preStr, string nextStr)
        {
            string tempStr = oldStr.Substring(oldStr.IndexOf(preStr) + preStr.Length);
            tempStr = tempStr.Substring(0, tempStr.IndexOf(nextStr));
            return tempStr;
        }
    }
}
