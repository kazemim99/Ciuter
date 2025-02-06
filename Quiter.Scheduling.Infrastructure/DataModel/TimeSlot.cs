namespace Quiter.Scheduling.Infrastructure.DataModel
{
    public class TimeSlot : IEquatable<TimeSlot>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Equals(TimeSlot? other)
        {
            if (ReferenceEquals(null, other)) return false;
            return StartTime == other.StartTime && EndTime == other.EndTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartTime, EndTime);
        }
    }
}
