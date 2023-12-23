using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusStatistics.Application.Abstractions.Data;
using VirusStatistics.Application.Abstractions.Messaging;
using VirusStatistics.Domain.Common;
using VirusStatistics.Domain.Users;

namespace VirusStatistics.Application.Users.Queries.GetUserById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetUserByIdQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            UserResponse? user = await _dbContext.Users
                .AsNoTracking()
                .Where(q => q.Id == query.UserId)
                .Select(q => UserResponse.Create(q))
                .FirstOrDefaultAsync(cancellationToken);
            if (user is null)
                return Result.Failure<UserResponse>(UserErrors.NotFound(query.UserId));
            return user;
        }
    }
}
