namespace GymAppV2.Core.DTOs
{
    public class GymProgramDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int TrainerId { get; set; }
        public string TrainerFullName { get; set; } = string.Empty;
    }

    public class CreateGymProgramDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int TrainerId { get; set; }
    }

    public class UpdateGymProgramDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
