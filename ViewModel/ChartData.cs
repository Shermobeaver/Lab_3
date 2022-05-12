using LiveCharts;

namespace ViewModel
{
    public class ChartData
    {
        // Properties
        public SeriesCollection PlotLines { get; set; }
        public Func<double, string> Formatter { get; set; }

        // Constructor
        public ChartData()
        {
            PlotLines = new SeriesCollection();

            // Values Formatter
            Formatter = value => value.ToString("F4");
        }
    }
}
