﻿#pragma checksum "..\..\..\..\Pages\MyContracts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DCAA55EF9F3E0FA66F621BB3AA069D8C8CE4DE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coursework.Pages;
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


namespace Coursework.Pages {
    
    
    /// <summary>
    /// MyContracts
    /// </summary>
    public partial class MyContracts : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Pages\MyContracts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ContractsList;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\MyContracts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MoneyForDebt;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\MyContracts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RepayDebt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Coursework;component/pages/mycontracts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MyContracts.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ContractsList = ((System.Windows.Controls.ListBox)(target));
            
            #line 26 "..\..\..\..\Pages\MyContracts.xaml"
            this.ContractsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ContractsList_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MoneyForDebt = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\..\Pages\MyContracts.xaml"
            this.MoneyForDebt.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.MoneyForDebt_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RepayDebt = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Pages\MyContracts.xaml"
            this.RepayDebt.Click += new System.Windows.RoutedEventHandler(this.RepayDebt_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

