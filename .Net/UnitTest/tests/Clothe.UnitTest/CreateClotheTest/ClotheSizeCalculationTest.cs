using Clothes.Application.CreateClothe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Application.UnitTests.CreateClotheTest
{
    public class ClotheSizeCalculationTest
    {
        ClotheSizeCalculation ClotheSizeCalculation { get; set; }
        public ClotheSizeCalculationTest() {
            ClotheSizeCalculation = new ClotheSizeCalculation();
        }

       
        [Theory]        
        [InlineData(20,10, "S")]
        [InlineData(100, 80, "L")]
        [InlineData(50, 40, "M")]
        [InlineData(130, 110, "XXL")]
        public void Calculate_Shouldbe_OK(int height, int width, string result)
        {
            var size = ClotheSizeCalculation.Calculate(height, width);
            Assert.Equal(result, size);
        }

        [Fact]
        public void Calculate_Shouldbe_Exception()
        {
            Assert.Throws<InvalidDataException>(()=> { ClotheSizeCalculation.Calculate(0, -1); });
        }
    }
}
