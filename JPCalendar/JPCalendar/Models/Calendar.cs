using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;

namespace JPCalendar.Models
{
    public class Calendar
    {
        public bool IsLeapYear(int year)//判断某年是不是闰年
        {
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            {
                //Console.WriteLine("是 闰年");
                return true;
            }
            else
            {
                //Console.WriteLine("不是 闰年");
                return false;
            }
        }
        public int WhatDay(int currentYear, int month)//判断从某年某月第一天是星期几
        {
            int num;
            int totalDays = 0;
            for (int i = 1900; i < currentYear; i++)
            {
                if (IsLeapYear(i))
                {
                    totalDays += 366;
                }
                else
                {
                    totalDays += 365;
                }

            }
            for (int j = 1; j < month; j++)
            {
                totalDays += EveryMonthDays(currentYear, j);
            }

            num = totalDays % 7;
            return num + 1;
        }
        public int EveryMonthDays(int year, int month)//判断某年每个月的天数
        {
            int i = month;
            int monthDay;
            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
            {
                monthDay = 31;
            }

            else if (i == 4 || i == 6 || i == 9 || i == 11)
            {
                monthDay = 30;
            }

            else if (i == 2 && IsLeapYear(year) == true)
            {
                monthDay = 29;
            }
            else
            {
                monthDay = 28;
            }
            return monthDay;
        }


    }

    public class Lunar
    {     
        //天干  
        //private static string[] TianGan = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        //地支  
        //private static string[] DiZhi = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        //十二生肖  
        //private static string[] ShengXiao = { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        //农历日期  
        private static string[] DayName = { "*", "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十" };
        //农历月份
        private static string[] MonthName = { "*", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };
        //公历月计数天  
        private static int[] MonthAdd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        //农历数据  
        private static int []LunarData = {
     0x04AE53,0x0A5748,0x5526BD,0x0D2650,0x0D9544,
     0x46AAB9,0x056A4D,0x09AD42,0x24AEB6,0x04AE4A, //1901-1910

     0x6A4DBE,0x0A4D52,0x0D2546,0x5D52BA,0x0B544E,
     0x0D6A43,0x296D37,0x095B4B,0x749BC1,0x049754, //1911-1920

     0x0A4B48,0x5B25BC,0x06A550,0x06D445,0x4ADAB8,
     0x02B64D,0x095742,0x2497B7,0x04974A,0x664B3E, //1921-1930

     0x0D4A51,0x0EA546,0x56D4BA,0x05AD4E,0x02B644,
     0x393738,0x092E4B,0x7C96BF,0x0C9553,0x0D4A48, //1931-1940

     0x6DA53B,0x0B554F,0x056A45,0x4AADB9,0x025D4D,
     0x092D42,0x2C95B6,0x0A954A,0x7B4ABD,0x06CA51, //1941-1950

     0x0B5546,0x555ABB,0x04DA4E,0x0A5B43,0x352BB8,
     0x052B4C,0x8A953F,0x0E9552,0x06AA48,0x7AD53C, //1951-1960

     0x0AB54F,0x04B645,0x4A5739,0x0A574D,0x052642,
     0x3E9335,0x0D9549,0x75AABE,0x056A51,0x096D46, //1961-1970

     0x54AEBB,0x04AD4F,0x0A4D43,0x4D26B7,0x0D254B,
     0x8D52BF,0x0B5452,0x0B6A47,0x696D3C,0x095B50, //1971-1980

     0x049B45,0x4A4BB9,0x0A4B4D,0xAB25C2,0x06A554,
     0x06D449,0x6ADA3D,0x0AB651,0x093746,0x5497BB, //1981-1990

     0x04974F,0x064B44,0x36A537,0x0EA54A,0x86B2BF,
     0x05AC53,0x0AB647,0x5936BC,0x092E50,0x0C9645, //1991-2000

     0x4D4AB8,0x0D4A4C,0x0DA541,0x25AAB6,0x056A49,
     0x7AADBD,0x025D52,0x092D47,0x5C95BA,0x0A954E, //2001-2010

     0x0B4A43,0x4B5537,0x0AD54A,0x955ABF,0x04BA53,
     0x0A5B48,0x652BBC,0x052B50,0x0A9345,0x474AB9, //2011-2020

     0x06AA4C,0x0AD541,0x24DAB6,0x04B64A,0x69573D,
     0x0A4E51,0x0D2646,0x5E933A,0x0D534D,0x05AA43, //2021-2030

     0x36B537,0x096D4B,0xB4AEBF,0x04AD53,0x0A4D48,
     0x6D25BC,0x0D254F,0x0D5244,0x5DAA38,0x0B5A4C, //2031-2040

     0x056D41,0x24ADB6,0x049B4A,0x7A4BBE,0x0A4B51,
     0x0AA546,0x5B52BA,0x06D24E,0x0ADA42,0x355B37, //2041-2050

     0x09374B,0x8497C1,0x049753,0x064B48,0x66A53C,
     0x0EA54F,0x06B244,0x4AB638,0x0AAE4C,0x092E42, //2051-2060

     0x3C9735,0x0C9649,0x7D4ABD,0x0D4A51,0x0DA545,
     0x55AABA,0x056A4E,0x0A6D43,0x452EB7,0x052D4B, //2061-2070

     0x8A95BF,0x0A9553,0x0B4A47,0x6B553B,0x0AD54F,
     0x055A45,0x4A5D38,0x0A5B4C,0x052B42,0x3A93B6, //2071-2080

     0x069349,0x7729BD,0x06AA51,0x0AD546,0x54DABA,
     0x04B64E,0x0A5743,0x452738,0x0D264A,0x8E933E, //2081-2090

     0x0D5252,0x0DAA47,0x66B53B,0x056D4F,0x04AE45,
     0x4A4EB9,0x0A4D4C,0x0D1541,0x2D92B5 //2091-2099

};

