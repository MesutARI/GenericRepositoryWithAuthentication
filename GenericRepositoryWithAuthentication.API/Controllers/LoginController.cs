using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Security.Models;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region variables
        private readonly IAuthenticationService authenticationService;

        #endregion

        #region LoginController
        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        #endregion

        #region Methods

        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Generic Repository with Athentication API started...");
        }
        #endregion

        #region AccessToken
        [HttpPost]
        public IActionResult AccessToken(User usr)
        {
           // if (!ModelState.IsValid)
           // {
           //     return BadRequest(ModelState.GetErrorMessages());
           // }
           // else
            string pass = Sha1Hash(usr.Password);

            GenericResponse<AccessToken> model = authenticationService.CreateAccessToken(usr.UserName, pass);

            if (model.Success)
            {
                return Ok(model.Tables);
            }
            else if (model.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(model.Message);
            else
                return BadRequest(model.Message);

        }
        #endregion

        #region RefreshToken
        [HttpPost]
        public IActionResult RefreshToken(User usr)
        {
            GenericResponse<AccessToken> model = authenticationService.CreateAccessTokenByRefreshToken(usr.RefreshToken);

            if (model.Success)
                return Ok(model.Tables);
            else if (model.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(model.Message);
            else
                return BadRequest(model.Message);
        }
        #endregion

        #region RevokeRefreshtoken
        [HttpPost]
        public IActionResult RevokeRefreshtoken(User usr)
        {
            GenericResponse<AccessToken> model = authenticationService.RevokeRefreshToken(usr.RefreshToken);

            if (model.Success)
                return Ok(model.Tables);
            else if (model.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(model.Message);
            else
                return BadRequest(model.Message);
        }
        #endregion

        #endregion

        #region sha1Hash
        private string Sha1Hash(string password)
        {
            return string.Join("", SHA1CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2"))).ToUpper();
        }
        #endregion
    }
}
