﻿#pragma checksum "..\..\AddEditEmploye.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E2D75557EE3D5C57C4E6A4CC69254A6F62196641882304373B0CF0EA7A9ACE17"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AdminApp_YchetSotrudnikov;
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


namespace AdminApp_YchetSotrudnikov {
    
    
    /// <summary>
    /// AddEditEmploye
    /// </summary>
    public partial class AddEditEmploye : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Name;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_LastName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_MiddleName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DP_DateOfEmployment;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Login;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Password;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\AddEditEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Soli;
        
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
            System.Uri resourceLocater = new System.Uri("/AdminApp_YchetSotrudnikov;component/addeditemploye.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddEditEmploye.xaml"
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
            
            #line 36 "..\..\AddEditEmploye.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TB_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TB_LastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TB_MiddleName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DP_DateOfEmployment = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.TB_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TB_Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TB_PhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TB_Soli = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
