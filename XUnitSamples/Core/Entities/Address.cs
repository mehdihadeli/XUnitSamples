namespace XUnitSamples.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}