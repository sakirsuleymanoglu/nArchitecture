﻿using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandRequest : IRequest, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "DeleteUserOperationClaim" };
    }
}