using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Services.Services
{
    public class UserServices : IUserServices
    {
        private UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private UserServices(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("Register Model is Null");
            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm Passwordd Doesnt Match",
                    IsSuccess = false,
                };
            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
            };
            var result = await _userManager.CreateAsync(identityUser,model.Password);
            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User Created Successfully!",
                    IsSuccess = true
                };
            }
            return new UserManagerResponse
            {
                Message = "User didnt Create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

    }
}
