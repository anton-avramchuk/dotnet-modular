﻿using Dotnet.Modular.Modules.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dotnet.Modular.Modules.Identity.Services;

public class IdentityUserManager<TIdentityUser, TIdentityRole> : UserManager<TIdentityUser> where TIdentityRole : IdentityRole where TIdentityUser : IdentityUser<TIdentityRole>
{
    public IdentityUserManager(IUserStore<TIdentityUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TIdentityUser> passwordHasher, IEnumerable<IUserValidator<TIdentityUser>> userValidators, IEnumerable<IPasswordValidator<TIdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TIdentityUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }
}