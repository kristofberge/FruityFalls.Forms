// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IncreasingFruitSpawner.cs" company="ArcTouch, Inc.">
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
//   Defines the IncreasingFruitSpawner type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Entities
{
    using System;

    public class IncreasingFruitSpawner : FruitSpawner
    {
        public IncreasingFruitSpawner(float timeBetweenSpawns, Func<Fruit> createFruitFunction)
            : base(timeBetweenSpawns, createFruitFunction)
        {
            
        }
    }
}