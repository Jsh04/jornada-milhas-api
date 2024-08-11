using AutoFixture;
using JornadaMilhasTest.IntegrationsTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests
{
    [SetUpFixture]
    public class SharingResources
    {
        public static Fixture AutoFixture;

        [OneTimeSetUp]
        public void InicializeObjects() 
        {
            AutoFixture = new Fixture();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            
        }
    }
}
