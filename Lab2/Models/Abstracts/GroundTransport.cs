namespace Lab2.Models.Abstracts
{
    public abstract class GroundTransport : Transport
    {
        internal int RideTimeBeforeRest { get; set; }
        
        internal int RestTimeConst { get; set; }
    }
}