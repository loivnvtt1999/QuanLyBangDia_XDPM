﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NGON-LUA-REC202\\SQLEXPRESS;Initial Catalog=DB_BangDia;User ID=sa;Pass" +
            "word=sapassword;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False")]
        public string DB_BangDiaConnectionString1 {
            get {
                return ((string)(this["DB_BangDiaConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NGON-LUA-REC202\\SQLEXPRESS;Initial Catalog=DB_BangDia;Integrated Secu" +
            "rity=True")]
        public string DB_BangDiaConnectionString {
            get {
                return ((string)(this["DB_BangDiaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-PULK309\\DUONG;Initial Catalog=DB_BangDia;Integrated Security=" +
            "True")]
        public string DB_BangDiaConnectionString2 {
            get {
                return ((string)(this["DB_BangDiaConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=MSI\\SQLEXPRESS;Initial Catalog=DB_BangDia;Integrated Security=True;Co" +
            "nnect Timeout=30;Encrypt=False;TrustServerCertificate=False")]
        public string DB_BangDiaConnectionString3 {
            get {
                return ((string)(this["DB_BangDiaConnectionString3"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-D922LRS\\SQLEXPRESS;Initial Catalog=DB_BangDia;Integrated Secu" +
            "rity=True")]
        public string DB_BangDiaConnectionString4 {
            get {
                return ((string)(this["DB_BangDiaConnectionString4"]));
            }
        }
    }
}
