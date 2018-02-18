using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StravaClub.Core.Utils
{
	public static class NumberHelpers
	{
		/// <summary>
		/// Extract numbers from strava
		/// </summary>
		/// <param name="value">the value from the page</param>
		/// <returns>number</returns>
		public static double ExtractNumberFromStrava(this string value)
		{
			/// necessary to deal with time numbers
			value = value.Replace('h', '.');

			value = String.Concat(
				value.Where(c => Char.IsDigit(c) || Char.IsPunctuation(c))
			);

			return double.Parse(value);
		}

		public static string FormatToStravaTime(this decimal value)
		{
			var values = value.ToString().Split('.');

			if (values.Length == 0)
			{
				return string.Empty;
			}

			var hours = values.Length > 0 ? values[0] : "0";
			var minutes = values.Length > 1 ? values[1] : "0";

			return $"{hours}h {minutes}m";
		}
	}
}
