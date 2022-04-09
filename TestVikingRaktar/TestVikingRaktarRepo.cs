using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using System.Web;
using VikingRaktar;
using Xunit;

namespace TestVikingRaktar
{
    //TDD
    public class TestVikingRaktarRepo: IClassFixture<WebApplicationFactory<VikingRaktar.Startup>>
    {
        private readonly WebApplicationFactory<VikingRaktar.Startup> _factory;

        public TestVikingRaktarRepo(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        
        [Fact]
        public async Task TestRaktarIndexPage()
        {
            //Arange,Act,Assert
            //Arange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/Raktar/Index");
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);

        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Raktar/Index")]
        [InlineData("/Raktar/Details/1")]
        [InlineData("/Raktar/Edit")]
        [InlineData("/Raktar/Create")]


        public async Task TestAllIndexPage(string url)
        {
            //Arange,Act,Assert
            //Arange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync(url);
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);

        }

        [Theory]
        [InlineData("Alaplap")]
        [InlineData("Egér")]
        [InlineData("Almafa")]

        public async Task TestAruk(string title)
        {
            
            //Arange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("Raktar/Index");
            var pageContents = await response.Content.ReadAsStringAsync();
            var content = pageContents.ToString();
            
            //var c = HttpUtility.HtmlEncode(title);


            //assert
            //magyar ékezet probléma
            Assert.Contains(title, content);

        }


    }


}
