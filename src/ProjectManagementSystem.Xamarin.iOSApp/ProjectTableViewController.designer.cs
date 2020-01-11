// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ProjectManagementSystem.Xamarin.iOSApp
{
    [Register ("ProjectListController")]
    partial class ProjectTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ProjectTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProjectTableView != null) {
                ProjectTableView.Dispose ();
                ProjectTableView = null;
            }
        }
    }
}