using JornadaMilhasTest.InterfacesTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.InterfacesTest.Helpers;

[SetUpFixture]
public class SharingResources
{
    public static TestFixture Fixture { get; set; }

    [OneTimeSetUp]
    public void ConfigurarRecurso()
    {
        Fixture = new TestFixture();
    }

    [OneTimeTearDown]
    public void LimparRecurso()
    {
        Fixture.Dispose();
    }


}
