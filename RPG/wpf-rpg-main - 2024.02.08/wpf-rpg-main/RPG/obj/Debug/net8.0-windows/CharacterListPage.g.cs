﻿#pragma checksum "..\..\..\CharacterListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "113C169B25D106D2B1C1CEAE9F940A450915EC12"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace RPG {
    
    
    /// <summary>
    /// CharacterListPage
    /// </summary>
    public partial class CharacterListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 158 "..\..\..\CharacterListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel characterButtonPanel;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\CharacterListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CharacterGrid;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\CharacterListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCharacterButton;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\CharacterListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\CharacterListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BackLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RPG;component/characterlistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CharacterListPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.characterButtonPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.CharacterGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.AddCharacterButton = ((System.Windows.Controls.Button)(target));
            
            #line 179 "..\..\..\CharacterListPage.xaml"
            this.AddCharacterButton.Click += new System.Windows.RoutedEventHandler(this.AddCharacter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 187 "..\..\..\CharacterListPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            
            #line 187 "..\..\..\CharacterListPage.xaml"
            this.BackButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.BackButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 187 "..\..\..\CharacterListPage.xaml"
            this.BackButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.BackButton_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BackLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

