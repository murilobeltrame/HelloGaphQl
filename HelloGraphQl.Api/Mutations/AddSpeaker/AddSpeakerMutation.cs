using System.Threading.Tasks;
using HelloGraphQl.Api.Data;
using HotChocolate;

namespace HelloGraphQl.Api.Mutations.AddSpeaker
{
    public class AddSpeakerMutation
    {
        public async Task<AddSpeakerPayload> AddSpeakerAsync(AddSpeakerInput input, [Service]ApplicationDbContext context)
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
