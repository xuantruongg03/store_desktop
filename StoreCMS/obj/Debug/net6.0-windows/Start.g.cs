﻿#pragma checksum "..\..\..\Start.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E926775A326C94C503C285B607C96743EFBAFC23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreCMS;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StoreCMS {
    
    
    /// <summary>
    /// Start
    /// </summary>
    public partial class Start : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_products;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_product;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_banner;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_banners;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search_product;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGV;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StoreCMS;component/start.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Start.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.view_products = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Start.xaml"
            this.view_products.Click += new System.Windows.RoutedEventHandler(this.View_Products);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Add_product = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Start.xaml"
            this.Add_product.Click += new System.Windows.RoutedEventHandler(this.Opend_Form_Add_Product);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Add_banner = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Start.xaml"
            this.Add_banner.Click += new System.Windows.RoutedEventHandler(this.Edit_Product);
            
            #line default
            #line hidden
            return;
            case 4:
            this.view_banners = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Start.xaml"
            this.view_banners.Click += new System.Windows.RoutedEventHandler(this.Delete_Product);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Search_product = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Start.xaml"
            this.Search_product.Click += new System.Windows.RoutedEventHandler(this.Find_Product);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DGV = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Start.xaml"
            this.DGV.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DGV_AutoGeneratedColumns);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

