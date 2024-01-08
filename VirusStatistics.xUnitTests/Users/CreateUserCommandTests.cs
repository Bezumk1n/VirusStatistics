using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Data;
using VirusStatistics.Application.Users.Commands;
using VirusStatistics.Application.Users.Queries.GetUserByEmail;
using VirusStatistics.Domain.Common;
using VirusStatistics.Domain.Users;

namespace VirusStatistics.xUnitTests.Users
{
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommandHandler _commandHandler;
        private readonly GetUserByEmailQueryHandler _queryHandler;
        private readonly IApplicationDbContext _dbContextMock;
        public CreateUserCommandTests()
        {
            _dbContextMock = Substitute.For<IApplicationDbContext>();
            _commandHandler = new CreateUserCommandHandler(_dbContextMock);
        }
        [Fact]
        public async Task Handle_Should_ReturnError_WhentEmailIsInvalid()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand("invalid_mail", "Stanislav", "123");
            //Act
            Result result = await _commandHandler.Handle(command, default);
            //Assert
            result.Error.Should().Be(EmailErrors.InvalidFormat);
        }
        [Fact]
        public async Task Handle_Should_ReturnError_Success()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand("valid@mail.com", "Stanislav", "123");
            //Act
            Result result = await _commandHandler.Handle(command, default);
            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
