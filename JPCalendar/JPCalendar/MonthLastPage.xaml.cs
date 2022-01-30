using JPCalendar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace JPCalendar
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MonthLastPage : Page
    {
        class Item
        {
            public string Yangli { get; set; }
            public string Nongli { get; set; }
        }
        public MonthLastPage()
        {
            this.InitializeComponent();
            List<Item> Items = new List<Item>();
            Lunar lunar = new Lunar();
            Calendar calendar = new Calendar();
            App.Month--;
            if (App.Month == 0)
            {
                App.Year--;
                App.Month = 12;
            }
            Year.Text = App.Year + "年 " + App.Month + "月";
            int x = calendar.WhatDay(App.Year, App.Month);//得出某年某月的第一天是星期几
            int y = calendar.EveryMonthDays(App.Year, App.Month);//得出某年某月的天数
            int index = x;
            int monthIndex2 = 1;

            for (int i = 0; i < 42; i++)
            {
                if (i < index && index != 7) Items.Add(new Item { });
                else if (monthIndex2 <= y)
                {
                    Items.Add(new Item { Yangli = monthIndex2.ToString(), Nongli = lunar.GetLunarCalendar(App.Year, App.Month, monthIndex2) });
                    monthIndex2++;
                }
                else if (i < 42 && i % 7 != 0) Items.Add(new Item { });
                else if (i % 7 == 0) i += 7;
            }
            gridView.ItemsSource = Items;
        }
    }
}
