﻿#pragma checksum "C:\Users\86139\source\repos\JPCalendar\JPCalendar\Unforgetable\Page28.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "314AD71E913F13C47505216610B99A18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JPCalendar.Unforgetable
{
    partial class Page28 : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Unforgetable\Page28.xaml line 59
                {
                    this.ContentPanel = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Unforgetable\Page28.xaml line 60
                {
                    this.list = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 5: // Unforgetable\Page28.xaml line 54
                {
                    this.Add = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Add).Click += this.AddButton_Click;
                }
                break;
            case 6: // Unforgetable\Page28.xaml line 55
                {
                    this.Delete = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Delete).Click += this.DeleteButton_Click;
                }
                break;
            case 7: // Unforgetable\Page28.xaml line 40
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Unforgetable\Page28.xaml line 43
                {
                    this.Event = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Unforgetable\Page28.xaml line 23
                {
                    this.TitlePanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

