using Xunit;
using CarWorkshop.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using CarWorkshop.Application.CarWorkshop;
using Moq;
using MediatR;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using Microsoft.AspNetCore.TestHost;
using FluentAssertions;
using System.Net;

namespace CarWorkshop.MVC.Controllers.Tests
{
    public class CarWorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _factory;

        public CarWorkshopControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingWorkshops()
        {
            var carWorkshops = new List<CarWorkshopDto>()
            {
                new CarWorkshopDto { Name = "cw 1" },
                new CarWorkshopDto { Name = "cw 2" },
                new CarWorkshopDto { Name = "cw 3" }
            };

            var medatiorMock = new Mock<IMediator>();
            medatiorMock.Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(carWorkshops);

            var client = _factory
                .WithWebHostBuilder(builder
                    => builder.ConfigureTestServices(services => services.AddScoped(_ => medatiorMock.Object)))
                .CreateClient();

            var response = await client.GetAsync("/CarWorkshop/Index");
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should()
                .Contain("<h1>Index</h1>")
                .And.Contain("cw 1")
                .And.Contain("cw 2")
                .And.Contain("cw 3");

        }

        [Fact()]
        public async Task Index_ReturnsEmptyView_ForNonExistingWorkshops()
        {
            var carWorkshops = new List<CarWorkshopDto>();

            var medatiorMock = new Mock<IMediator>();
            medatiorMock.Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(carWorkshops);

            var client = _factory
                .WithWebHostBuilder(builder
                    => builder.ConfigureTestServices(services => services.AddScoped(_ => medatiorMock.Object)))
                .CreateClient();

            var response = await client.GetAsync("/CarWorkshop/Index");
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should()
                .NotContain("div class=\"card m-3\" style=\"width: 18rem;\"");

        }

    }
}