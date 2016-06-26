// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageModel.cs" company="ArcTouch, Inc.">
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
//   Defines the MainPageModel type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using FruityFalls.Forms.Common.Enums;
using Xamarin.Forms;

namespace FruityFalls.Forms.PageModels
{
    [PropertyChanged.ImplementPropertyChanged]
    public class MainPageModel
    {
        public MainPageModel()
        {
            SetFruitTypeCommand = new Command<FruitType>(SetFruitType);
        }

        public FruitType SelectedFruitType { get; set; }

        public Command<FruitType> SetFruitTypeCommand { get; set; }

        private void SetFruitType(FruitType type)
        {
            SelectedFruitType = type;
        }
    }
}