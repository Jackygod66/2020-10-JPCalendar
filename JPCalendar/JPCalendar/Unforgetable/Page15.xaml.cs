using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace JPCalendar.Unforgetable
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Page15 : Page
    {
        public class UnforgetModel
        {
            public string times { get; set; }
            public string events { get; set; }
        }
        ObservableCollection<UnforgetModel> UnforgetModels = new ObservableCollection<UnforgetModel>();
        public Page15()
        {
            this.InitializeComponent();
            list.ItemsSource = UnforgetModels;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            UnforgetModels.Add(new UnforgetModel { times = Time.Text, events = ":" + Event.Text });
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                UnforgetModel unforgetModel = list.SelectedItem as UnforgetModel;
                if (UnforgetModels.Contains(unforgetModel))
                {
                    UnforgetModels.Remove(unforgetModel);
                }
            }
        }
    }

}