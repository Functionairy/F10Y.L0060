using System;


namespace F10Y.L0060
{
	/// <summary>
	/// .NET 6.0 foundation library.
	/// </summary>
	public static class Documentation
	{
        /// <summary>
        /// .NET 6.0 foundation library.
        /// </summary>
        /// <reference>
        /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
        /// </reference>
        public static readonly object Project_SelfDescription;

        /// <summary>
        /// If the time is after now, then the next time occurs today. Else if the time occurs before now, then the next time occurs tomorrow.
        /// </summary>
        public static readonly object NextDateAfterTime;
    }
}