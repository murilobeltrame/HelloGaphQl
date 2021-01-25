using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HelloGraphQl.Api.Data;
using HelloGraphQl.Api.DataLoader;
using HelloGraphQl.Api.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace HelloGraphQl.Api.Types
{
    public class SpeakerType : ObjectType<Speaker>
    {
        protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
        {
            descriptor
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");
        }

        private class SpeakerResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(Speaker speaker, [ScopedService] ApplicationDbContext context, SessionByIdDataLoader sessionByIdDataLoader, CancellationToken cancellationToken)
            {
                var sessionIds = await context.Speakers
                    .Where(w => w.Id == speaker.Id)
                    .Include(i => i.SessionSpeakers)
                    .SelectMany(s => s.SessionSpeakers.Select(ss => ss.SessionId))
                    .ToArrayAsync();
                return await sessionByIdDataLoader.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}
