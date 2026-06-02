using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public class GymProgram : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }
}