        //private static int[] LunarData = { 2635, 333387, 1701, 1748, 267701, 694, 2391, 133423, 1175, 396438, 3402, 3749, 331177, 1453, 694, 201326, 2350, 465197, 3221, 3402, 400202, 2901, 1386, 267611, 605, 2349, 137515, 2709, 464533, 1738, 2901, 330421, 1242, 2651, 199255, 1323, 529706, 3733, 1706, 398762, 2741, 1206, 267438, 2647, 1318, 204070, 3477, 461653, 1386, 2413, 330077, 1197, 2637, 268877, 3365, 531109, 2900, 2922, 398042, 2395, 1179, 267415, 2635, 661067, 1701, 1748, 398772, 2742, 2391, 330031, 1175, 1611, 200010, 3749, 527717, 1452, 2742, 332397, 2350, 3222, 268949, 3402, 3493, 133973, 1386, 464219, 605, 2349, 334123, 2709, 2890, 267946, 2773, 592565, 1210, 2651, 395863, 1323, 2707, 265877 };
        /// <summary>  
        /// 获取对应日期的农历 
        /// 
        /// </summary>  
        /// <param name="dtDay">公历日期</param> 
        ///
        ///<returns></returns>  
        ///

        public string GetSolarHoliday(int month, int day)//阳历节日类
        {
            if (month == 1 && day == 1) return "元旦";
            else if (month == 2 && day == 14) return "情人节";
            else if (month == 3 && day == 8) return "妇女节";
            else if (month == 3 && day == 12) return "植树节";
            else if (month == 4 && day == 1) return "愚人节";
            else if (month == 4 && day == 5) return "清明节";
            else if (month == 5 && day == 1) return "劳动节";
            else if (month == 5 && day == 4) return "青年节";
            else if (month == 6 && day == 1) return "儿童节";
            else if (month == 7 && day == 1) return "建党节";
            else if (month == 8 && day == 1) return "建军节";
            else if (month == 9 && day == 10) return "教师节";
            else if (month == 10 && day == 1) return "国庆节";
            else if (month == 12 && day == 25) return "圣诞节";
            else return "";
        }

        public string GetLunarHoliday(int month,int day)//阴历节日类
        {
            if (month == 1 && day == 1) return "春节";
            else if (month == 1 && day == 15) return "元宵节";           
            else if (month == 5 && day == 5) return "端午节";
            else if (month == 7 && day == 7) return "七夕节";
            else if (month == 8 && day == 15) return "中秋节";
            else if (month == 9 && day == 9) return "重阳节";
            else if (month == 12 && day == 30) return "除夕";
            else return "";
        }


