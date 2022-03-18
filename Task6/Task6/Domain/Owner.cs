using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Enums;
using Task6.Enums.Extensions;

namespace Task6.Domain
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public OwnerLivingEnum Living { get; set; }
        public List<Pet> Pets { get; set; }
        public override string ToString()
        {
            return "Id: " + Id + "\nName: " + FirstName + " " + LastName + "\nAge: " + 
                Age + "\n" + Living.Living();
        }
    }

    public class OwnerComparer : IEqualityComparer<Owner>
    {
        public bool Equals(Owner? x, Owner? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Owner obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
