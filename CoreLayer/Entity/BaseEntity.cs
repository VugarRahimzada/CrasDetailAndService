namespace CoreLayer.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int Delete { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
