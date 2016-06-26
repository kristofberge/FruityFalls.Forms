// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FruitSpawner.cs" company="ArcTouch, Inc.">
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
//   Defines the FruitSpawner type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace FruityFalls.Forms.Entities
{
    using System;

    public class FruitSpawner
    {
        protected float lastSpawn;
        protected float timeSinceLastSpawn;

        public FruitSpawner(float timeBetweenSpawns, Func<Fruit> createFruitFunction)
        {
            TimeBetweenSpawns = timeBetweenSpawns;
            CreateFruitFunction = createFruitFunction;

            timeSinceLastSpawn = timeBetweenSpawns;
        }
        
        public event EventHandler<Fruit> FruitSpawned;
        
        public float TimeBetweenSpawns { get; set; }
        
        public Func<Fruit> CreateFruitFunction { get; set; }

        public void Activity(float frameTimeInSeconds)
        {
            if (HasEnoughTimePassed(frameTimeInSeconds))
            {
                this.timeSinceLastSpawn = 0;
                FruitSpawned?.Invoke(this, CreateFruitFunction?.Invoke() ?? null);
            }
        }

        private bool HasEnoughTimePassed(float frameTimeInSeconds)
        {
            this.timeSinceLastSpawn += frameTimeInSeconds;
            return timeSinceLastSpawn >= TimeBetweenSpawns;
        }
    }
}