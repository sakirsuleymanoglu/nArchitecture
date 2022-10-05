using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListByUserUserOperationClaim;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserOperationClaimCommandRequest, UserOperationClaim>();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommandResponse>();
            CreateMap<UserOperationClaim, GetListByUserUserOperationClaimElementModel>()
                .ForMember(x => x.UserEmail, x => x.MapFrom(x => x.User.Email))
                .ForMember(x => x.OperationClaimName, x => x.MapFrom(x => x.OperationClaim.Name));
            CreateMap<IPaginate<UserOperationClaim>, GetListByUserUserOperationClaimQueryResponse>();
        }
    }
}
