﻿using System;

namespace Dotnet.Modular.Core.Extensions.Common;

/// <summary>
/// Extension methods for the <see cref="DateTime"/>.
/// </summary>
public static class DateTimeExtensions
{
    public static DateTime ClearTime(this DateTime dateTime)
    {
        return dateTime.Subtract(
            new TimeSpan(
                0,
                dateTime.Hour,
                dateTime.Minute,
                dateTime.Second,
                dateTime.Millisecond
            )
        );
    }
}
