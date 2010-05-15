using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace Fluent.Entities
{
    public class Vehicle
    {
        public virtual int Id { get; protected set; }
        public virtual string Vin { get; set; }
        public virtual int ModelYear { get; set; }
        private IList<Module> _modules = new List<Module>();
        public virtual IEnumerable<Module> Modules { get { return _modules; } }
    }
}