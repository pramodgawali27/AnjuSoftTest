using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAPI.Models;

namespace UserAPI.Mappers
{
    public class UserMapper
    {
        public static UserVm GetUser()
        {
            UserVm _userVm = new UserVm();
            _userVm.FirstName = "John";
            _userVm.LastName = "Doe";
            return _userVm;
        }
    }
}