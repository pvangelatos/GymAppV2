using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;

namespace GymAppV2.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> GetAllAsync()
        {
            var members = await _memberRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            return member is null ? null : _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> CreateAsync(CreateMemberDto dto)
        {
            var member = _mapper.Map<Member>(dto);
            await _memberRepository.AddAsync(member);
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> UpdateAsync(int id, UpdateMemberDto dto)
        {
            var member = await _memberRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Member with id {id} not found.");
            _mapper.Map(dto, member);
            member.UpdatedAt = DateTime.UtcNow;
            await _memberRepository.UpdateAsync(member);
            return _mapper.Map<MemberDto>(member);
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _memberRepository.ExistAsync(id))
                throw new KeyNotFoundException($"Member with id {id} not found.");
            await _memberRepository.DeleteAsync(id);
        }
    }
}
