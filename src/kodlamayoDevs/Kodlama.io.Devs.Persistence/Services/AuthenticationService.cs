﻿using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application;
using Kodlama.io.Devs.Application.Exceptions.Users;
using Kodlama.io.Devs.Application.Services;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Persistence.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly RuleManager _ruleManager;

        public AuthenticationService(IAppUserRepository appUserRepository, RuleManager ruleManager)
        {
            _appUserRepository = appUserRepository;
            _ruleManager = ruleManager;
        }

        public async Task<User> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            await _ruleManager.CheckIfAlreadyExistsAsync<UserEmailAlreadyExistsException>(operation: async () =>
            {
                return await _appUserRepository.GetAsync(x => x.Email == userForRegisterDto.Email);
            });

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            AppUser user = new()
            {
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };

            return await _appUserRepository.AddAsync(user);
        }
    }
}
