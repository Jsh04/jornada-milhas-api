using JornadaMilhas.Core.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Builders
{
    public abstract class BaseMockBuilder<TInterface> where TInterface : class
    {
        protected readonly Mock<TInterface> _mock;
        protected BaseMockBuilder()
        {
            _mock = new Mock<TInterface>();
        }

        public abstract TInterface Build();
    }
}
