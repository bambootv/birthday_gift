using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuVanQuaSinhNhat
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public float Money { get; set; }
        public string RelationshipFit { get; set; }
        public string GenderFit { get; set; }
        public string JobFit { get; set; }
        public string MaritalStatusFit { get; set; }
        public string Message { get; set; }
        public byte[] Image { get; set; }
        public string Color { get; set; }

        public Product(int id, string name, int minimumAge, int maximumAge, float money, string relationshipFit, string genderFit, string jobFit , string maritalStatusFit , string message, byte[] image, string color)
        {
            Id = id;
            Name = name;
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
            Money = money;
            RelationshipFit = relationshipFit;
            GenderFit = genderFit;
            JobFit = jobFit;
            MaritalStatusFit = maritalStatusFit;
            Message = message;
            Image = image;
            Color = color;
        }

        public int DateOfBirth()
        {
            return 2013;
        }
    }
}
