namespace ShiftSystem002.Domain.Entities
{
    public class Person : Base.BaseEntity
    {
        public string DNI { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
