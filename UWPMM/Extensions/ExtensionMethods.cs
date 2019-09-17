using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMM.Extensions
{
    public static class ExtensionMethods
    {
        public static string GetString(this string[] myStrings)
        {
            return string.Join("\r", myStrings);
        }
        public static string TrimNewsString(this string theNewsString)
        {
            string suffixToRemove = " | Inrikes";
            string theNewsStringTrimedAtTheEnd = theNewsString.Substring(0, theNewsString.Length - suffixToRemove.Length);

            return theNewsStringTrimedAtTheEnd.Replace("| ", "\r");
        }
        public static string GetDouble(this double[] myDouble)
        {
            string[] doubleToString = new string[myDouble.Length];
            for (int i = 0; i < myDouble.Length; i++)
            {
                doubleToString[i] = Math.Round(myDouble[i], 1).ToString();
                doubleToString[i] = doubleToString[i] + "°";
            }

            return string.Join("\r", doubleToString).Replace(",", ".");
        }

        public static string UnixTimeToDateTime(int unixTimeStamp)
        {
            DateTime dateTimeConverted = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeConverted = dateTimeConverted.AddSeconds(unixTimeStamp).ToLocalTime();

            string time = dateTimeConverted.ToString("HH:mm");

            return time;
        }
    }
}
