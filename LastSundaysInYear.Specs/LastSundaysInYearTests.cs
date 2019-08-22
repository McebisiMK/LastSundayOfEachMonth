using System;
using System.Collections.Generic;
using FluentAssertions;
using LastSundaysInYear.Library;
using LastSundaysInYear.Library.Exceptions;
using LastSundaysInYear.Library.ILastSundayOfMonth;
using LastSundaysInYear.Library.IValidations;
using NSubstitute;
using NUnit.Framework;

namespace LastSundaysInYear.Specs
{
    [TestFixture]
    public class LastSundaysInYearTests
    {
        [TestCase(-1)]
        [TestCase(0000)]
        [TestCase(11111)]
        public void GetLastSundays_Given_Invalid_Year_Should_Throw_Exception_With_Message(int year)
        {
            //-----------------------Arrange------------------------------
            var validator = Substitute.For<IValidator>();
            var lastSunday = Substitute.For<ILastSunday>();
            var lastSundaysInYear = new LastSundays(validator, lastSunday);

            validator.When(x => x.Validate(year)).Throw(new InvalidYearException());

            //-----------------------Act----------------------------------
            var exception = Assert.Throws<InvalidYearException>(() => lastSundaysInYear.GetLastSundays(year));

            //-----------------------Assert-------------------------------
            exception.Message.Should().Be("Year must be between 1 - 9999!!");
        }

        [TestCase(0001)]
        [TestCase(2015)]
        [TestCase(9999)]
        public void GetLastSundays_Given_Valid_Year_Should_Make_A_Call_To_Validate_Method(int year)
        {
            //-----------------------Arrange------------------------------
            var validator = Substitute.For<IValidator>();
            var lastSunday = Substitute.For<ILastSunday>();
            var lastSundaysInYear = new LastSundays(validator, lastSunday);

            //-----------------------Act----------------------------------
            lastSundaysInYear.GetLastSundays(year);

            //-----------------------Assert-------------------------------
            validator.Received(1).Validate(year);
        }

        [TestCase(-2010)]
        [TestCase(99999)]
        [TestCase(0)]
        public void GetLastSundays_Given_Invalid_Year_Should_Not_Call_GetLastSunday_Method(int year)
        {
            //-----------------------Arrange------------------------------
            var validator = Substitute.For<IValidator>();
            var lastSunday = Substitute.For<ILastSunday>();
            var lastSundaysInYear = new LastSundays(validator, lastSunday);

            validator.When(x => x.Validate(year)).Throw(new InvalidYearException());

            //-----------------------Act----------------------------------
            var exception = Assert.Throws<InvalidYearException>(() => lastSundaysInYear.GetLastSundays(year));

            //-----------------------Assert-------------------------------
            lastSunday.DidNotReceive().GetLastSunday(Arg.Any<int>(), Arg.Any<int>());
        }

        [TestCase(1111)]
        [TestCase(2014)]
        [TestCase(2010)]
        public void GetLastSundays_Given_Valid_Year_Should_Make_Twelve_Calls_To_LastSundayOfMonth_Method(int year)
        {
            //-----------------------Arrange------------------------------
            var validator = Substitute.For<IValidator>();
            var lastSunday = Substitute.For<ILastSunday>();
            var lastSundaysInYear = new LastSundays(validator, lastSunday);

            //-----------------------Act----------------------------------
            lastSundaysInYear.GetLastSundays(year);

            //-----------------------Assert-------------------------------
            lastSunday.Received(12).GetLastSunday(Arg.Any<int>(), Arg.Any<int>());
        }

        [Test]
        public void GetLastSundayOfEachMonth_GivenValidYear_ShouldGetLastSundayOfEachMonth()
        {
            //---------------------------------Arrange-------------------------------------------------
            var year = 2013;
            var lastSundaysOfTheYear = new LastSundays();

            //---------------------------------Act-----------------------------------------------------
            var actual = lastSundaysOfTheYear.GetLastSundays(year);

            //---------------------------------Assert--------------------------------------------------
            var expectedSundays = GetLastSundaysInYear(year);

            actual.Should().BeEquivalentTo(expectedSundays);

        }

        private List<DateTime> GetLastSundaysInYear(int year)
        {
            return new List<DateTime>()
                        {
                            new DateTime(year,01,27),
                            new DateTime(year,02,24),
                            new DateTime(year,03,31),
                            new DateTime(year,04,28),
                            new DateTime(year,05,26),
                            new DateTime(year,06,30),
                            new DateTime(year,07,28),
                            new DateTime(year,08,25),
                            new DateTime(year,09,29),
                            new DateTime(year,10,27),
                            new DateTime(year,11,24),
                            new DateTime(year,12,29)
                        };
        }
    }
}