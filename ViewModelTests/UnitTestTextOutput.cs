using Xunit;
using ViewModel;

namespace ViewModelTests
{
    public class UnitTestTextOutput
    {
        [Fact]
        public void TestSetDefault()
        {
            var TextBlocks = new TextOutput();

            TextBlocks.TextBlock_Der_1rst_l = 1;
            TextBlocks.TextBlock_Der_1rst_r = 1;
            TextBlocks.TextBlock_Der_2nd_l = 1;
            TextBlocks.TextBlock_Der_2nd_r = 1;
            TextBlocks.TextBlock_Integ1 = 1;
            TextBlocks.TextBlock_Integ2 = 1;
            TextBlocks.TextBlock_Spl1 = 1;
            TextBlocks.TextBlock_Spl2 = 1;

            // This should make them all equal to 0
            TextBlocks.SetDefaults();

            Assert.Equal<double>(0, TextBlocks.TextBlock_Der_1rst_l);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Der_1rst_r);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Der_2nd_l);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Der_2nd_r);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Integ1);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Integ2);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Spl1);
            Assert.Equal<double>(0, TextBlocks.TextBlock_Spl2);
        }
    }
}
