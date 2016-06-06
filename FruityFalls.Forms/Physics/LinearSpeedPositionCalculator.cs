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
using System;
using CocosSharp;
using FruityFalls.Forms.Common;

namespace FruityFalls.Forms.Physics
{
    public class LinearSpeedPositionCalculator : IPositionCalculator
    {
        public CCPoint Velocity { get; private set; }

        public LinearSpeedPositionCalculator()
        {
            Velocity = new CCPoint(0, Coefficients.Gravity);
        }

        public CCPoint GetNewPosition(float frameTimeInSeconds)
        {
            return Velocity * frameTimeInSeconds;
        }
    }
}

