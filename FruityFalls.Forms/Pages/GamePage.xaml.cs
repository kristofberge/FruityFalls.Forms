// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GamePage.xaml.cs" company="ArcTouch, Inc.">
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
//   Defines the GamePage.xaml type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Pages
{
    using System;
    using CocosSharp;
    using FruityFalls.Forms.Scenes;
    using Xamarin.Forms;

    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var ccSharpView = new CocosSharpView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            ccSharpView.ViewCreated = OnViewCreated;
            AbsoluteLayout.SetLayoutBounds(ccSharpView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(ccSharpView, AbsoluteLayoutFlags.All);

            outerLayout.Children.Add(ccSharpView);
        }

        private void OnViewCreated(object sender, EventArgs e)
        {
            GameController.InitializeGame(sender as CCGameView);
        }
    }
}