using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelloGraphQl.Api.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<T>(this IObjectFieldDescriptor descriptor) where T: DbContext
        {
            return descriptor.UseScopedService(
                create: s => s.GetRequiredService<IDbContextFactory<T>>().CreateDbContext(),
                disposeAsync: (s, c) => c.DisposeAsync());
        }
    }
}
