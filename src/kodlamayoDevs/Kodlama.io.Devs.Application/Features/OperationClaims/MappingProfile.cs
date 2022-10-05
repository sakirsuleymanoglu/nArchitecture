using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;

namespace Kodlama.io.Devs.Application.Features.OperationClaims
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOperationClaimCommandRequest, OperationClaim>();
            CreateMap<OperationClaim, CreateOperationClaimCommandResponse>();
            CreateMap<UpdateOperationClaimCommandRequest, OperationClaim>();
            CreateMap<OperationClaim, GetByIdOperationClaimQueryResponse>();
        }
    }
}
