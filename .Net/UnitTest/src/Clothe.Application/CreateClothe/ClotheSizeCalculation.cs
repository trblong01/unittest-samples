using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Application.CreateClothe
{
    public class ClotheSizeCalculation
    {
        public ClotheSizeCalculation() { 
        
        }

        public string Calculate(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new InvalidDataException("Invalid height, width");
            }

            if (height <= 40 && width <= 20)
            {
                return "S";
            }

            if (height >= 80 && height  <=120 && width >= 60 && width <=100)
            {
                return "L";
            }

            if (height >= 40 && height  < 80 && width >= 20 && width <60)
            {
                return "M";
            }

            return "XXL";
        }
    }
}
