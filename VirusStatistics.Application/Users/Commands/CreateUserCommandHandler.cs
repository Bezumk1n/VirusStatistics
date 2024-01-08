using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Messaging;
using VirusStatistics.Application.Users.Queries.GetUserByEmail;
using VirusStatistics.Application.Users.Queries;
using VirusStatistics.Domain.Common;
using VirusStatistics.Application.Abstractions.Data;
using VirusStatistics.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace VirusStatistics.Application.Users.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateUserCommandHandler(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            Result<Email> emailResult = Email.Create(command.Email);

            if (emailResult.IsFailure)
                return Result.Failure<Guid>(emailResult.Error);

            Email email = emailResult.Value;

            var emailExists = await _dbContext.Users
                .Include(i => i.Email)
                .FirstOrDefaultAsync(q => q.Email.Value == email.Value)
                .ConfigureAwait(true);

            if (emailExists != null)
                return Result.Failure<Guid>(UserErrors.EmailNotUniq);

            var user = User.Create(command.Name, email, command.Password);

            await _dbContext.Users.AddAsync(user).ConfigureAwait(true);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);

            return user.Id;
        }
    }
}
