using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PayrollProcessor.Core;
using PayrollProcessor.Core.Entities;
using PayrollProcessor.Core.Repositories;
using PayrollProcessor.Core.Repositories.Decorators;

namespace PayrollProcessor.Tests.Repositories.Decorators
{
    [TestFixture]
    public class CacheRepositoryDecoratorTests
    {
        [Test]
        public void CacheRepositoryDecorator_ShouldCache_EmployeeRepository()
        {
            //Arrange
            var employeeId = 1;

            var testEmployee =
                new Employee()
                {
                    Id = employeeId,
                    FirstName = "Test",
                    State = State.TX,
                    HourlyRate = 100,
                    LastName = "Test"
                };

            var repoMock = new Mock<IEmployeeGetRepository>();
            repoMock.Setup(r => r.Get(employeeId))
                .Returns(testEmployee);

            var sut = new CacheRepositoryDecorator(repoMock.Object);

            //Act
            // Call twice but make sure the repository was only hit once, second call should pull from cache
            var employee = sut.Get(employeeId);
            employee = sut.Get(employeeId);

            //Assert
            repoMock.Verify(x => x.Get(employeeId), Times.AtMostOnce);
            Assert.That(employee.Id == employeeId);
        }
    }
}
