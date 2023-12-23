using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Data;
using VirusStatistics.Application.Abstractions.Messaging;
using VirusStatistics.Application.Users.Queries.GetUserById;
using VirusStatistics.Domain.Common;
using VirusStatistics.Domain.Users;

namespace VirusStatistics.Application.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetUserByEmailQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            UserResponse? user = await _dbContext.Users
                .AsNoTracking()
                .Where(q => q.Email.Value == query.Email)
                .Select(q => UserResponse.Create(q))
                .FirstOrDefaultAsync(cancellationToken);
            if (user is null)
                return Result.Failure<UserResponse>(UserErrors.NotFoundByEmail(query.Email));
            return user;
        }
    }
}
