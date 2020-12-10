using Bunit;
using Xunit;

namespace Beam.Tests
{
    public class IndexPagesTests : TestContext
    {
        [Fact]
        public void CounterStartsAtZero()
        {
            // Arrange
            var cut = RenderComponent<Beam.Client.Pages.Index>();

            // Assert
            Assert.Contains("Select a Frequency, or create a new one", cut.Markup);
            cut.MarkupMatches(@"<h2 diff:ignore></h2>
                                        <p diff:ignore></p>");
        }
    }
}
