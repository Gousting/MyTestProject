using JWT.Algorithms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTestDemo.Models.MyJwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyTestDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public TokenInfo Login(LoginRequest loginRequest)
        {

            TokenInfo token = new TokenInfo();//需要返回的口令信息

            if (loginRequest != null)
            {
                string userName = loginRequest.UserName;
                string passWord = loginRequest.PassWord;

                bool isAdmin = (userName == "admin") ? true : false;

                //身份验证操作
                //TODO

                AuthInfo authInfo = new AuthInfo()
                {
                    UserName = userName,
                    Roles = new List<string> { "admin", "commonrole" },
                    IsAdmin = isAdmin,
                    ExpiryDateTime = DateTime.Now.AddHours(2)
                };


                const string secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";//口令加密秘钥


                try
                {
                    byte[] key = Encoding.UTF8.GetBytes(secretKey);

                    IJwtAlgorithm algorithm = new RS512Algorithm(RSA.Create());///加密方式

                }
                catch (Exception ex)
                {

                }

            }



            return token;

        }
    }
}
