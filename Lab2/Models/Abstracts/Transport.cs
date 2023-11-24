namespace Lab2.Models.Abstracts
{
    public abstract class Transport
    {
        internal string Name { get; set; }
        
        internal int Speed { get; set; }
        
        internal abstract long Move(int distance);
    }
}