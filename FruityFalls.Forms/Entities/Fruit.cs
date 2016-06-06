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
    using CocosSharp;

    using FruityFalls.Forms.Common;
    using FruityFalls.Forms.Geometry;
    using FruityFalls.Forms.Physics;

    public class Fruit : CCNode
    {
        private CCSprite graphic;
        private CCDrawNode debugGraphic;

        private IPositionCalculator positionCalculator;

        public Fruit(IPositionCalculator positionCalculator)
        {
            this.positionCalculator = positionCalculator;

            CreateGraphic();

            if (Coefficients.ShowCollisionAreas) 
            {
                CreateDebugGraphic();
            }

            CreateHitBox();
        }

        public Circle Collision { get; private set; }



        public void Activity(float frameTimeInSeconds)
        {
            Velocity += Acceleration * frameTimeInSeconds;
            this.Position += Velocity * frameTimeInSeconds;

            this.Position = positionCalculator.GetNewPosition(frameTimeInSeconds);
        }

        public float Radius 
        {
            get { return Coefficients.FruitRadius; }
        }

        private void CreateGraphic()
        {
            this.graphic = new CCSprite(Images.CHERRY);
            this.graphic.IsAntialiased = true;
            this.AddChild(graphic);
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