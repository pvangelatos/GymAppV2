using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateMemberDto
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
    }
    public class UpdateMemberDto
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
