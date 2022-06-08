using JWT;
using JWT.Algorithms;
using JWT.Serializers;
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

            TokenInfo tokenInfo = new TokenInfo();//需要返回的口令信息

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
                    IJsonSerializer serializer = new JsonNetSerializer();//序列化Json
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64加解密
                    IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                    var token = encoder.Encode(authInfo, key);


                    tokenInfo.Success = true;
                    tokenInfo.Token = token;
                    tokenInfo.Message = "OK";
                }
                catch (Exception ex)
                {
                    tokenInfo.Success = false;
                    tokenInfo.Message = "获取Token出错:" + ex.Message;
                }


            }
            else
            {
                tokenInfo.Success = false;
                tokenInfo.Message = "用户信息为空";
            }


            return tokenInfo;

        }



    }
}
