// --------------------------------------------------------------------------------------------------------------------
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
    using System.Collections.Generic;

    using CocosSharp;

    using FruityFalls.Forms.Common;
    using FruityFalls.Forms.Entities;
    using FruityFalls.Forms.Utils;

    public class GameScene : CCScene
    {
        private CCLayer backgroundLayer;
        private CCLayer gameplayLayer;
        private CCLayer foreGroundLayer;

        private IncreasingFruitSpawner spawner;

        private List<Fruit> fruitList = new List<Fruit>();

        public GameScene(CCGameView gameView) : base(gameView)
        {
            SetUpLayers();

            CreateBackground();
            
            CreateForeground();
            
            CreateFruitSpawner();

            CreatePaddle();
            
            Schedule(GameLoop);
        }
        
        private void SetUpLayers()
        {
            backgroundLayer = new CCLayer();
            gameplayLayer = new CCLayer();
            foreGroundLayer = new CCLayer();
            
            this.AddLayer(backgroundLayer);
            this.AddLayer(gameplayLayer);
            this.AddLayer(foreGroundLayer);
        }

        private void CreateBackground()
        {
            var background = new CCSprite(Images.BACKGROUND);
            background.AnchorPoint = new CCPoint(0, 0);
            background.IsAntialiased = false;

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


            foreGroundLayer.AddChild(foreground);
        }

        private void CreateFruitSpawner()
        {
            spawner = new IncreasingFruitSpawner(Coefficients.StartingFruitPerSecond, () => FruitFactory.CreateGameFruit(gameplayLayer));
            spawner.FruitSpawned += OnFruitSpawned;
        }

        private void OnFruitSpawned(object sender, Fruit fruit)
        {
            this.fruitList.Add(fruit);
            this.gameplayLayer.AddChild(fruit);
        }

        private void CreatePaddle()
        {
            
        }

        private void GameLoop(float frameTimeInSeconds)
        {
            foreach (Fruit fruit in fruitList)
            {
                fruit.Activity(frameTimeInSeconds);
            }

            spawner.Activity(frameTimeInSeconds);
        }
    }
}