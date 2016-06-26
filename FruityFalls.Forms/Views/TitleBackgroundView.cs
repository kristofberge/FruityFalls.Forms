// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FruitGameView.cs" company="ArcTouch, Inc.">
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
//   Defines the FruitGameView type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Views
{
    using System;

    using CocosSharp;
    using FruityFalls.Forms;
    using FruityFalls.Forms.Common.Enums;
    using FruityFalls.Forms.Scenes;

    using Xamarin.Forms;

    public class TitleBackgroundView : CocosSharpView
    {
        public static readonly BindableProperty FruitTypeProperty =
            BindableProperty.Create(nameof(FruitType), typeof(FruitType), typeof(TitleBackgroundView), FruitType.Random, propertyChanged: (bindable, oldValue, newValue) => 
        {
            var scene = (bindable as TitleBackgroundView)?.titleScene;
            if (scene != null)
            {
                scene.FruitType = (FruitType)newValue;
            }
        });

        private TitleScene titleScene;

        public TitleBackgroundView()
        {
            base.ViewCreated += OnViewCreated;
        }
        
        public FruitType FruitType
        {
            get { return (FruitType)GetValue(FruitTypeProperty); }
            set { SetValue(FruitTypeProperty, value); }
        }
        
        public new EventHandler<EventArgs> ViewCreated { get; private set; }

        protected void OnViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;
            titleScene = GameController.Initialize<TitleScene>(gameView, gv => new TitleScene(gv) { FruitType = FruitType });
        }
    }
}