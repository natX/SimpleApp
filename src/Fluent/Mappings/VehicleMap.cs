using Fluent.Entities;
using FluentNHibernate.Mapping;

namespace Fluent.Mappings
{
    public class VehicleMap
        : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id);
            Map(x => x.Vin);
            Map(x => x.ModelYear);
            HasMany(x => x.Modules)
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
}