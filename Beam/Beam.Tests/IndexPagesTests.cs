using Beam.Client.Pages;
using Beam.Tests.Auth;
using Bunit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Beam.Tests
{
    public class IndexPagesTests : TestContext
    {
        [Fact]
        public void CounterStartsAtZero()
        {
            Services.AddAuthenticationServices(TestAuthenticationStateProvider
                .CreateAuthenticationState("TestUser"));

            var wrapper = RenderComponent<CascadingAuthenticationState>(p => p.AddChildContent<Index>());

            // Arrange
            var cut = wrapper.FindComponent<Index>();

            // Assert
            Assert.Contains("Select a Frequency, or create a new one", cut.Markup);
            cut.MarkupMatches(@"<h2 diff:ignore></h2>
                                        <p diff:ignore></p>");
        }

        [Fact]
        public void IndexShowsLoginLinkWhenUnAuthorized()
        {
            Services.AddAuthenticationServices(TestAuthenticationStateProvider.CreateUnauthenticationState(),
                AuthorizationResult.Failed());

            Services.AddScoped<MockNavigationManager, MockNavigationManager>();
            var wrapper = RenderComponent<CascadingAuthenticationState>(p => p.AddChildContent<Index>());

            // Arrange
            var cut = wrapper.FindComponent<Index>();

            Assert.DoesNotContain("Select a Frequency, or create a new one", cut.Markup);

            cut.Find("a").MarkupMatches(@"<a href=""/login"">Log In</a>");
        }
    }
}
