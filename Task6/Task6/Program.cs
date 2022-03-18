using System.Linq;
using Task6.Domain;

namespace Task6
{
    public class Program
    {
        private static IEnumerable<Owner> _owners = CreateOwners();
        private static IEnumerable<Pet> _pets = CreatePets();
        public static void Main(string[] args)
        {
        }

        private static void Filtering()
        {
            var ownersWithAgeGreaterThan25 = _owners.Where(x => x.Age > 25);
            var first2Pets = _pets.Take(2);
            var petsButFirst2 = _pets.Skip(2);
            var petsUntilFirstTeenager = _pets.TakeWhile(x => x.Age != AnimalAgeEnum.TEENAGER);
            var petsIgnoredUntilFirstTeenager = _pets.SkipWhile(x => x.Age != AnimalAgeEnum.TEENAGER);
            var comparerPet = new PetComparer();
            var petsWithUniqueAge = _pets.Distinct(comparerPet);
        }

        private static void Projection()
        {
            var ownersWithNameStartingWithP = _owners.Select(x => x.LastName.StartsWith("P"));
            var ownersPets = _owners.SelectMany(x => x.Pets);
        }

        private static void Joins()
        {
            var ownersByPets = from pet in _pets
                               join owner in _owners
                               on pet.OwnerId equals owner.Id
                               select new { PetName = pet.Name, OwnerFirstName = owner.FirstName, OwnerLastName = owner.LastName };
            var petsByOwners = from owner in _owners
                               join pet in _pets
                               on owner.Id equals pet.OwnerId into pets
                               select new { OwnerFirstName = owner.FirstName, Pets = pets };
        }

        private static void Ordering()
        {
            var ownersOrderedByLastNameThenByFirstName = _owners.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            var ownersOrderedByNumbersOfPetsThenByAge = _owners.OrderByDescending(x => x.Pets.Capacity).ThenByDescending(x => x.Age);
            var petsReversed = _pets.Reverse();
        }

        private static void Grouping()
        {
            var petsGroupedByAge = _pets.GroupBy(x => x.Age);
        }

        private static void SetOperators()
        {
            var newOwners = new List<Owner>()
            {
                new Owner()
                {
                    Id = 1,
                    FirstName = "Ana",
                    LastName = "Popescu",
                    Age = 22,
                    Living = OwnerLivingEnum.SHARINGROOM,
                    Pets = new List<Pet>()
                }                
            };
            var ownersConcatenated = _owners.Concat(newOwners);
            var ownersUnique = _owners.Union(newOwners, new OwnerComparer());
            var duplicatedOwners = _owners.Intersect(newOwners, new OwnerComparer());
            var nonDuplicatedOwners = _owners.Except(newOwners, new OwnerComparer());
        }

        private static void ConversionMethods()
        {
            var workingOwners = _owners.OfType<WorkingOwner>();
            var ownersDowncast = _owners.AsEnumerable();
            var ownersArray = _owners.ToArray();
            var ownersList = _owners.ToList();
            var ownersDictionary = _owners.ToDictionary(x => x.Id, x => x);
            var ownersLookup = _owners.ToLookup(x => x.Id);
            var castToWorkingOwners = workingOwners.AsEnumerable<Owner>();
            var ownersQuery = _owners.AsQueryable();
        }

