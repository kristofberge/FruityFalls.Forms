// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Circle.cs" company="ArcTouch, Inc.">
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
//   Defines the Circle type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Geometry
{
    using CocosSharp;

    public class Circle : CCNode
    {
        public float Radius { get; set; }

        public bool IsPointInside(CCPoint point)
        {
            CCPoint absolutePosition = this.PositionWorldspace;

            float horizontalSide = point.X - absolutePosition.X;
            float verticalSide = point.Y - absolutePosition.Y;
            float distanceFromMiddle = (horizontalSide * horizontalSide) + (verticalSide * verticalSide);

            return distanceFromMiddle < Radius;
        }
    }
}