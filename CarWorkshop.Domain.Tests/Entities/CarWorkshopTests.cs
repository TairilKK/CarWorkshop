using Xunit;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodedName()
        {
            var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            carWorkshop.EncodeName();

            carWorkshop.EncodedName.Should().Be("test-workshop");
        }
    }
}