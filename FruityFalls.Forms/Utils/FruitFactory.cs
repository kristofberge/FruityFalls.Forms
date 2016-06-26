// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FruitFactory.cs" company="ArcTouch, Inc.">
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
//   Defines the FruitFactory type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using CocosSharp;
using FruityFalls.Forms.Common;
using FruityFalls.Forms.Common.Enums;
using FruityFalls.Forms.Entities;
using FruityFalls.Forms.Physics;

namespace FruityFalls.Forms.Utils
{
    public static class FruitFactory
    {
        public static Fruit CreateTitleFruit(CCLayer layer, FruitType type = FruitType.Random)
        {
            return new Fruit(type, new ConstantSpeedPositionCalculator(Coefficients.Gravity))
            {
                PositionX = CCRandom.GetRandomFloat(0 + (Coefficients.FruitRadius * 1.5f), layer.ContentSize.Width - (Coefficients.FruitRadius * 1.5f)),
                PositionY = layer.ContentSize.Height + Coefficients.FruitRadius
            };
        }

        public static Fruit CreateGameFruit(CCLayer layer, FruitType type = FruitType.Random)
        {
            return new Fruit(type, new AcceleratingPositionCalculator(Coefficients.Gravity, Coefficients.Gravity / 2))
            {
                PositionX = CCRandom.GetRandomFloat(0 + (Coefficients.FruitRadius * 1.5f), layer.ContentSize.Width - (Coefficients.FruitRadius * 1.5f)),
                PositionY = layer.ContentSize.Height + Coefficients.FruitRadius
            };
        }
    }
}