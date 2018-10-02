﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57A4354B286AB28DD7FB677A1566C74C6F33633A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HRIS.Controller;
using HRIS.Teaching;
using HRIS.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace HRIS.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StaffNameFilter;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox StaffListShowBox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StaffDetailPanel;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PhotoGrid;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ActivityGrid;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UnitFilter;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox UnitListShowBox;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel UnitDetailPanel;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UnitPhotoGrid;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UnitTimeGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HRIS;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.StaffNameFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\View\MainWindow.xaml"
            this.StaffNameFilter.KeyUp += new System.Windows.Input.KeyEventHandler(this.StaffNameFilter_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 33 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Category_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StaffListShowBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 59 "..\..\..\View\MainWindow.xaml"
            this.StaffListShowBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StaffListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.StaffDetailPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.PhotoGrid = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.ActivityGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.UnitFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 163 "..\..\..\View\MainWindow.xaml"
            this.UnitFilter.KeyUp += new System.Windows.Input.KeyEventHandler(this.StaffNameFilter_KeyUp);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 165 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Category_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UnitListShowBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 172 "..\..\..\View\MainWindow.xaml"
            this.UnitListShowBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StaffListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.UnitDetailPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.UnitPhotoGrid = ((System.Windows.Controls.Image)(target));
            return;
            case 12:
            this.UnitTimeGrid = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

