﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAS.UA.Server.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CAS.UA.Server.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap about_CommServer {
            get {
                object obj = ResourceManager.GetObject("about_CommServer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://www.commsvr.com/OPC-Help/Index.aspx?topic=html/ec4ecefe-2d13-4ed9-af36-72152ff597f3.htm.
        /// </summary>
        internal static string Help_Main {
            get {
                return ResourceManager.GetString("Help_Main", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://www.commsvr.com/.
        /// </summary>
        internal static string Home {
            get {
                return ResourceManager.GetString("Home", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://www.commsvr.com/rss/commservernews_en.rss.
        /// </summary>
        internal static string RSS {
            get {
                return ResourceManager.GetString("RSS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to commserver@commserver.eu.
        /// </summary>
        internal static string Support_emailAddress {
            get {
                return ResourceManager.GetString("Support_emailAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi, 
        ///I am interested in the following feature or  the following elements should be changed:.
        /// </summary>
        internal static string Support_MessageBody {
            get {
                return ResourceManager.GetString("Support_MessageBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPC Viewer.
        /// </summary>
        internal static string Support_MessageCaption {
            get {
                return ResourceManager.GetString("Support_MessageCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPC Viewer questions.
        /// </summary>
        internal static string Support_messageSubject {
            get {
                return ResourceManager.GetString("Support_messageSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Click OK to send email or Cancel otherwise..
        /// </summary>
        internal static string Support_MessageToBeShown {
            get {
                return ResourceManager.GetString("Support_MessageToBeShown", resourceCulture);
            }
        }
    }
}