        public string GetLunarCalendar(int year, int month, int day)//计算阳历对应的阴历日期并输出
        {
            int Smonth = month;
            int Sday = day;
            string calendar = string.Empty;
            int leap = 0;
            int LunarCalendarDay=0;
            int Spring_NY, Sun_NY, StaticDayCount;
            int index, flag;
            //Spring_NY 记录春节离当年元旦的天数。
            //Sun_NY 记录阳历日离当年元旦的天数。
            if (((LunarData[year - 1901] & 0x0060) >> 5) == 1)
                Spring_NY = (LunarData[year - 1901] & 0x001F) - 1;
            else
                Spring_NY = (LunarData[year - 1901] & 0x001F) - 1 + 31;
            Sun_NY = MonthAdd[month - 1] + day - 1;
            if ((year%4==0) && (month > 2))
                Sun_NY++;
            //StaticDayCount记录大小月的天数 29 或30
            //index 记录从哪个月开始来计算。
            //flag 是用来对闰月的特殊处理。
            //判断阳历日在春节前还是春节后
            if (Sun_NY >= Spring_NY)//阳历日在春节后（含春节那天）
            {
                Sun_NY -= Spring_NY;
                month = 1;
                index = 1;
                flag = 0;
                if ((LunarData[year - 1901] & (0x80000 >> (index - 1))) == 0)
                    StaticDayCount = 29;
                else
                    StaticDayCount = 30;
                while (Sun_NY >= StaticDayCount)
                {
                    Sun_NY -= StaticDayCount;
                    index++;
                    if (month == ((LunarData[year - 1901] & 0xF00000) >> 20))
                    {
                        flag = ~flag;
                        if (flag == 0)
                            month++;
                    }
                    else
                        month++;
                    if ((LunarData[year - 1901] & (0x80000 >> (index - 1))) == 0)
                        StaticDayCount = 29;
                    else
                        StaticDayCount = 30;
                }
                day = Sun_NY + 1;
            }
            else //阳历日在春节前
            {
                Spring_NY -= Sun_NY;
                year--;
                month = 12;
                if (((LunarData[year - 1901] & 0xF00000) >> 20) == 0)
                    index = 12;
                else
                    index = 13;
                flag = 0;
                if ((LunarData[year - 1901] & (0x80000 >> (index - 1))) == 0)
                    StaticDayCount = 29;
                else
                    StaticDayCount = 30;
                while (Spring_NY > StaticDayCount)
                {
                    Spring_NY -= StaticDayCount;
                    index--;
                    if (flag == 0)
                        month--;
                    if (month == ((LunarData[year - 1901] & 0xF00000) >> 20))
                        flag = ~flag;
                    if ((LunarData[year - 1901] & (0x80000 >> (index - 1))) == 0)
                        StaticDayCount = 29;
                    else
                        StaticDayCount = 30;
                }
                day = StaticDayCount - Spring_NY + 1;
            }
            LunarCalendarDay |= day;
            LunarCalendarDay |= (month << 6);
            int Nmonth = (LunarCalendarDay & 0x3c0) >> 6;
            int Nday = LunarCalendarDay & 0x3f;
            if (month == ((LunarData[year - 1901] & 0xF00000) >> 20)) leap = 1;
            //将阴历节日输出
            calendar += GetLunarHoliday(Nmonth, Nday);//阴历节日
            if (calendar == "")
            {
                //将阳历节日输出
                calendar += GetSolarHoliday(Smonth, Sday);//阳历节日

                if (calendar == "")
                {
                    if (leap == 1) calendar += "闰" + MonthName[Nmonth].ToString() + "月";
                    else calendar += MonthName[Nmonth].ToString() + "月";
                    //农历日//  
                    calendar += DayName[Nday].ToString() + "日";
                }
            }
            return calendar;

        }

    }

