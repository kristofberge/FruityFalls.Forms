// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="ArcTouch, Inc.">
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
//   Defines the MainPage.xaml type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocosSharp;
using FruityFalls.Forms.Common;
using FruityFalls.Forms.Scenes;
using Xamarin.Forms;

namespace FruityFalls.Forms.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage ()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            CocosSharpView background = CreateBackground();
            Button startButton = CreateStartButton();

            outerLayout.Children.Add(background);
            outerLayout.Children.Add(startButton);
        }

        private CocosSharpView CreateBackground()
        {
            var background = new CocosSharpView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            background.ViewCreated = OnViewCreated;

            AbsoluteLayout.SetLayoutBounds(background, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(background, AbsoluteLayoutFlags.All);

            return background;
        }

        private Button CreateStartButton()
        {
            Color bgColor = Color.FromRgba(255, 255, 255, 0.5);
            var button = new Button
            {
                Text = "START",
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                BackgroundColor = bgColor,
                BorderColor = Color.Aqua,
                Command = new Command(() => Application.Current.MainPage = new GamePage())
            };

            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0.5, 0.5, 0.5, 50));
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            return button;
        }

        private void OnViewCreated(object sender, EventArgs e)
        {
            GameController.InitializeTitle(sender as CCGameView);
        }
    }
}