using ApplicationForm.Application.Models;
using ApplicationForm.Domain.Entities;
using AutoMapper;

namespace ApplicationForm.Application
{
    public class ApplicationFormProfile
    {
        public class ContactProfile : Profile
        {
            public ContactProfile()
            {
              
                CreateMap<Question, QuestionDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
                CreateMap<QuestionDTO, Question>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
                CreateMap<AdditionalQuestionDTO, AdditionalQuestion>().ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question)).ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));
                CreateMap<AdditionalQuestion, AdditionalQuestionDTO>().ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question)).ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));
                CreateMap<CandidateInfoDTO, CandidateInfo>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName)).ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)).ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ForMember(dest => dest.IDNumber, opt => opt.MapFrom(src => src.IDNumber)).ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)).ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone)).ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality)).ForMember(dest => dest.CurrentResidence, opt => opt.MapFrom(src => src.CurrentResidence)).ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth)).ForMember(dest => dest.AdditionalQuestions, opt => opt.MapFrom(src => src.AdditionalQuestions));
                CreateMap<CandidateInfo, CandidateInfoDTO>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName)).ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)).ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ForMember(dest => dest.IDNumber, opt => opt.MapFrom(src => src.IDNumber)).ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)).ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone)).ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality)).ForMember(dest => dest.CurrentResidence, opt => opt.MapFrom(src => src.CurrentResidence)).ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth)).ForMember(dest => dest.AdditionalQuestions, opt => opt.MapFrom(src => src.AdditionalQuestions));
            }
        }
    }
}
