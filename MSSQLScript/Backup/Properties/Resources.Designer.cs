﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5420
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSQLScript.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MSSQLScript.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to 
        ///SET ARITHABORT ON
        ///SET CONCAT_NULL_YIELDS_NULL ON
        ///SET QUOTED_IDENTIFIER ON
        ///SET ANSI_NULLS ON
        ///SET ANSI_PADDING ON
        ///SET ANSI_WARNINGS ON
        ///SET NUMERIC_ROUNDABORT OFF
        ///
        ///declare @crlf char(2)
        ///SET @crlf=char(13)+char(10)
        ///
        ///;WITH ColumnDefs as
        ///(
        ///  select TableObj=c.[object_id]
        ///        ,ColSeq=c.column_id
        ///        ,ColumnDef=quotename(c.Name)+&apos; &apos;
        ///                  +case 
        ///                     when c.is_computed=1 then &apos;as &apos;+coalesce(k.[definition],&apos;&apos;)
        ///                         +case when k.is_persisted= [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string tables {
            get {
                return ResourceManager.GetString("tables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ;WITH TypeDef AS(
        ///  SELECT TypeName=QUOTENAME( SCHEMA_NAME(t.schema_id))+&apos;.&apos;+QUOTENAME(t.name)
        ///        ,ParentName=TYPE_NAME(t.system_type_id)+&apos;&apos;
        ///                 +case
        ///                    when DataType in (&apos;decimal&apos;,&apos;numeric&apos;) then &apos;(&apos;+cast(t.precision as varchar(10))+case when t.scale&lt;&gt;0 then &apos;,&apos;+cast(t.scale as varchar(10)) else &apos;&apos; end +&apos;)&apos;
        ///                    when DataType in (&apos;char&apos;,&apos;varchar&apos;,&apos;nchar&apos;,&apos;nvarchar&apos;,&apos;binary&apos;,&apos;varbinary&apos;) then &apos;(&apos;+case when t.max_length=-1 then &apos;max&apos; else case when Data [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string types {
            get {
                return ResourceManager.GetString("types", resourceCulture);
            }
        }
    }
}
