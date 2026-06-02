namespace GymAppV2.Core.DTOs
{
    public class TimeSlotDto
    {
        public int Id { get; set; }
        public int GymProgramId { get; set; }
        public string ProgramName { get; set; } = string.Empty;
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class CreateTimeSlotDto
    {
        public int GymProgramId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
