using Xunit;
using CarWorkshop.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using FluentAssertions;

namespace CarWorkshop.MVC.Controllers.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HomeControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact()]
        public async Task About_ReturnsViewWithRenderModel()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Home/About");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should()
                .Contain("<h1>About</h1>")
                .And.Contain("<div class=\"alert alert-primary\">Description</div>")
                .And.Contain("<li>beard</li>")
                .And.Contain("<li>meats</li>")
                .And.Contain("<li>food</li>");
        }
    }
}