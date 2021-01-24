using System;
using System.Linq;
using HelloGraphQl.Api.Data;
using HotChocolate;

namespace HelloGraphQl.Api
{
    public class Query
    {
        public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) => context.Speakers;
    }
}
