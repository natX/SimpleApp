using Fluent.Entities;
using FluentNHibernate.Mapping;

namespace Fluent.Mappings
{
    public class SoftwareMap
        : ClassMap<Software>
    {
        public SoftwareMap()
        {
            Id(x => x.Id);
            Map(x => x.PartNumber);
        }
    }
}
