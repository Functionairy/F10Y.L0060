using System;

using F10Y.T0002;


namespace F10Y.L0060
{
    /// <summary>
    /// Functions for the <see cref="DateOnly"/> type.
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IDateOnlyOperator
    {
        DateOnly Add_Days(DateOnly date, int days)
            => date.AddDays(days);

        DateOnly Add_Day(DateOnly date)
            => this.Add_Days(date, 1);

        DateOnly Add_Years(DateOnly date, int years)
            => date.AddYears(years);

        DateOnly Add_Year(DateOnly date)
            => this.Add_Years(date, 1);

        DateOnly Subtract_Year(DateOnly date)
            => this.Add_Years(date, -1);

        string Format(
            DateOnly date,
            string formatTemplate)
            => Instances.StringOperator.Format(
                formatTemplate,
                date);

        DateOnly Get_Today_Local()
        {
            var dateTime = Instances.DateTimeOperator.Get_Today_Local();

            var output = this.From_DateTime(dateTime);
            return output;
        }

        DateOnly Get_Today_Utc()
        {
            var dateTime = Instances.DateTimeOperator.Get_Today_Utc();

            var output = this.From_DateTime(dateTime);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Today_Local"/> as the default.
        /// </summary>
        DateOnly Get_Today()
        {
            var today = this.Get_Today_Local();
            return today;
        }

        DateOnly Get_Tomorrow_Local()
        {
            var todayLocalDateTime = Instances.DateTimeOperator.Get_Tomorrow_Local();

            var todayLocal = this.From_DateTime(todayLocalDateTime);
            return todayLocal;
        }

        DateOnly Get_Tomorrow_Utc()
        {
            var todayUtcDateTime = Instances.DateTimeOperator.Get_Tomorrow_Utc();

            var todayUtc = this.From_DateTime(todayUtcDateTime);
            return todayUtc;
        }

        /// <summary>
        /// Chooses <see cref="Get_Tomorrow_Local"/> as the default.
        /// </summary>
        DateOnly Get_Tomorrow()
        {
            var today = this.Get_Tomorrow_Local();
            return today;
        }

        int Get_Year(DateOnly date)
            => date.Year;

        DateOnly From_DateTime(DateTime dateTime)
        {
            var dateOnly = DateOnly.FromDateTime(dateTime);
            return dateOnly;
        }

        DateTime To_DateTime(DateOnly date)
        {
            var output = Instances.DateTimeOperator.From(
                date.Year,
                date.Month,
                date.Day,
                0, 0, 0);

            return output;
        }

        DateOnly Get_DateOnly(DateTime dateTime)
        {
            var output = DateOnly.FromDateTime(dateTime);
            return output;
        }

        bool Is_Saturday(DateOnly date)
    => this.Is_DayOfWeek(
        date,
        DayOfWeek.Saturday);

        bool Is_Sunday(DateOnly date)
            => this.Is_DayOfWeek(
                date,
                DayOfWeek.Sunday);

        bool Is_DayOfWeek(
            DateOnly date,
            DayOfWeek dayOfWeek)
            => date.DayOfWeek == dayOfWeek;

        DateOnly Parse_Exact(
            string dateOnlyString,
            string formatString)
        {
            var output = DateOnly.ParseExact(
                dateOnlyString,
                formatString);

            return output;
        }
    }
}
