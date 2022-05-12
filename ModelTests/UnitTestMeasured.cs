using Xunit;
using Model;
using System.Collections.ObjectModel;
using System;

namespace ModelTests
{
    public class UnitTestMeasured
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

            // Is null?
            Assert.NotNull(measured);

            // Parameters copied correctly?
            Assert.Equal<int>(inLength1, measured.Length);
            Assert.Equal<double>(inLeft, measured.Left);
            Assert.Equal<double>(inRight, measured.Right);
            Assert.Equal<int>((int)inFunction, (int)measured.Function);
        }

        // Updater works?
        [Fact]
        public void TestUpdater()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Cubic, 1, 10.5, 15.8);
            var measured = new MeasuredData(inputParams);

            int inLength1 = 25;
            int inLength2 = 10 * 10;
            double inLeft = 1;
            double inRight = 30;
            SPf inFunction = SPf.Cubic;
            double inx1 = 2;
            double inx2 = 11.5;
            double inx3 = 16.8;

            var inputParams2 = new InputParams(inLength1, inLength2, inLeft, inRight, inFunction, inx1, inx2, inx3);
            measured.Updater(inputParams2);

            // Params updated?
            Assert.Equal<int>(inLength1, measured.Length);
            Assert.Equal<double>(inLeft, measured.Left);
            Assert.Equal<double>(inRight, measured.Right);
            Assert.Equal<int>((int)inFunction, (int)measured.Function);
        }

        // Grid creates?
        [Fact]
        public void TestCreateGrid()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Cubic, 1, 10.5, 15.8);
            var measured = new MeasuredData(inputParams);
            measured.CreateGrid();

            // Length correct?
            Assert.Equal<int>(measured.Length, measured.Grid.Length);

            // Assending order?
            for(int i = 1; i < measured.Grid.Length; i++)
            {
                Assert.True(measured.Grid[i - 1] < measured.Grid[i]);
            }
        }

        // It measures?
        [Fact]
        public void TestMeasure_Linear()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Linear, 1, 10.5, 15.8);
            var measured = new MeasuredData(inputParams);
            measured.CreateGrid();
            ObservableCollection<string> resault = measured.Measure();

            // Length correct?
            Assert.Equal<int>(measured.Length, measured.Measures.Length);

            // Right calculations?
            for (int i = 0; i < measured.Grid.Length; i++)
            {
                Assert.Equal<double>(measured.Grid[i], measured.Measures[i]);
            }
        }

        // It measures?
        [Fact]
        public void TestMeasure_Cubic()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Cubic, 1, 10.5, 15.8);
            var measured = new MeasuredData(inputParams);
            measured.CreateGrid();
            ObservableCollection<string> resault = measured.Measure();

            // Length correct?
            Assert.Equal<int>(measured.Length, measured.Measures.Length);

            // Right calculations?
            for (int i = 0; i < measured.Grid.Length; i++)
            {
                Assert.Equal<double>(Math.Pow(measured.Grid[i], 3), measured.Measures[i]);
            }
        }

        // It measures?
        [Fact]
        public void TestMeasure_Random()
        {
            var inputParams = new InputParams(20, 20 * 10, 0, 20, SPf.Random, 1, 10.5, 15.8);
            var measured = new MeasuredData(inputParams);
            measured.CreateGrid();
            ObservableCollection<string> resault = measured.Measure();

            // Length correct?
            Assert.Equal<int>(measured.Length, measured.Measures.Length);

            // We cant check if calculation are right
        }
    }
}
