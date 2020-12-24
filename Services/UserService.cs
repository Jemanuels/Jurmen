using Jurmen.Constants;
using Jurmen.Models;
using Jurmen.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurmen.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;



        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            IDictionary<string, object> value = new Dictionary<string, object>();

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var userWithSameEmail = await _userManager.FindByNameAsync(model.Email);
            if(userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Authorization.default_role.ToString());
                    return $"User Registered with username {user.UserName}";
                }
                else
                {
                    value["ErrorMessage"] = result.Errors;
                    return JsonConvert.SerializeObject(value);
                }
            }
            else
            {
                return $"Email {user.Email} is already registered.";
            }
        }
    }
}
