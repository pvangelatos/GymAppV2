using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public class Trainer : BaseEntity
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<GymProgram> Programs { get; set; } = new List<GymProgram>();
    }
}
