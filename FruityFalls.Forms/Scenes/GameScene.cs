﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameScene.cs" company="ArcTouch, Inc.">
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
//   Defines the GameScene type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Scenes
{
    using System;
    using System.Collections.Generic;
    using CocosSharp;
    using FruityFalls.Forms.Common;
    using FruityFalls.Forms.Entities;

    public class GameScene : CCScene
    {
        private CCLayer backgroundLayer;
        private CCLayer gameplayLayer;
        private CCLayer foreGroundLayer;

        private List<Fruit> fruitList;

        public GameScene(CCGameView gameView) : base(gameView)
        {
            CreateBackground();

            CreateForeground();
            
            CreateGameplay();

            AddLayersToScene();

            CreatePaddle();

            CreateFruit();
            
            Schedule(GameLoop);
        }

        private void CreateBackground()
        {
            var background = new CCSprite(Images.BACKGROUND);
            background.AnchorPoint = new CCPoint(0, 0);
            background.IsAntialiased = false;

            backgroundLayer = new CCLayer();
            backgroundLayer.AddChild(background);
        }

        private void CreateForeground()
        {
            var foreground = new CCSprite(Images.FOREGROUND);
            foreground.AnchorPoint = new CCPoint(0, 0);
            foreground.IsAntialiased = false;

            #if DEBUG
            if (Coefficients.ShowCollisionAreas)
            {
                foreground.Opacity = 100;
            }
            #endif

            foreGroundLayer = new CCLayer();
            foreGroundLayer.AddChild(foreground);
        }

        private void CreateGameplay()
        {
            gameplayLayer = new CCLayer();
        }

        private void CreatePaddle()
        {
            
        }

        private void CreateFruit()
        {
            fruitList = new List<Fruit>();
            var fruit = new Fruit();

            fruit.PositionX = CCRandom.GetRandomFloat(0 + (fruit.Radius * 1.5f), gameplayLayer.ContentSize.Width - (fruit.Radius * 1.5f));
            fruit.PositionY = gameplayLayer.ContentSize.Height + fruit.Radius;

            fruitList.Add(fruit);
            gameplayLayer.AddChild(fruit);
        }

        private void AddLayersToScene()
        {
            this.AddLayer(backgroundLayer);
            this.AddLayer(gameplayLayer);
            this.AddLayer(foreGroundLayer);
        }

        private void GameLoop(float frameTimeInSeconds)
        {
            foreach (Fruit fruit in fruitList)
            {
                fruit.Activity(frameTimeInSeconds);
            }
        }
    }
}