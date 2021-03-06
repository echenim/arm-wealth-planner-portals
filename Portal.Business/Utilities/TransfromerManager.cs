﻿using System;
using System.Globalization;

namespace Portal.Business.Utilities
{
    public static class TransfromerManager
    {
        /// <summary>
        /// method to convert date to human readible form
        /// converting 2019-01-28 14:09:23 => Today Jan 2019 2:14 PM
        /// converting 2019-01-28 14:09:23 => Yesterday Jan 2019 2:14 PM
        /// converting 2019-01-28 14:09:23 => 28 Jan 2019 2:14 PM
        /// </summary>
        /// <param name="dateToHumanize">DateTime</param>
        /// <returns>date in human format</returns>
        public static string DateHumanized(string dateToHumanize)
        {
            var dates = DateTime.Parse(dateToHumanize);

            return (DateTime.Now.Date - dates.Date).Days == 0
                ? $"Today {dates:MMM yyyy hh:mm tt}"
                : (DateTime.Now.Date - dates.Date).Days == 1
                    ? $"Yesterday {dates:MMM yyyy hh:mm tt}"
                    : $"{dates:dd MMM yyyy hh:mm tt}";
        }

        public static string DateHumanized(DateTime dateToHumanize)
            => (DateTime.Now.Date - dateToHumanize.Date).Days == 0
                ? $"Today {dateToHumanize:MMM yyyy hh:mm tt}"
                : (DateTime.Now.Date - dateToHumanize.Date).Days == 1
                    ? $"Yesterday {dateToHumanize:MMM yyyy hh:mm tt}"
                    : $"{dateToHumanize:dd MMM yyyy hh:mm tt}";

        /// <summary>
        /// format decimals to #,##0.##
        /// 12314 =>  12,314
        /// 12314.23123  => 12,314.23
        /// 12314.2  => 12,314.2
        /// 1231412314.2  => 1,231,412,314.2
        /// </summary>
        /// <param name="decimalToHumanized">decimalToHumanized</param>
        /// <returns>#,##0.##</returns>
        public static string DecimalHuamanized(decimal decimalToHumanized)
        => $"{decimalToHumanized:#,##0.##}";

        /// <summary>
        /// format integer to #,##0.##
        /// 12314 =>  12,314
        /// 12314.23123  => 12,314.23
        /// 12314.2  => 12,314.2
        /// 1231412314.2  => 1,231,412,314.2
        /// </summary>
        /// <param name="decimalToHumanized">decimalToHumanized</param>
        /// <returns>#,##0.##</returns>
        public static string IntegerHuamanized(int intToHumanized)
            => $"{intToHumanized:#,##0}";

        /// <summary>
        /// format integer to #,##0.##
        /// 12314 =>  12,314
        /// 12314.23123  => 12,314.23
        /// 12314.2  => 12,314.2
        /// 1231412314.2  => 1,231,412,314.2
        /// </summary>
        /// <param name="intToHumanized">decimalToHumanized</param>
        /// <returns>#,##0.##</returns>
        public static string IntegerHuamanized(long intToHumanized)
            => $"{intToHumanized:#,##0}";

        /// <summary>
        /// format decimals to #,##0.##
        /// 12314 =>  12,314
        /// 12314.23123  => 12,314.23
        /// 12314.2  => 12,314.2
        /// 1231412314.2  => 1,231,412,314.2
        /// </summary>
        /// <param name="decimalToHumanized">decimalToHumanized</param>
        /// <returns>#,##0.##</returns>
        public static string DecimalHumanizedX(decimal decimalToHumanized)
            => decimalToHumanized.ToString("N1", CultureInfo.InvariantCulture);

        public static string DefaultPassword()
            => "103Solutionx$#@";
    }
}