using Xunit;
using Model;

namespace ModelTests
{
    public class UnitTestSplineParams
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
            var splineParams = new SplineParameters(inputParams);

            // Is null?
            Assert.NotNull(splineParams);

            // Parameters copied correctly?
            Assert.Equal<int>(inLength2, splineParams.UniformLength);
            Assert.Equal<double>(inx1, splineParams.x1);
            Assert.Equal<double>(inx2, splineParams.x2);
            Assert.Equal<double>(inx3, splineParams.x3);
        }

        // Updater works?
        [Fact]
        public void TestUpdater()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Cubic, 1, 10.5, 15.8);
            var splineParams = new SplineParameters(inputParams);

            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;

            var inputParams2 = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);
            splineParams.Updater(inputParams2);

            // Params updated?
            Assert.Equal<int>(inLength2, splineParams.UniformLength);
            Assert.Equal<double>(inx1, splineParams.x1);
            Assert.Equal<double>(inx2, splineParams.x2);
            Assert.Equal<double>(inx3, splineParams.x3);
        }
    }
}
