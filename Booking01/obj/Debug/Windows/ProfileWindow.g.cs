﻿#pragma checksum "..\..\..\Windows\ProfileWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E2F7161D6A35B85ED6838019A73EB98F396A60CD33BC207CFD6B0D210E2E948"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Booking01.Windows;
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


namespace Booking01.Windows {
    
    
    /// <summary>
    /// ProfileWindow
    /// </summary>
    public partial class ProfileWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 127 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopGrid;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newAdButton;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid BottomGrid;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nameBlock;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock phoneBlock;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock emailBlock;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ownCountBlock;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock rentBlock;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ownButton;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Windows\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rentButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Booking01;component/windows/profilewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ProfileWindow.xaml"
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
            this.TopGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\Windows\ProfileWindow.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.newAdButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.BottomGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.nameBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.phoneBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.emailBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ownCountBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.rentBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.ownButton = ((System.Windows.Controls.Button)(target));
            
            #line 143 "..\..\..\Windows\ProfileWindow.xaml"
            this.ownButton.Click += new System.Windows.RoutedEventHandler(this.ownButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.rentButton = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\..\Windows\ProfileWindow.xaml"
            this.rentButton.Click += new System.Windows.RoutedEventHandler(this.rentButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

