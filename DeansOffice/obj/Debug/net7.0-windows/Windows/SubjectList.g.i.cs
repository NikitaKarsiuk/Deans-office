﻿#pragma checksum "..\..\..\..\Windows\SubjectList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0919C748A91BB176F5300C5E90C2753E5F606010"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DeansOffice.Converters;
using DeansOffice.Windows;
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


namespace DeansOffice.Windows {
    
    
    /// <summary>
    /// SubjectList
    /// </summary>
    public partial class SubjectList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Windows\SubjectList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid subjectListDataGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\SubjectList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectAddButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\SubjectList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectChangeButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\SubjectList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectDeleteButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DeansOffice;component/windows/subjectlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\SubjectList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.subjectListDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.SubjectAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Windows\SubjectList.xaml"
            this.SubjectAddButton.Click += new System.Windows.RoutedEventHandler(this.SubjectAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SubjectChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\SubjectList.xaml"
            this.SubjectChangeButton.Click += new System.Windows.RoutedEventHandler(this.SubjectChangeButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SubjectDeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\SubjectList.xaml"
            this.SubjectDeleteButton.Click += new System.Windows.RoutedEventHandler(this.SubjectDeleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

