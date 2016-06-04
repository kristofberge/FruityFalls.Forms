// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FruityFalls.Forms.cs" company="ArcTouch, Inc.">
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the FruityFalls.Forms type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using FruityFalls.Forms.Pages;
using Xamarin.Forms;

namespace FruityFalls.Forms
{
    public class App : Application
    {
        public App ()
        {
            MainPage = new NavigationPage (new MainPage ());
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

