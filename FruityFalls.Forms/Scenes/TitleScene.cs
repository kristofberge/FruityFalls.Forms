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
using System;
using System.Collections.Generic;
using CocosSharp;
using FruityFalls.Forms.Common;
using FruityFalls.Forms.Entities;

namespace FruityFalls.Forms.Scenes
{
    public class TitleScene : CCScene
    {
        private CCLayer backgroundLayer;
        private CCLayer fruitLayer;

        private List<Fruit> fruitList;

        public TitleScene(CCGameView titleView) : base(titleView)
        {
            CreateBackground();

            fruitLayer = new CCLayer();

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

        private void CreatePaddle()
        {

        }

        private void CreateFruit()
        {
            fruitList = new List<Fruit>();
            var fruit = new Fruit();

            fruit.PositionX = CCRandom.GetRandomFloat(0 + (fruit.Radius * 1.5f), fruitLayer.ContentSize.Width - (fruit.Radius * 1.5f));
            fruit.PositionY = fruitLayer.ContentSize.Height + fruit.Radius;

            fruitList.Add(fruit);
            fruitLayer.AddChild(fruit);
        }

        private void AddLayersToScene()
        {
            this.AddLayer(backgroundLayer);
            this.AddLayer(fruitLayer);
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