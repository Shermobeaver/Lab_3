using Xunit;
using Model;
using System;

namespace ModelTests
{
    public class UnitTestInputParams
    {
        // Can construct?
        [Fact]
        public void TestConstructor()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Cubic, 1, 10.5, 15.8);

            Assert.NotNull(inputParams);
        }

        // Are values set correctly and can we get them?
        [Fact]
        public void TestValuesSet()
        {
            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 0;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 1;
            double inx2 = 10.5;
            double inx3 = 15.8;

            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);

            Assert.Equal<int>(inLength1, inputParams.Length);
            Assert.Equal<int>(inLength2, inputParams.UniformLength);
            Assert.Equal<double>(inLeft, inputParams.Left);
            Assert.Equal<double>(inRight, inputParams.Right);
            Assert.Equal<int>((int)inFunction, (int)inputParams.Function);
            Assert.Equal<double>(inx1, inputParams.x1);
            Assert.Equal<double>(inx2, inputParams.x2);
            Assert.Equal<double>(inx3, inputParams.x3);
        }

        // Are incorrect values causing us to set Error variables?
        [Fact]
        public void TestIncorrectValues()
        {
            int inLength1 = 20;
            int inLength2 = 10 * 10;
            double inLeft = 0;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 1;
            double inx2 = 10.5;
            double inx3 = 15.8;

            var inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);

            inputParams.Length = 2;
            Assert.True(inputParams.Error1);

            inputParams.Length = 3;
            Assert.False(inputParams.Error1);

            inputParams.Left = 40;
            Assert.True(inputParams.Error1);

            inputParams.Right = -1;
            Assert.True(inputParams.Error1);

            inputParams.UniformLength = 2;
            Assert.True(inputParams.Error2);

            inputParams.UniformLength = 3;
            Assert.False(inputParams.Error2);

            inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);

            inputParams.x1 = -1;
            Assert.True(inputParams.Error2);

            inputParams.x2 = -2;
            Assert.True(inputParams.Error2);

            inputParams.x3 = -3;
            Assert.True(inputParams.Error2);

            inputParams = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);

            inputParams.x1 = 1;
            Assert.False(inputParams.Error2);

            inputParams.x2 = 5;
            Assert.False(inputParams.Error2);

            inputParams.x3 = 10;
            Assert.False(inputParams.Error2);
        }
    }
}