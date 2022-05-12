using System.Collections.ObjectModel;
using Model;

namespace ViewModel
{
    public class ViewData
    {
        // Properties
        public InputParams InputData { get; set; }
        public SplinesData SpData { get; set; }
        public ObservableCollection<string> ListContents { get; set; }
        public ChartData Plot { get; set; }
        public ViewActions ViewActions { get; set; }
        public TextOutput TextBlocks { get; set; }

        public bool IsMeasured { get; set; }
        public bool IsSplined { get; set; }

        // Constructor
        public ViewData(ViewActions inViewActions)
        {
            // Actions, provided by View
            ViewActions = inViewActions;

            // Starter values
            InputData = new(20, 20 * 10, 0, 20, SPf.Cubic, 1, 10.5, 15.8);

            // Init
            SpData = new(new(InputData), new(InputData));
            ListContents = new();
            Plot = new();
            TextBlocks = new();
        }

        // Actions
        public bool ActionMeasure_CanExecute()
        {
            return !InputData.Error1;
        }
        public void ActionMeasure(object obj)
        {
            try
            {
                // Clear old values
                TextBlocks.SetDefaults();

                // Update data from InputParameters
                SpData.Measured.Updater(InputData);

                // Sets grid and measures values
                Measure();

                // Set flag for Splines command
                IsMeasured = true;
                IsSplined = false;

                // Add to plot
                Plot.PlotLines.Clear();
                ViewActions.AddToSeries(Plot.PlotLines, SpData.Measured.Grid, SpData.Measured.Measures, "Measured", 0);
            }
            catch (Exception error)
            {
                ViewActions.SendErrorMessage($"Unexpected error: {error.Message}.");
            }
        }

        public bool ActionSplines_CanExecute()
        {
            return (!InputData.Error2) && IsMeasured && (!IsSplined);
        }
        public void ActionSplines(object obj)
        {
            try
            {
                // Update data from InputParameters
                SpData.SplParams.Updater(InputData);

                // Set flag so we can'te execute command again without measuring
                IsSplined = true;

                // Interpolation
                double status = Interpolate();

                if (status == 0)
                {
                    // Inputing text
                    TextBlocks.TextBlock_Der_1rst_l = SpData.Derivatieves[0];
                    TextBlocks.TextBlock_Der_1rst_r = SpData.Derivatieves[1];
                    TextBlocks.TextBlock_Der_2nd_l = SpData.Derivatieves[2];
                    TextBlocks.TextBlock_Der_2nd_r = SpData.Derivatieves[3];
                    TextBlocks.TextBlock_Spl1 = SpData.CubicSpline[0];
                    TextBlocks.TextBlock_Spl2 = SpData.CubicSpline[SpData.Measured.Length - 1];

                    // Add to plot
                    ViewActions.AddToSeries(Plot.PlotLines, GetUniformGrid(), SpData.CubicSpline, "Spline", 1);

                    //Integrals
                    status = Integrate();

                    if (status == 0)
                    {
                        // Inputing text
                        TextBlocks.TextBlock_Integ1 = SpData.Integrals[0];
                        TextBlocks.TextBlock_Integ2 = SpData.Integrals[1];
                    }
                    else
                    {
                        ViewActions.SendErrorMessage($"Error in Integrate(): {status}.");
                    }
                }
                else
                {
                    ViewActions.SendErrorMessage($"Error in Interpolate(): {status}.");
                }
            }
            catch (Exception error)
            {
                ViewActions.SendErrorMessage($"Unexpected error: {error.Message}.");
            }
        }

        // Measuring
        public void Measure()
        {
            SpData.Measured.CreateGrid();
            // Copying resault collection
            ListContents.Clear();
            ObservableCollection<string> collectionCopy = SpData.Measured.Measure();
            foreach (string item in collectionCopy)
            {
                ListContents.Add(item);
            }
        }

        // Creates uniform grid
        public double[] GetUniformGrid()
        {
            double[] gridUniform = new double[SpData.SplParams.UniformLength];
            double step = (SpData.Measured.Right - SpData.Measured.Left) / (SpData.SplParams.UniformLength - 1);
            for (int i = 0; i < SpData.SplParams.UniformLength; i++)
            {
                gridUniform[i] = SpData.Measured.Left + (i * step);
            }
            return gridUniform;
        }

        // Call interpolate and integrate functions
        public double Interpolate()
        {
            return SpData.Interpolate();
        }
        public double Integrate()
        {
            return SpData.Integrate();
        }
    }
}