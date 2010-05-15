using System.Collections.Generic;

namespace Fluent.Entities
{
    public class Plant
    {
        public virtual int Id { get; protected set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Software> Software{get;set;}
    }
}