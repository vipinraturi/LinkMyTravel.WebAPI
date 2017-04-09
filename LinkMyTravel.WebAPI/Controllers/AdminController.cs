using LinkMyTravel.WebAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkMyTravel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> _userManager;
        public AdminController(UserManager<AppUser> usrMgr)
        {
            _userManager = usrMgr;
        }

        [HttpGet]
        public async Task<ResultSet<AppUser>> GetAll()
        {
            var response = new ResultSet<AppUser>();

            try
            {
                var items =  _userManager.Users;
                if (items == null)
                {
                    response.DidError = false;
                    response.Message = "No result to return";
                }
                else
                {
                    response.List = items;
                }

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        public async Task<ResultSet<AppUser>> Create([FromBody] AppUser item)
        {
            var response = new ResultSet<AppUser>();

            if (item == null)
            {
                response.DidError = true;
                response.ErrorMessage = "Cannot pass null value";
            }

            try
            {
                IdentityResult result = await _userManager.CreateAsync(item);
                if (result.Errors != null )
                {
                    response.DidError = true;
                    foreach (var itemInternal in result.Errors)
                    {
                        response.ErrorMessage = itemInternal.Description;
                    }
                }
                else
                {
                    response.Message = "Inserted Successfully!";
                    response.DidError = false;
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response;
        }


        [HttpPut()]
        public async Task<ResultSet<AppUser>> Update([FromBody] AppUser item)
        {
            var response = new ResultSet<AppUser>();

            if (item == null)
            {
                response.DidError = true;
                response.ErrorMessage = "Cannot pass null value";
            }

            try
            {
                AppUser currentUser = await _userManager.FindByIdAsync(item.Id);
                IdentityResult result = await _userManager.UpdateAsync(currentUser);
                if (result.Errors != null)
                {
                    response.DidError = true;
                    foreach (var itemInternal in result.Errors)
                    {
                        response.ErrorMessage = itemInternal.Description;
                    }
                }
                else
                {
                    response.Message = "Updated Successfully!";
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            
            return response;
        }


        [HttpDelete()]
        public async Task<ResultSet<AppUser>> Delete([FromBody] AppUser item)
        {
            var response = new ResultSet<AppUser>();

            if (item == null)
            {
                response.DidError = true;
                response.ErrorMessage = "Cannot pass null value";
            }

            try
            {
                AppUser currentUser = await _userManager.FindByIdAsync(item.Id);
                IdentityResult result = await _userManager.DeleteAsync(currentUser);

                if (result.Errors != null)
                {
                    response.DidError = true;
                    foreach (var itemInternal in result.Errors)
                    {
                        response.ErrorMessage = itemInternal.Description;
                    }
                }
                else
                {
                    response.Message = "Deleted Successfully!";
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response;
        }
    }
}
