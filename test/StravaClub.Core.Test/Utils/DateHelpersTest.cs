using StravaClub.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StravaClub.Core.Test.Utils
{
	public class DateHelpersTest
	{
		[Fact]
		public void DaysToEndYear_CalculteDays_ReturnNumberDays()
		{
			// Arrange
			var dateTime = new DateTime(2016, 1, 1);

			// Act
			var days = dateTime.DaysToEndYear();

			// Assert
			Assert.Equal(365, days);
		}

		[Fact] 

		public void DaysToEndMonth_CalculteDaysInTheBeginningOfTheYear_ReturnNumberDays()
		{
			// Arrange
			var dateTime = new DateTime(2016, 1, 1);

			// Act
			var days = dateTime.DaysToEndMonth();

			// Assert
			Assert.Equal(31, days);
		}

		[Fact]
		public void DaysToEndMonth_CalculteDaysInTheMiddleOfTheMonth_ReturnNumberDays()
		{
			// Arrange
			var dateTime = new DateTime(2018, 5, 21);

			// Act
			var days = dateTime.DaysToEndMonth();

			// Assert
			Assert.Equal(11, days);
		}
	}
}
