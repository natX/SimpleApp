namespace Fluent.Entities
{
    public class Module
    {
        public virtual int Id { get; set; }
        public virtual string PartNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}