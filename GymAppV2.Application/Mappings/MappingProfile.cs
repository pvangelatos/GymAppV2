using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;

namespace GymAppV2.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Member
            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Trainer
            CreateMap<Trainer, TrainerDto>();
            CreateMap<CreateTrainerDto, Trainer>();
            CreateMap<UpdateTrainerDto, Trainer>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // GymProgram
            CreateMap<GymProgram, GymProgramDto>()
                .ForMember(d => d.TrainerFullName,
                    o => o.MapFrom(s => s.Trainer != null ? $"{s.Trainer.Firstname} {s.Trainer.Lastname}" : string.Empty));
            CreateMap<CreateGymProgramDto, GymProgram>();
            CreateMap<UpdateGymProgramDto, GymProgram>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // TimeSlot
            CreateMap<TimeSlot, TimeSlotDto>()
                .ForMember(d => d.ProgramName,
                    o => o.MapFrom(s => s.GymProgram != null ? s.GymProgram.Name : string.Empty));
            CreateMap<CreateTimeSlotDto, TimeSlot>();

            // Booking
            CreateMap<Booking, BookingDto>()
                .ForMember(d => d.MemberFullName,
                    o => o.MapFrom(s => s.Member != null ? $"{s.Member.Firstname} {s.Member.Lastname}" : string.Empty))
                .ForMember(d => d.ProgramName,
                    o => o.MapFrom(s => s.TimeSlot != null && s.TimeSlot.GymProgram != null
                        ? s.TimeSlot.GymProgram.Name : string.Empty));
            CreateMap<CreateBookingDto, Booking>();

            // Subscription
            CreateMap<Subscription, SubscriptionDto>()
                .ForMember(d => d.MemberFullName,
                    o => o.MapFrom(s => s.Member != null ? $"{s.Member.Firstname} {s.Member.Lastname}" : string.Empty))
                .ForMember(d => d.PlanName,
                    o => o.MapFrom(s => s.Plan != null ? s.Plan.Name : string.Empty));
            CreateMap<CreateSubscriptionDto, Subscription>();

            // SubscriptionPlan
            CreateMap<SubscriptionPlan, SubscriptionPlanDto>();
            CreateMap<CreateSubscriptionPlanDto, SubscriptionPlan>();
            CreateMap<UpdateSubscriptionPlanDto, SubscriptionPlan>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Payment
            CreateMap<Payment, PaymentDto>();
            CreateMap<CreatePaymentDto, Payment>();
        }
    }
}
