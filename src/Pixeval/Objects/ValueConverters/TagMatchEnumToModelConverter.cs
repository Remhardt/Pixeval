﻿#region Copyright (C) 2019-2020 Dylech30th. All rights reserved.

// Pixeval - A Strong, Fast and Flexible Pixiv Client
// Copyright (C) 2019-2020 Dylech30th
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System;
using System.Globalization;
using System.Windows.Data;
using Pixeval.Core;
using Pixeval.Data.ViewModel;

namespace Pixeval.Objects.ValueConverters
{
    public class TagMatchEnumToModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SearchTagMatchOption option)
                return option switch
                {
                    SearchTagMatchOption.PartialMatchForTags => SearchTagMatchOptionModel.PartialMatchModel,
                    SearchTagMatchOption.ExactMatchForTags   => SearchTagMatchOptionModel.ExactMatchModel,
                    SearchTagMatchOption.TitleAndCaption     => SearchTagMatchOptionModel.TitleAndCaptionModel,
                    _                                        => throw new ArgumentOutOfRangeException()
                };
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SearchTagMatchOptionModel model) return model.Corresponding;

            return null;
        }
    }
}