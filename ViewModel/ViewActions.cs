using LiveCharts;

namespace ViewModel
{
    public interface ViewActions
    {
        public void AddToSeries(SeriesCollection SeriesCollection, double[] points, double[] values, string title, int mode);

        public void SendErrorMessage(string error);
    }
}
