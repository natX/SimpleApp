using System.Collections.Generic;

namespace Fluent.Entities
{
    public class Software
    {
        public virtual int Id { get; protected set;}
        public virtual string PartNumber { get; set; }
        protected virtual IList<Plant> Plants{get;set;}
    }
}