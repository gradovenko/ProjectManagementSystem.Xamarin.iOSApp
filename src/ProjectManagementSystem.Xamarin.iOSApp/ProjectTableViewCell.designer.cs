﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ProjectManagementSystem.Xamarin.iOSApp
{
    [Register ("ProjectTableViewCell")]
    partial class ProjectTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProjectNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProjectNameLabel != null) {
                ProjectNameLabel.Dispose ();
                ProjectNameLabel = null;
            }
        }
    }
}