using System;
using NUnit.Framework;
using PayrollProcessor.Core.Paystub;
using PayrollProcessor.Core.Workweek;

namespace PayrollProcessor.Tests.Paystub
{
    [TestFixture]
    public class PaystubDateGetterTests
    {
        private PaystubDateGetter _sut;

        [SetUp]
        public void Init()
        {
            _sut = new PaystubDateGetter(new StandardWorkweek());
        }

        [Test]
        public void PaystubDateGetter_ShouldReturn_CorrectDates_ForMidweek()
        {
            //Arrange
            var date = DateTime.Parse("2018-06-14");

            var expectedStartDate = DateTime.Parse("2018-05-28");
            var expectedEndDate = DateTime.Parse("2018-06-10");

            //Act
            var dates = _sut.GetPaystubDates(date);

            //Assert
            Assert.That(dates.StartDate == expectedStartDate);
            Assert.That(dates.EndDate == expectedEndDate);
        }

        [Test]
        public void PaystubDateGetter_ShouldReturn_CorrectDates_ForEndDate()
        {
            //Arrange
            var date = DateTime.Parse("2018-06-17");

            var expectedStartDate = DateTime.Parse("2018-05-28");
            var expectedEndDate = DateTime.Parse("2018-06-10");

            //Act
            var dates = _sut.GetPaystubDates(date);

            //Assert
            Assert.That(dates.StartDate == expectedStartDate);
            Assert.That(dates.EndDate == expectedEndDate);
        }
    }
}
