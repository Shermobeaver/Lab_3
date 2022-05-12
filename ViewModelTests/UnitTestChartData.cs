using Xunit;
using ViewModel;

namespace ViewModelTests
{
    public class UnitTestChartData
    {
        // Can construct?
        [Fact]
        public void TestConstructor()
        {
            var plot = new ChartData();

            // Is null?
            Assert.NotNull(plot);

            // Inner variables created correctly?
            Assert.NotNull(plot.PlotLines);
            Assert.NotNull(plot.Formatter);
        }
    }
}
