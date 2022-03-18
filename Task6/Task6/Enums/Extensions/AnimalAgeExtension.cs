using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Xml.Linq.Extensions;

namespace Task6.Enums.Extensions
{
    public static class AnimalAgeExtension
    {
        public static string Age(this AnimalAgeEnum animalAge)
        {
            switch (animalAge)
            {
                case AnimalAgeEnum.OLD: return "This animal is old";
                case AnimalAgeEnum.TEENAGER: return "This animal is a teenager";
                case AnimalAgeEnum.ADULT: return "This animal is an adult";
                case AnimalAgeEnum.BABY: return "This animal is a baby";
            }
            return "Value unknown";
        }
    }
}
