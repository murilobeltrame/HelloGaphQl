using HelloGraphQl.Api.Data;

namespace HelloGraphQl.Api.Mutations.AddSpeaker
{
    public class AddSpeakerPayload
    {
        public AddSpeakerPayload(Speaker speaker)
        {
            Speaker = speaker;
        }

        public Speaker Speaker { get; }
    }
}
