// MIT License
//
// Copyright (c) 2007-2025 Balsam Research, LLC All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE

using System;
using System.Collections.Generic;

namespace Balsam
{
    /// <summary>
    /// Defines common methods and properties that all time series must implement.
    /// </summary>
    public interface ISeries
    {
        #region Properties

        /// <summary>
        /// Gets/sets the symbol.
        /// </summary>
        string Symbol { get; set; }

        /// <summary>
        /// Gets/sets the name or description.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the number of observations in the series.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the indexing strategy. Absolute indexes the series from 0 to Count - 1. RelativeToCurrentBar operates as an offset to Index.
        /// </summary>
        IndexKind Indexing { get; }

        /// <summary>
        /// Gets the index of the current bar or -1 if Indexing property is Absolute.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Gets the current object according to the indexing strategy.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        object this[int index] { get; }

        /// <summary>
        /// Gets/sets the index on which the series is in a valid state.
        /// </summary>
        int MaxBarsBack { get; set; }

        /// <summary>
        /// Gets the dates associated with the series.
        /// </summary>
        IReadOnlyList<DateTime> Dates { get; }

        /// <summary>
        /// Gets the first date on which there is valid data available (i.e on MaxBarsBack).
        /// </summary>
        DateTime FirstDate { get; }

        /// <summary>
        /// Gets the late date of the series.
        /// </summary>
        DateTime LastDate { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the index to the specified value.
        /// </summary>
        /// <param name="index"></param>
        void SetIndex(int index);

        /// <summary>
        /// Sets the index using the specified date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        int SetIndex(DateTime date);

        /// <summary>
        /// Returns the value at the specified index. Indexing strategy is ignored.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        object GetValue(int index);

        /// <summary>
        /// Sets the value in a series at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void SetValue(int index, object value);

        /// <summary>
        /// Adds a date/value observation to the series.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        void Add(DateTime date, object value);

        /// <summary>
        /// Removes an observation at the specified index.
        /// </summary>
        /// <param name="index"></param>
        void Remove(int index);

        /// <summary>
        /// Removes an observation at the specified date. Returns true if date found.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool Remove(DateTime date);

        /// <summary>
        /// Clears the series.
        /// </summary>
        void Clear();

        /// Returns a new series that is synced with the specified dates.
        ISeries Sync(IEnumerable<DateTime> dates);

        /// <summary>
        /// Returns an independent copy of this series.
        /// </summary>
        /// <returns></returns>
        ISeries Clone();

        /// <summary>
        /// Returns a subset of this series between the specified start and end dates inclusive.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        ISeries Subset(DateTime startDate, DateTime endDate);

        #endregion
    }
}
