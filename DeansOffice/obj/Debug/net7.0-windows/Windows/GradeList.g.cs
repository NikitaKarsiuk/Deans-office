﻿#pragma checksum "..\..\..\..\Windows\GradeList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "867AF40D13930A5AF3E2FA98B33BEC29A0E25B4B"
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
    /// GradeList
    /// </summary>
    public partial class GradeList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Windows\GradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gradeListDataGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\GradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GradeAddButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\GradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GradeChangeButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\GradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GradeDeleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DeansOffice;component/windows/gradelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\GradeList.xaml"
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
            this.gradeListDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.GradeAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\GradeList.xaml"
            this.GradeAddButton.Click += new System.Windows.RoutedEventHandler(this.GradeAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GradeChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\GradeList.xaml"
            this.GradeChangeButton.Click += new System.Windows.RoutedEventHandler(this.GradeChangeButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GradeDeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Windows\GradeList.xaml"
            this.GradeDeleteButton.Click += new System.Windows.RoutedEventHandler(this.GradeDeleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
