using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#region General Information
// General Information about an assembly is controlled through the following set of attributes.
// Change these attribute values to modify the information associated with an assembly.
[assembly: AssemblyCompany("Tonquish Creek Software")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCopyright("Copyright © 2017 Tonquish Creek Software. All Rights Reserved.")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDefaultAlias("TonquishCreek.Dapper.Repositories")]
[assembly: AssemblyDescription("Simple implementation of the Repository pattern using the Dapper data access library.")]
[assembly: AssemblyProduct("TonquishCreek.Dapper.Repositories")]
[assembly: AssemblyTitle("TonquishCreek.Dapper.Repositories")]
[assembly: AssemblyTrademark("")]
[assembly: CLSCompliant(false)]
#endregion

#region Compiler Services Information
[assembly: InternalsVisibleTo("TonquishCreek.Dapper.Repositories.Test, PublicKey=00240000048000009400000006020000002400005253413100040000010001001f73e5b52cf92ee68639ab8b570fa468a43a478a48d08e737ca366c7bf5aaf6d840b19035cc210f0b37555be9545a724d071a899becf436faf4030a9bdba6dc606627cef47e0b52d9826c5e84131b388b47db18fb3252c5216aebadc85bf609f61af8ea0ff6cf2317cbaf4106baaf73d436e1a6e017e13f560986391425e3ca2")]
#endregion

#region Enterprise Services Information
// Setting ApplicationActivation to Libary indicates that the assembly should run within the process that calls it, not within a separate process hosted by COM+.
// This is important since the assembly must be allowed to run within many different processes, including Windows Forms, ASP.NET, and COM+.
//[assembly: ApplicationActivation(ActivationOption.Library)]

// Setting ApplicationAccessControl to false indicates that COM+ shouldn’t apply its own method-level security when clients try to call objects within the assembly.
//[assembly: ApplicationAccessControl(false)]
#endregion

#region Interop Services Information
// Setting ComVisible to false makes the types in this assembly not visible to COM components.
// If you need to access a type in this assembly from COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
#endregion

#region Resource Information
[assembly: NeutralResourcesLanguage("en-US")]
#endregion

#region Security Information
//[assembly: PermissionSet(SecurityAction.RequestMinimum, Unrestricted = true)]
#endregion

#region Version Information
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Revision
//      Build Number
//
// When '*' is used, the Revision will be the number of days since December 31, 1999
// and the Build Number will be the number of seconds since 12AM divided by 2.
[assembly: AssemblyVersion("1.0.*")]
#endregion
