using System.Threading.Tasks;
using HelloGraphQl.Api.Attributes;
using HelloGraphQl.Api.Data;
using HotChocolate;

namespace HelloGraphQl.Api.Mutations.AddSpeaker
{
    public class AddSpeakerMutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(AddSpeakerInput input, [ScopedService]ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            await context.Speakers.AddAsync(speaker);
            await context.SaveChangesAsync();
            return new AddSpeakerPayload(speaker);
        }
    }
}
