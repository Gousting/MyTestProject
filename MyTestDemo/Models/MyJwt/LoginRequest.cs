using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestDemo.Models.MyJwt
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    public class LoginRequest
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}
