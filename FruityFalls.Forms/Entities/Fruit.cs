// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fruit.cs" company="ArcTouch, Inc.">
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
//   Defines the Fruit type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Entities
{
    using System;
    using CocosSharp;

    using FruityFalls.Forms.Common;
    using FruityFalls.Forms.Common.Enums;
    using FruityFalls.Forms.Geometry;
    using FruityFalls.Forms.Physics;

    public class Fruit : CCNode
    {
        private CCSprite graphic;
        private CCDrawNode debugGraphic;

        private IPositionCalculator positionCalculator;

        public Fruit(FruitType type, IPositionCalculator positionCalculator)
        {
            this.positionCalculator = positionCalculator;

            SetType(type);

            CreateGraphic();

            CreateHitBox();
        }

        public Circle Collision { get; private set; }

        public FruitType Type { get; private set; }

        public void Activity(float frameTimeInSeconds)
        {
            this.Position = positionCalculator.GetNewPosition(frameTimeInSeconds, this.Position);
        }

        private void SetType(FruitType type)
        {
            if (type == FruitType.Random)
            {
                int rand = CCRandom.GetRandomInt(0, 1);
                Type = rand == 0 ? FruitType.Cherry : FruitType.Lemon;
            }
            else
            {
                Type = type;
            }
        }

        private void CreateGraphic()
        {
            string image = Type == FruitType.Cherry ? Images.CHERRY : Images.LEMON;

            if (!string.IsNullOrEmpty(image))
            {
                this.graphic = new CCSprite(image);
                this.graphic.IsAntialiased = true;
                this.AddChild(graphic);
            }
            else
            {
                throw new ArgumentException($"Invalid FruitType: {Type}");
            }
        }

        private void CreateDebugGraphic()
        {
            debugGraphic = new CCDrawNode();
            this.AddChild(debugGraphic);
        }

        private void CreateHitBox()
        {
            Collision = new Circle();
            Collision.Radius = Coefficients.FruitRadius;
            this.AddChild(Collision);
        }
    }
}