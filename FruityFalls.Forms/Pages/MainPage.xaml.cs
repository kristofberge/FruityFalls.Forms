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

namespace FruityFalls.Forms.Pages
{
    using System;
    using FruityFalls.Forms.Common.Enums;
    using FruityFalls.Forms.PageModels;

    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPageModel pageModel { get { return BindingContext as MainPageModel; } }

        public MainPage ()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            this.BindingContext = new MainPageModel();

            Button startButton = CreateStartButton();

            StackLayout buttonsLayout = CreateButtonsLayout();

            outerLayout.Children.Add(startButton);
            outerLayout.Children.Add(buttonsLayout);
        }

        private Button CreateStartButton()
        {
            Button button = CreateStandardButton("START");
            button.Command = new Command(() => Application.Current.MainPage = new GamePage());

            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0.5, 0.5, 0.5, 50));
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            return button;
        }

        private StackLayout CreateButtonsLayout()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            AbsoluteLayout.SetLayoutBounds(layout, new Rectangle(0, 1, 1, 70));
            AbsoluteLayout.SetLayoutFlags(layout, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            Button cherryButton = CreateStandardButton("Cherry");
            Button lemonButton = CreateStandardButton("Lemon");
            Button randomButton = CreateStandardButton("Random");

            cherryButton.SetBinding(Button.CommandProperty, "SetFruitTypeCommand");
            cherryButton.SetValue(Button.CommandParameterProperty, FruitType.Cherry);

            lemonButton.SetBinding(Button.CommandProperty, "SetFruitTypeCommand");
            lemonButton.SetValue(Button.CommandParameterProperty, FruitType.Lemon);

            randomButton.SetBinding(Button.CommandProperty, "SetFruitTypeCommand");
            randomButton.SetValue(Button.CommandParameterProperty, FruitType.Random);

            layout.Children.Add(cherryButton);
            layout.Children.Add(lemonButton);
            layout.Children.Add(randomButton);

            return layout;
        }

        static Button CreateStandardButton(string text)
        {
            Color bgColor = Color.FromRgba(255, 255, 255, 0.5);
            return new Button
            {
                Text = text,
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                BackgroundColor = bgColor,
                BorderColor = Color.Aqua
            };
        }
    }
}