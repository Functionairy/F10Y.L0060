using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0060
{
    [FunctionsMarker]
    public partial interface IDateTimeOperator :
        L0000.IDateTimeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0000.IDateTimeOperator _L0000 => L0000.DateTimeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        DateTime From_DateAndTime(DateOnly dateOnly, TimeOnly timeOnly)
        {
            var dateTime = dateOnly.ToDateTime(timeOnly);
            return dateTime;
        }
    }
}
