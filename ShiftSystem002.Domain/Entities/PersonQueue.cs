namespace ShiftSystem002.Domain.Entities
{
    public class PersonQueue : Base.BaseEntity
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }
        
        public int QueueLineId { get; set; }

        public QueueLine QueueLine { get; set; }

        public Enums.Status Status { get; set; } = Enums.Status.Registered;

        public Enums.Conditions Conditions { get; set; } = Enums.Conditions.Normal;
        
        public DateTime Created { get; set; } = DateTime.Now;

        public int Turn { get; set; } = 1;
    }
}
