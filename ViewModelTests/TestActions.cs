using LiveCharts;
using ViewModel;

namespace ViewModelTests
{
    internal class TestActions : ViewActions
    {
        public void AddToSeries(SeriesCollection SeriesCollection, double[] points, double[] values, string title, int mode)
        {
        }

        public void SendErrorMessage(string error)
        {
            throw new System.Exception(error);
        }
    }
}
