using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Enums.Extensions;

namespace Task6.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public AnimalAgeEnum Age { get; set; }
        public AnimalTypeEnum Type { get; set; }
        public override string ToString()
        {
            return "Id: " + Id + "\nName: " + Name + "\nOwnerId: " + OwnerId + 
                "\n" + Age.Age() + "\n" + Type.Type();
        }
    }

    public class PetComparer : IEqualityComparer<Pet>
    {
        public bool Equals(Pet? x, Pet? y)
        {
            return x.Age == y.Age;
        }

        public int GetHashCode([DisallowNull] Pet obj)
        {
            return obj.Age.GetHashCode();
        }
    }
}
