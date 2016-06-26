// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearSpeedPositionCalculator.cs" company="ArcTouch, Inc.">
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
//   Defines the LinearSpeedPositionCalculator type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Physics
{
    using CocosSharp;

    public class ConstantSpeedPositionCalculator : IPositionCalculator
    {
        public ConstantSpeedPositionCalculator(float gravity)
        {
            Velocity = new CCPoint(0, gravity);
        }

        public CCPoint Velocity { get; set; }
        
        public CCPoint GetNewPosition(float frameTimeInSeconds, CCPoint currentPosition)
        {
            return currentPosition += Velocity * frameTimeInSeconds;
        }
    }
}