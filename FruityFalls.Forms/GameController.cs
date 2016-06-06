// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameController.cs" company="ArcTouch, Inc.">
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
//   Defines the GameController type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms
{
    using System;
    using System.Collections.Generic;

    using CocosSharp;
    using FruityFalls.Forms.Common;
    using FruityFalls.Forms.Scenes;

    public static class GameController
    {
        public static void InitializeGame(CCGameView gameView)
        {
            Initialize(gameView);
            var gameScene = new  GameScene(gameView);
            gameView.RunWithScene(gameScene);
        }

        public static void InitializeTitle(CCGameView gameView)
        {
            Initialize(gameView);
            var titleScene = new TitleScene(gameView);
            gameView.RunWithScene(titleScene);
        }

        public static void Initialize(CCGameView gameView)
        {
            gameView.ContentManager.SearchPaths = new List<string> { "Images" };

            gameView.DesignResolution = new CCSizeI(Constants.DESIGN_WIDTH, Constants.DESIGN_HEIGHT);


        }

   }
}