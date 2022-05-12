using Xunit;
using Model;
using ViewModel;

namespace ViewModelTests
{
    public class UnitTestViewData
    {
        // Can construct?
        [Fact]
        public void TestConstructor()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            // Is null?
            Assert.NotNull(viewData);

            // Inner variables created correctly?
            Assert.NotNull(viewData.InputData);
            Assert.NotNull(viewData.SpData);
            Assert.NotNull(viewData.ListContents);
            Assert.NotNull(viewData.Plot);
            Assert.NotNull(viewData.ViewActions);
            Assert.NotNull(viewData.TextBlocks);
        }

        // Updater for measured and splines works correctly
        [Fact]
        public void TestUpdater()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;

            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);

            viewData.InputData = inputParams;

            viewData.SpData.Measured.Updater(viewData.InputData);

            // Params updated?
            Assert.Equal<int>(inLength1, viewData.SpData.Measured.Length);
            Assert.Equal<double>(inLeft, viewData.SpData.Measured.Left);
            Assert.Equal<double>(inRight, viewData.SpData.Measured.Right);
            Assert.Equal<int>((int)inFunction, (int)viewData.SpData.Measured.Function);

            viewData.SpData.SplParams.Updater(viewData.InputData);

            // Parameters copied correctly?
            Assert.Equal<int>(inLength2, viewData.SpData.SplParams.UniformLength);
            Assert.Equal<double>(inx1, viewData.SpData.SplParams.x1);
            Assert.Equal<double>(inx2, viewData.SpData.SplParams.x2);
            Assert.Equal<double>(inx3, viewData.SpData.SplParams.x3);
        }

        // Can we measure?
        [Fact]
        public void TestMeasure()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            viewData.Measure();

            // Length correct?
            Assert.Equal<int>(viewData.SpData.Measured.Length, viewData.SpData.Measured.Grid.Length);

            // Assending order?
            for (int i = 1; i < viewData.SpData.Measured.Grid.Length; i++)
            {
                Assert.True(viewData.SpData.Measured.Grid[i - 1] < viewData.SpData.Measured.Grid[i]);
            }

            // Length correct?
            Assert.Equal<int>(viewData.SpData.Measured.Length, viewData.SpData.Measured.Measures.Length);

            // Collection was updated?
            Assert.NotNull(viewData.ListContents);
        }

        // Interpolates without errors?
        [Fact]
        public void TestInterpolate()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            viewData.Measure();

            Assert.Equal<double>(0, viewData.Interpolate());
        }

        // Integrates without errors?
        [Fact]
        public void TestIntegrate()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            viewData.Measure();

            Assert.Equal<double>(0, viewData.Interpolate());
            Assert.Equal<double>(0, viewData.Integrate());
        }

        // Is CanExecute working correctly
        [Fact]
        public void TestCanExecute()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            // We can't Spline without measures but we can Measure
            Assert.True(viewData.ActionMeasure_CanExecute());

            viewData.ActionMeasure(0);
            // Now we can Spline
            Assert.True(viewData.ActionSplines_CanExecute());

            viewData.ActionSplines(0);
            // Now we can't Spline
            Assert.False(viewData.ActionSplines_CanExecute());

            // We can't Measure with incorrect input
            int inLength1 = 20;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;
            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);
            viewData.InputData = inputParams;

            viewData.InputData.Length = 2; // Incorrect
            viewData.SpData.Measured.Updater(viewData.InputData);

            Assert.False(viewData.ActionMeasure_CanExecute());

            viewData.InputData.Length = 20;
            viewData.InputData.x1 = 20; // Incorrect
            viewData.SpData.SplParams.Updater(viewData.InputData);
            viewData.ActionMeasure(0);

            Assert.False(viewData.ActionSplines_CanExecute());
        }

        // Interpolate() and Integrate() resaults are used correctly in text output?
        [Fact]
        public void TestResaults()
        {
            var actions = new TestActions();
            var viewData = new ViewData(actions);

            viewData.Measure();

            viewData.ActionMeasure(0);
            viewData.ActionSplines(0);

            // Check TextBocks values
            Assert.Equal<double>(viewData.SpData.Derivatieves[0], viewData.TextBlocks.TextBlock_Der_1rst_l);
            Assert.Equal<double>(viewData.SpData.Derivatieves[1], viewData.TextBlocks.TextBlock_Der_1rst_r);
            Assert.Equal<double>(viewData.SpData.Derivatieves[2], viewData.TextBlocks.TextBlock_Der_2nd_l);
            Assert.Equal<double>(viewData.SpData.Derivatieves[3], viewData.TextBlocks.TextBlock_Der_2nd_r);
            Assert.Equal<double>(viewData.SpData.CubicSpline[0], viewData.TextBlocks.TextBlock_Spl1);
            Assert.Equal<double>(viewData.SpData.CubicSpline[viewData.SpData.Measured.Length - 1], viewData.TextBlocks.TextBlock_Spl2);
            Assert.Equal<double>(viewData.SpData.Integrals[0], viewData.TextBlocks.TextBlock_Integ1);
            Assert.Equal<double>(viewData.SpData.Integrals[1], viewData.TextBlocks.TextBlock_Integ2);
        }
    }
}