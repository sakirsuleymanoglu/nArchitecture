using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

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
            CreateMap<OperationClaim, GetListOperationClaimElementModel>();
            CreateMap<IPaginate<OperationClaim>, GetListOperationClaimQueryResponse>();
        }
    }
}
