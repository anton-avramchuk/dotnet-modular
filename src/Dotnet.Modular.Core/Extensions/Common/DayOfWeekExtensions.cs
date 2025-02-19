﻿using System;

namespace Dotnet.Modular.Core.Extensions.Common;

/// <summary>
/// Extension methods for the <see cref="DayOfWeek"/>.
/// </summary>
public static class DayOfWeekExtensions
{
    /// <summary>
    /// Check if given <see cref="DayOfWeek"/> value is weekend.
    /// </summary>
    public static bool IsWeekend(this DayOfWeek dayOfWeek)
    {
        return dayOfWeek.IsIn(DayOfWeek.Saturday, DayOfWeek.Sunday);
    }

    /// <summary>
    /// Check if given <see cref="DayOfWeek"/> value is weekday.
    /// </summary>
    public static bool IsWeekday(this DayOfWeek dayOfWeek)
    {
        return dayOfWeek.IsIn(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday);
    }
}
