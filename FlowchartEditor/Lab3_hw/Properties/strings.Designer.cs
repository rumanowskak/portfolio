﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab3_hw.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Lab3_hw.Properties.strings", typeof(strings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blok decyzyjny.
        /// </summary>
        public static string DecisionBlockText {
            get {
                return ResourceManager.GetString("DecisionBlockText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wczytywanie.
        /// </summary>
        public static string FileLoadedCaption {
            get {
                return ResourceManager.GetString("FileLoadedCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pomyślnie wczytano plik..
        /// </summary>
        public static string FileLoadedMessage {
            get {
                return ResourceManager.GetString("FileLoadedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Błąd.
        /// </summary>
        public static string FileLoadingErrorCaption {
            get {
                return ResourceManager.GetString("FileLoadingErrorCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Błąd podczas wczytywania pliku..
        /// </summary>
        public static string FileLoadingErrorMessage {
            get {
                return ResourceManager.GetString("FileLoadingErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zapisywanie.
        /// </summary>
        public static string FileSavedCaption {
            get {
                return ResourceManager.GetString("FileSavedCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pomyślnie zapisano plik..
        /// </summary>
        public static string FileSavedMessage {
            get {
                return ResourceManager.GetString("FileSavedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blok operacyjny.
        /// </summary>
        public static string OperationBlockText {
            get {
                return ResourceManager.GetString("OperationBlockText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ostrzeżenie.
        /// </summary>
        public static string StartBlockPresentCaption {
            get {
                return ResourceManager.GetString("StartBlockPresentCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blok startowy już istnieje.
        /// </summary>
        public static string StartBlockPresentMessage {
            get {
                return ResourceManager.GetString("StartBlockPresentMessage", resourceCulture);
            }
        }
    }
}
