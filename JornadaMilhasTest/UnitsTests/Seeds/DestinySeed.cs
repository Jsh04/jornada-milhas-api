using AutoFixture;
using AutoFixture.Kernel;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Seeds
{
    public static class DestinySeed
    {
        public static Destiny GetDestinyTest(Fixture fixture)
        {
            var fixtureCustom = CustomizeCreateDestiny(fixture);

            return fixtureCustom.Build<Destiny>().OmitAutoProperties().Create();
        }

        public static IEnumerable<Destiny> GetDestiniesByNumberOfObjects(Fixture fixture, int numberOfObjects)
        {
            var fixtureCustom = CustomizeCreateDestiny(fixture);

            return fixtureCustom.Build<Destiny>().OmitAutoProperties().CreateMany(numberOfObjects);
        }

        private static Fixture CustomizeCreateDestiny(Fixture fixture)
        {
            fixture.Customize<Destiny>(custom => custom.FromFactory(() =>
            {
                return Destiny.Create(fixture.Create<string>(), fixture.Create<string>(), fixture.Create<decimal>(), fixture.Create<string>(), fixture.Create<string>(), new List<ImagemDestino>()).Value;
            }));

            return fixture;
        }
    }
}
