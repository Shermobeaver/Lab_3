using Xunit;
using Model;

namespace ModelTests
{
    public class UnitTestSplinesData
    {
        // Can construct?
        [Fact]
        public void TestConstructor()
        {
            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;

            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);
            var measured = new MeasuredData(inputParams);
            var splineParams = new SplineParameters(inputParams);
            var data = new SplinesData(measured, splineParams);

            // Is null?
            Assert.NotNull(data);

            // Parameters copied correctly?
            Assert.NotNull(data.Measured);
            Assert.NotNull(data.SplParams);

            // Internal parameters were set correctly
            Assert.Equal<int>(2, data.Integrals.Length);
            Assert.Equal<int>(4, data.Derivatieves.Length);
        }

        // Interpolates without errors?
        [Fact]
        public void TestInterpolate()
        {
            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;

            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);
            var measured = new MeasuredData(inputParams);
            var splineParams = new SplineParameters(inputParams);
            var data = new SplinesData(measured, splineParams);

            // Populate data
            data.Measured.CreateGrid();
            data.Measured.Measure();

            Assert.Equal<double>(0, data.Interpolate());
        }

        // Integrates without errors?
        [Fact]
        public void TestIntegrate()
        {
            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;

            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);
            var measured = new MeasuredData(inputParams);
            var splineParams = new SplineParameters(inputParams);
            var data = new SplinesData(measured, splineParams);

            // Populate data
            data.Measured.CreateGrid();
            data.Measured.Measure();

            Assert.Equal<double>(0, data.Interpolate());
            Assert.Equal<double>(0, data.Integrate());
        }
    }
}
