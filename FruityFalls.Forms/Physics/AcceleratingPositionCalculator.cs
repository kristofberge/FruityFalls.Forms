// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcceleratingPositionCalculator.cs" company="ArcTouch, Inc.">
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
//   Defines the AcceleratingPositionCalculator type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Physics
{
    using CocosSharp;

    public class AcceleratingPositionCalculator : IPositionCalculator
    {
        public CCPoint Velocity { get; set; }

        public CCPoint Acceleration { get; set; }

        public AcceleratingPositionCalculator(float acceleration, float initialVelocity)
        {
            Acceleration = new CCPoint(0, acceleration);
            Velocity = new CCPoint(0, initialVelocity);
        }

        public CCPoint GetNewPosition(float frameTimeInSeconds, CCPoint currentPosition)
        {
            Velocity += Acceleration * frameTimeInSeconds;
            return currentPosition += Velocity * frameTimeInSeconds;
        }
    }
}