using AutoFixture;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;
using JornadaMilhasTest.UnitsTests.Helper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.RepositoryTests;

[TestFixture]
public class UserRepositoryTest
{
    private readonly Mock<IUserRepository> _mockRepositoryUser;
    private readonly Fixture _fixture;
    public UserRepositoryTest() 
    {
        _fixture = new Fixture();
        _mockRepositoryUser = new Mock<IUserRepository>();
    }

    [Test]
    public async Task DeverarRetornarUsuarioPeloEmailFornecido()
    {
        var email = "test@gmail.com";
        var userLimited = UnitTestHelper.GetUserLimitedTest(_fixture, email); 
        _mockRepositoryUser.Setup(repository => repository.GetByEmailAsync(email, It.IsAny<CancellationToken>())).ReturnsAsync(userLimited);

        var result = await _mockRepositoryUser.Object.GetByEmailAsync(email);

        //assert
        Assert.That(result.Email.Address, Is.EqualTo(email));
        _mockRepositoryUser.Verify(userRepositpry => userRepositpry.GetByEmailAsync(email, It.IsAny<CancellationToken>()), Times.Once());
    }
}
