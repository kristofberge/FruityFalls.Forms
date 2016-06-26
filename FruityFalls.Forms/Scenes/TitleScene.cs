// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TitleScene.cs" company="ArcTouch, Inc.">
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
//   Defines the TitleScene type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Scenes
{
    using System.Collections.Generic;

    using CocosSharp;

    using FruityFalls.Forms.Common;
    using FruityFalls.Forms.Common.Enums;
    using FruityFalls.Forms.Entities;
    using FruityFalls.Forms.Utils;

    public class TitleScene : CCScene
    {
        private CCLayer backgroundLayer;
        private CCLayer fruitLayer;

        private List<Fruit> fruitList = new List<Fruit>();
        private FruitSpawner spawner;

        public TitleScene(CCGameView titleView) : base(titleView)
        {
            AddLayersToScene();

            CreateBackground();
            
            CreateFruitSpawner();

            Schedule(GameLoop);
        }

        public FruitType FruitType { get; set; } = FruitType.Random;

        private void AddLayersToScene()
        {
            backgroundLayer = new CCLayer();
            fruitLayer = new CCLayer();

            this.AddLayer(backgroundLayer);
            this.AddLayer(fruitLayer);
        }

        private void CreateBackground()
        {
            var background = new CCSprite(Images.BACKGROUND);
            background.AnchorPoint = new CCPoint(0, 0);
            background.IsAntialiased = false;

            backgroundLayer.AddChild(background);
        }

        private void CreateFruitSpawner()
        {
            float timeBetweenSpawns = 1 / Coefficients.FruitPerSecondTitleScreen;
            this.spawner = new FruitSpawner(timeBetweenSpawns, () => FruitFactory.CreateTitleFruit(fruitLayer, FruitType));
            spawner.FruitSpawned += OnFruitSpawned;
        }
        
        private void OnFruitSpawned(object sender, Fruit fruit)
        {
            this.fruitList.Add(fruit);
            this.fruitLayer.AddChild(fruit);
        }

        private void GameLoop(float frameTimeInSeconds)
        {
            foreach (Fruit fruit in fruitList)
            {
                fruit.Activity(frameTimeInSeconds);
            }

            fruitList.RemoveAll(IsUnderBottomOfScene);

            spawner.Activity(frameTimeInSeconds);
        }

        private bool IsUnderBottomOfScene(Fruit fruit)
        {
            return fruit.PositionY < -Coefficients.FruitRadius;
        }
   }
}