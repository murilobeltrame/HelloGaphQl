using System.Reflection;
using HelloGraphQl.Api.Data;
using HelloGraphQl.Api.Extensions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace HelloGraphQl.Api.Attributes
{
    public class UseApplicationDbContextAttribute: ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