        private static void ElementOperators()
        {
            var firstPet = _pets.First();
            var firstPetDefault = _pets.FirstOrDefault();
            var lastOwner = _owners.Last();
            var lastOwnerDefault = _owners.FirstOrDefault();
            try
            {
                var singlePet = _pets.Single();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                var singlePetDefault = _pets.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var secondPet = _pets.ElementAt(1);
            var secondPetDefault = _pets.ElementAtOrDefault(2);
            var empty = _pets.DefaultIfEmpty();
        }

        private static void AggregationMethods()
        {
            var ownersCount = _owners.Count();
            var ownersMinimumAge = _owners.Min(x => x.Age);
            var ownersMaximumAge = _owners.Max(x => x.Age);
            var ownersAverageAge = _owners.Average(x => x.Age);
            var ownersSumAge = _owners.Sum(x => x.Age);
            var ownersAggregateByLastName = _owners.Aggregate((x, y) => new Owner
            {
                FirstName = x.FirstName,
                LastName = y.LastName
            });
        }

        private static void Quantifiers()
        {
            var teenagerPetExits = _pets.Contains(new Pet
            {
                Age = AnimalAgeEnum.TEENAGER
            });
            var ownersOver25YearsExists = _owners.Any(x => x.Age > 25);
            var allOwnersOver25Years = _owners.All(x => x.Age > 25);
            var copyOwners = _owners;
            var identicalOwners = _owners.SequenceEqual(copyOwners);
        }

        private static void GenerationMethods()
        {
            var emptyString = Enumerable.Empty<string>();
            var repeating0Integer = Enumerable.Repeat(0, 10);
            var first100Integers = Enumerable.Range(0, 100);
        }

        private static IEnumerable<Owner> CreateOwners()
        {
            yield return new Owner
            {
                Id = 1,
                FirstName = "Ana",
                LastName = "Popescu",
                Age = 22,
                Living = OwnerLivingEnum.SHARINGROOM,
                Pets = new List<Pet>()
                {
                    new Pet
                    {
                        Id = 1,
                        Name = "Bob",
                        Type = AnimalTypeEnum.DOG,
                        Age = AnimalAgeEnum.BABY,
                        OwnerId = 1
                    },
                    new Pet
                    {
                        Id = 5,
                        Name = "Rex",
                        Type = AnimalTypeEnum.DOG,
                        Age = AnimalAgeEnum.ADULT,
                        OwnerId = 1
                    }
                }
            };

            yield return new WorkingOwner
            {
                Id = 2,
                FirstName = "Maria",
                LastName = "Popa",
                Age = 25,
                Living = OwnerLivingEnum.APARTMENT,
                Pets= new List<Pet>()
                {
                    new Pet
                    {
                        Id = 2,
                        Name = "Luna",
                        Type = AnimalTypeEnum.DOG,
                        Age = AnimalAgeEnum.TEENAGER,
                        OwnerId = 2
                    },
                    new Pet
                    {
                        Id = 4,
                        Name = "Calipso",
                        Type = AnimalTypeEnum.HORSE,
                        Age = AnimalAgeEnum.OLD,
                        OwnerId = 2
                    }
                },
                HoursWorked = 40
            };

            yield return new Owner
            {
                Id = 3,
                FirstName = "Andrei",
                LastName = "Marcu",
                Age = 30,
                Living = OwnerLivingEnum.HOUSE,
                Pets = new List<Pet>()
                {
                    new Pet
                    {
                        Id = 3,
                        Name = "Pepi",
                        Type = AnimalTypeEnum.CAT,
                        Age = AnimalAgeEnum.TEENAGER,
                        OwnerId = 3
                    }
                }
            };
        }

        private static IEnumerable<Pet> CreatePets()
        {
            yield return new Pet
            {
                Id = 1,
                Name = "Bob",
                Type = AnimalTypeEnum.DOG,
                Age = AnimalAgeEnum.BABY,
                OwnerId = 1
            };

            yield return new Pet
            {
                Id = 2,
                Name = "Luna",
                Type = AnimalTypeEnum.DOG,
                Age = AnimalAgeEnum.TEENAGER,
                OwnerId = 2
            };

            yield return new Pet
            {
                Id = 3,
                Name = "Pepi",
                Type = AnimalTypeEnum.CAT,
                Age = AnimalAgeEnum.TEENAGER,
                OwnerId = 3
            };

            yield return new Pet
            {
                Id = 4,
                Name = "Calipso",
                Type = AnimalTypeEnum.HORSE,
                Age = AnimalAgeEnum.OLD,
                OwnerId = 2
            };

            yield return new Pet
            {
                Id = 5,
                Name = "Rex",
                Type = AnimalTypeEnum.DOG,
                Age = AnimalAgeEnum.ADULT,
                OwnerId = 1
            };
        }
    }
}
