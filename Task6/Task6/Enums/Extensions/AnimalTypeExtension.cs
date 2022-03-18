using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Enums.Extensions
{
    public static class AnimalTypeExtension
    {
        public static string Type(this AnimalTypeEnum animalType)
        {
            switch (animalType)
            {
                case AnimalTypeEnum.DOG: return "This animal is a dog";
                 case AnimalTypeEnum.HORSE: return "This animal is a horse";
                case AnimalTypeEnum.CAT: return "This animal is a cat";
            }
            return "Unknown value";
        }
    }
}
