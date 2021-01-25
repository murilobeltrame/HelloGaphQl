using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HelloGraphQl.Api.Attributes;
using HelloGraphQl.Api.Data;
using HelloGraphQl.Api.DataLoader;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace HelloGraphQl.Api
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) => context.Speakers.ToListAsync();

        public Task<Speaker> GetSpeaker(Guid id, SpeakerByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
