using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using JPCalendar.Models;
using System.Data;
using Windows.UI.ViewManagement;
using JPCalendar.Unforgetable;
using Windows.Graphics.Printing;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace JPCalendar
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        class Item
        {
            public string Yangli { get; set; }
            public string Nongli { get; set; }
            public string Today { get; set; }
        }
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Page1));
            _ = ApplicationView.PreferredLaunchWindowingMode;//设置应用全屏显示
            List<Item> Items = new List<Item>();
            Lunar lunar = new Lunar();
            Calendar calendar = new Calendar();
            int x = calendar.WhatDay(DateTime.Now.Year,DateTime.Now.Month);//得出某年某月的第一天是星期几
            int y = calendar.EveryMonthDays(DateTime.Now.Year, DateTime.Now.Month);//得出某年某月的天数
            App.Year = DateTime.Now.Year;
            App.Month = DateTime.Now.Month;
            int index = x;
            int monthIndex2 = 1;
            
            for(int i = 0; i < 42; i++)
            {
                if (i < index && index != 7) Items.Add(new Item { });
                else if (monthIndex2 <= y)
                {
                    if(monthIndex2!=DateTime.Now.Day) 
                        Items.Add(new Item { Yangli = monthIndex2.ToString(), Nongli = lunar.GetLunarCalendar(DateTime.Now.Year, DateTime.Now.Month, monthIndex2) });
                    else if(monthIndex2==DateTime.Now.Day) Items.Add(new Item { Yangli = monthIndex2.ToString(), Nongli = lunar.GetLunarCalendar(DateTime.Now.Year, DateTime.Now.Month, monthIndex2),Today = "今天" });
                    monthIndex2++;
                }
                else if (i < 42 && i % 7 != 0) Items.Add(new Item { });
                else if (i % 7 == 0) i += 7;
            }
            gridView.ItemsSource = Items;
            
            showtimer = new DispatcherTimer();        
            showtimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            showtimer.Tick += Showtimer_Tick;
            showtimer.Start();
        }
        private DispatcherTimer showtimer;
        private void Showtimer_Tick(object sender, object e)
        {
            Year.Text = DateTime.Now.ToString();
        }//实现动态时间显示 

        private void gridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Item;
            if (item != null)
            {
                if (item.Yangli == null) MyFrame.Navigate(typeof(NullPage));
                else
                {
                    if (Int16.Parse(item.Yangli) == 1) MyFrame.Navigate(typeof(Page1));
                    else if (Int16.Parse(item.Yangli) == 2) MyFrame.Navigate(typeof(Page2));
                    else if (Int16.Parse(item.Yangli) == 3) MyFrame.Navigate(typeof(Page3));
                    else if (Int16.Parse(item.Yangli) == 4) MyFrame.Navigate(typeof(Page4));
                    else if (Int16.Parse(item.Yangli) == 5) MyFrame.Navigate(typeof(Page5));
                    else if (Int16.Parse(item.Yangli) == 6) MyFrame.Navigate(typeof(Page6));
                    else if (Int16.Parse(item.Yangli) == 7) MyFrame.Navigate(typeof(Page7));
                    else if (Int16.Parse(item.Yangli) == 8) MyFrame.Navigate(typeof(Page8));
                    else if (Int16.Parse(item.Yangli) == 9) MyFrame.Navigate(typeof(Page9));
                    else if (Int16.Parse(item.Yangli) == 10) MyFrame.Navigate(typeof(Page10));
                    else if (Int16.Parse(item.Yangli) == 11) MyFrame.Navigate(typeof(Page11));
                    else if (Int16.Parse(item.Yangli) == 12) MyFrame.Navigate(typeof(Page12));
                    else if (Int16.Parse(item.Yangli) == 13) MyFrame.Navigate(typeof(Page13));
                    else if (Int16.Parse(item.Yangli) == 14) MyFrame.Navigate(typeof(Page14));
                    else if (Int16.Parse(item.Yangli) == 15) MyFrame.Navigate(typeof(Page15));
                    else if (Int16.Parse(item.Yangli) == 16) MyFrame.Navigate(typeof(Page16));
                    else if (Int16.Parse(item.Yangli) == 17) MyFrame.Navigate(typeof(Page17));
                    else if (Int16.Parse(item.Yangli) == 18) MyFrame.Navigate(typeof(Page18));
                    else if (Int16.Parse(item.Yangli) == 19) MyFrame.Navigate(typeof(Page19));
                    else if (Int16.Parse(item.Yangli) == 20) MyFrame.Navigate(typeof(Page20));
                    else if (Int16.Parse(item.Yangli) == 21) MyFrame.Navigate(typeof(Page21));
                    else if (Int16.Parse(item.Yangli) == 22) MyFrame.Navigate(typeof(Page22));
                    else if (Int16.Parse(item.Yangli) == 23) MyFrame.Navigate(typeof(Page23));
                    else if (Int16.Parse(item.Yangli) == 24) MyFrame.Navigate(typeof(Page24));
                    else if (Int16.Parse(item.Yangli) == 25) MyFrame.Navigate(typeof(Page25));
                    else if (Int16.Parse(item.Yangli) == 26) MyFrame.Navigate(typeof(Page26));
                    else if (Int16.Parse(item.Yangli) == 27) MyFrame.Navigate(typeof(Page27));
                    else if (Int16.Parse(item.Yangli) == 28) MyFrame.Navigate(typeof(Page28));
                    else if (Int16.Parse(item.Yangli) == 29) MyFrame.Navigate(typeof(Page29));
                    else if (Int16.Parse(item.Yangli) == 30) MyFrame.Navigate(typeof(Page30));
                    else if (Int16.Parse(item.Yangli) == 31) MyFrame.Navigate(typeof(Page31));
                }
                    
            }          
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            WholeFrame.Navigate(typeof(MainPage));
        }

        private void LastMonth_Click(object sender, RoutedEventArgs e)
        {
            MonthFrame.Navigate(typeof(MonthLastPage));
            MyFrame.Navigate(typeof(NullPage));
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        { 
            MonthFrame.Navigate(typeof(MonthNextPage));
            MyFrame.Navigate(typeof(NullPage));
        }
    }

}
