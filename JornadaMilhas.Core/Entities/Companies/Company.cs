using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Companies
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string OriginCountry { get; set; }

        public DateTime DtFoundation { get; set; }


        private Company(string name, string description, string originCountry, DateTime dtFoundation)
        {
            Name = name;
            Description = description;
            OriginCountry = originCountry;
            DtFoundation = dtFoundation;
        }

        public static Result<Company> Create(string name, string description, string originCountry, DateTime dtFoundation)
        {
            var company = new Company(name, description, originCountry, dtFoundation);

            return Result.Ok(company);
        }
    }
}
