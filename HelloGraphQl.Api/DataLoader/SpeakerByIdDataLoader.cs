using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HelloGraphQl.Api.Data;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace HelloGraphQl.Api.DataLoader
{
    public class SpeakerByIdDataLoader: BatchDataLoader<Guid, Speaker>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public SpeakerByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory): base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Speaker>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using var context = _dbContextFactory.CreateDbContext();
            return await context.Speakers
                .Where(w => keys.Contains(w.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