    /*public string GetLunarCalendar(int year, int month, int day)//此类方法无法进行正常的闰年月份天数的判断
    {
        int BeginYear = 1901;
        int NumberYear = 199;
        string calendar = string.Empty;
        int Nyear = year;
        int Nmonth;
        int Nday;
        bool leap = false;

        //越界检查，如果越界，返回无效日期
        if (year <= BeginYear || (year > BeginYear + NumberYear - 1))
        {
            calendar += "";
            return calendar;
        }
        int YearIndex = year - BeginYear;

        //计算春节的公历日期
        int SpringMonth = (LunarData[YearIndex] & 0x60) >> 5;
        int SpringDay = (LunarData[YearIndex] & 0x1f);

        //计算今天是公历年的第几天
        int TodaySolarDay = DayofSolarYear(year, month, day);

        //计算春节是公历年的第几天
        int SpringSolarDay = DayofSolarYear(year, SpringMonth, SpringDay);

        //计算今天是农历年的第几天
        int TodayLunarDay = TodaySolarDay - SpringSolarDay + 1;

        //如果今天在春节的前面，重新计算TodayLunarDay
        if (TodayLunarDay < 0)
        {
            //农历年比当前公历年小1
            YearIndex--;
            Nyear--;

            //越界，返回无效日期
            if (YearIndex < 0)
            {
                calendar += "";
                return calendar;
            }
            SpringMonth = (LunarData[YearIndex] & 0x60) >> 5;
            SpringDay = (LunarData[YearIndex] & 0x1f);
            SpringSolarDay = DayofSolarYear(year, SpringMonth, SpringDay);
            int YearTotalDay = DayofSolarYear(Nyear, 12, 31);
            TodayLunarDay = TodaySolarDay + YearTotalDay - SpringSolarDay + 1;
        }

        //计算月份和日期
        int LunarMonth = 1;
        for(; LunarMonth <= 13; LunarMonth++)
        {
            int MonthDay = 29;
            if (((LunarData[YearIndex]>>(6+LunarMonth))&0x1)>0) MonthDay = 30;
            if (TodayLunarDay <= MonthDay) break;
            else TodayLunarDay -= MonthDay;
        }
        Nday = TodayLunarDay;

        //处理闰月
        int LeapMonth = (LunarData[YearIndex] >> 20) & 0xf;
        if (LeapMonth > 0 && LeapMonth < LunarMonth)
        {
            LunarMonth--;

            //如果当前月为闰月，设置闰月标志
            if (LunarMonth == LeapMonth) leap = true;
        }
        Nmonth = LunarMonth;

        //将阴历节日输出
        calendar += GetLunarHoliday(Nmonth, Nday);//阴历节日
        if (calendar == "")
        {
            //将阳历节日输出
            calendar += GetSolarHoliday(month, day);//阳历节日

            if (calendar == "")
            {
                if (leap == true)
                    //
                    calendar += "闰" + MonthName[Nmonth].ToString() + "月";
                else
                    calendar += MonthName[Nmonth].ToString() + "月";
                //农历日//  
                calendar += DayName[Nday].ToString() + "日";
            }              
        }
        return calendar;         
    }*/

    /*public string GetLunarCalendar(int year, int month, int day)//此类方法只能计算1921-2020年的月份显示
    {
        string calendar = string.Empty;
        int nTheDate;
        int nIsEnd;
        int k, m, n, nBit, i;

        calendar += GetSolarHoliday(month, day);//阳历节日
        if (calendar == "")
        {
            //计算到初始时间1921年2月8日的天数：1921-2-8(正月初一)   
            nTheDate = (year - 1921) * 365 + (year - 1921) / 4 + day + MonthAdd[month - 1] - 38;
            if ((year % 4 == 0) && (month > 2)) nTheDate += 1;
            //计算天干，地支，月，日
            nIsEnd = 0;
            m = 0;
            k = 0;
            n = 0;
            while (nIsEnd != 1)
            {
                if (LunarData[m] < 4095) k = 11;
                else k = 12;
                n = k;
                while (n >= 0)
                {     //获取LunarData[m]的第n个二进制位的值 
                    nBit = LunarData[m];
                    for (i = 1; i < n + 1; i++) nBit = nBit / 2;
                    nBit = nBit % 2;
                    if (nTheDate <= (29 + nBit))
                    {
                        nIsEnd = 1;
                        break;
                    }
                    nTheDate = nTheDate - 29 - nBit;
                    n = n - 1;
                }
                if (nIsEnd == 1) break;
                m = m + 1;
            }
            year = 1921 + m;
            month = k - n + 1;
            day = nTheDate;

            #region 格式化日期显示为三月廿四
            if (k == 12)
            {
                if (month == LunarData[m] / 65536 + 1)
                    month = 1 - month;
                else if (month > LunarData[m] / 65536 + 1)
                    month = month - 1;
            }
            //生肖//
            //           calendar = ShengXiao[(year - 4) % 60 % 12].ToString() + "年 ";
            //天干//  
            //            calendar += TianGan[(year - 4) % 60 % 10].ToString();
            //地支//  
            //            calendar += DiZhi[(year - 4) % 60 % 12].ToString() + " ";
            //农历月//

            calendar += GetLunarHoliday(month, day);
            if (calendar == "")
            {
                if (month < 1)
                    //
                    calendar += "闰" + MonthName[-1 * month].ToString() + "月";
                else
                    calendar += MonthName[month].ToString() + "月";
                //农历日//  
                calendar += DayName[day].ToString() + "日";
                return calendar;
                #endregion
            }
            else return calendar;
        }
        else return calendar;
    }*/
}

    

