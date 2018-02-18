using StravaClub.Core.Utils;
using Xunit;

namespace StravaClub.Core.Test.Utils
{
	public class NumberHelpersTest
	{
		[Theory]
		[InlineData("1000m", 1000)]
		[InlineData("70.1km", 70.1)]
		[InlineData("7h 1m", 7.1)]
		public void ExtractNumberFromStrava_ParseNumber_ReturnDecimal(string value, double expected)
		{
			// Act
			var number = value.ExtractNumberFromStrava();

			// Assert
			Assert.Equal(expected, number);
		}

		[Theory]
		[InlineData(1, "1h 0m")]
		[InlineData(1.2, "1h 2m")]
		[InlineData(12.5, "12h 5m")]
		[InlineData(2.17, "2h 17m")]
		public void FormatToStravaTime_FormatNumber_FormatedValue(decimal value, string expected)
		{
			// Act
			var formatedValue = value.FormatToStravaTime();

			// Assert
			Assert.Equal(expected, formatedValue);
		}
	}
}