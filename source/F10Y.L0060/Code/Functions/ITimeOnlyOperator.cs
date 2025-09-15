using System;

using F10Y.T0002;


namespace F10Y.L0060
{
    [FunctionsMarker]
    public partial interface ITimeOnlyOperator
    {
        TimeOnly From(
            int hours,
            int minutes)
            => new(hours, minutes);

        TimeOnly From_DateTime(DateTime dateTime)
        {
            var timeOnly = TimeOnly.FromDateTime(dateTime);
            return timeOnly;
        }

        /// <inheritdoc cref="Get_NextDateTimeOffset_Local(TimeOnly, TimeOnly)"/>
        DateTimeOffset Get_NextDateTimeOffset_Local(TimeOnly time_Local)
        {
            var now_Local_TimeOnly = this.Get_Now_Local();

            var nextDateTimeOffset = this.Get_NextDateTimeOffset_Local(
                time_Local,
                now_Local_TimeOnly);

            return nextDateTimeOffset;
        }

        /// <summary>
        /// Gets the next datetime offset at which the local time occurs.
        /// <inheritdoc cref="Documentation.NextDateAfterTime"/>
        /// </summary>
        DateTimeOffset Get_NextDateTimeOffset_Local(
            TimeOnly localTime,
            TimeOnly localNow)
        {
            var nextLocalDateTime = this.Get_NextDateTime_Local(localTime, localNow);

            var nextDateTimeOffset = Instances.DateTimeOffsetOperator.From_DateTime_Local(nextLocalDateTime);
            return nextDateTimeOffset;
        }

        TimeOnly Get_Now_Local()
        {
            var now_Local_DateTime = Instances.DateTimeOperator.Get_Now_Local();

            var nowLocal = this.From_DateTime(now_Local_DateTime);
            return nowLocal;
        }

        TimeOnly Get_TimeOnly(DateTime dateTime)
        {
            var output = TimeOnly.FromDateTime(dateTime);
            return output;
        }

        /// <summary>
        /// Gets the next datetime which the local time occurs.
        /// <inheritdoc cref="Documentation.NextDateAfterTime"/>
        /// </summary>
        DateTime Get_NextDateTime_Local(TimeOnly localTime, TimeOnly localNow)
        {
            var dateForNextTime = this.Get_DateForNextTime_Local(localTime, localNow);

            var nextLocalDateTime = Instances.DateTimeOperator.From_DateAndTime(dateForNextTime, localTime);
            return nextLocalDateTime;
        }

        DateOnly Get_DateForNextTime_Local(TimeOnly localTime, TimeOnly localNow)
        {
            var timeIsAfterNow = this.Is_TimeAfterNow_Local(localTime, localNow);

            var dateForNextTime = timeIsAfterNow
                ? Instances.DateOnlyOperator.Get_Today_Local()
                : Instances.DateOnlyOperator.Get_Tomorrow_Local();
                ;

            return dateForNextTime;
        }

        bool Is_TimeAfterNow_Local(
            TimeOnly time_Local,
            TimeOnly now_Local)
        {
            var timeIsAfterNow = time_Local > now_Local;
            return timeIsAfterNow;
        }
    }
}
