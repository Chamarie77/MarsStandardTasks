﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarsFramework.Config {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MarsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MarsResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarsFramework.Config.MarsResource", typeof(MarsResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://localhost:5000/.
        /// </summary>
        internal static string ApplicationUrl {
            get {
                return ResourceManager.GetString("ApplicationUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 2.
        /// </summary>
        internal static string Browser {
            get {
                return ResourceManager.GetString("Browser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \MarsFramework\ExcelData\TestData.xlsx.
        /// </summary>
        internal static string ExcelPath {
            get {
                return ResourceManager.GetString("ExcelPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \MarsFramework\ExcelData\DeleteTestData.xlsx.
        /// </summary>
        internal static string ExcelPathDelete {
            get {
                return ResourceManager.GetString("ExcelPathDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \MarsFramework\ExcelData\EditTestData.xlsx.
        /// </summary>
        internal static string ExcelPathEdit {
            get {
                return ResourceManager.GetString("ExcelPathEdit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \MarsFramework\ExcelData\ProfilePageData.xlsx.
        /// </summary>
        internal static string ExcelPathProfilePage {
            get {
                return ResourceManager.GetString("ExcelPathProfilePage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image\Sunflower.JPG.
        /// </summary>
        internal static string ImagePath {
            get {
                return ResourceManager.GetString("ImagePath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to true.
        /// </summary>
        internal static string IsLogin {
            get {
                return ResourceManager.GetString("IsLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \TestReports\MarsReports.html.
        /// </summary>
        internal static string ReportPath {
            get {
                return ResourceManager.GetString("ReportPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \Config\XMLFile.xml.
        /// </summary>
        internal static string ReportXMLPath {
            get {
                return ResourceManager.GetString("ReportXMLPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \TestReports\ScreenShots.
        /// </summary>
        internal static string ScreenShotPath {
            get {
                return ResourceManager.GetString("ScreenShotPath", resourceCulture);
            }
        }
    }
}
