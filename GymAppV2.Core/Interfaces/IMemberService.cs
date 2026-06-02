using System;
using System.Collections.Generic;
using System.Text;
using GymAppV2.Core.DTOs;

namespace GymAppV2.Core.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllAsync();
        Task<MemberDto?> GetByIdAsync(int id);
        Task<MemberDto> CreateAsync(CreateMemberDto dto);
        Task<MemberDto> UpdateAsync(int id, UpdateMemberDto dto);
        Task DeleteAsync(int id);
    }
}
