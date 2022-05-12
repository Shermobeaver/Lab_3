using System.Windows.Media;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using ViewModel;

namespace Lab_3
{
    public class ThisViewActions : ViewActions
    {
        // Add plot series
        public void AddToSeries(SeriesCollection SeriesCollection, double[] points, double[] values, string title, int mode)
        {
            // Custom array
            ChartValues<ObservablePoint> Values = new ChartValues<ObservablePoint>();
            for (int i = 0; i < values.Length; i++)
            {
                Values.Add(new(points[i], values[i]));
            }

            // Measured data
            if (mode == 0)
            {
                SeriesCollection.Add(new ScatterSeries
                {
                    Title = title,
                    Values = Values,
                    Fill = Brushes.Red,
                    MinPointShapeDiameter = 5,
                    MaxPointShapeDiameter = 5
                });
            }
            // Splines
            else if (mode == 1)
            {
                SeriesCollection.Add(new LineSeries
                {
                    Title = title,
                    Values = Values,
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Green,
                    PointGeometry = null, // Line without markers
                    LineSmoothness = 0
                });
            }
        }

        // Show error MessageBox
        public void SendErrorMessage(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
