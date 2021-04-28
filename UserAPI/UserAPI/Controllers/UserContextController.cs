using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAPI.Mappers;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    public class UserContextController : ApiController
    {
        [Route("api/getuserdata")]
        public UserVm Get()
        {
            return UserMapper.GetUser();
        }
    }
}
