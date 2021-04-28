using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAPP.Mapper;
using UserAPP.Models;

namespace UserAPP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserMapper _userMapper;
        public UserController() : this(new UserMapper())
        {
        }
        
        public UserController(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }
        [HttpGet]
        public ActionResult LoadUserData()
        {
            var model = new UserViewModel();
            model = _userMapper.GetUserDataToViewModel();
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Submit(UserViewModel model)
        {
            return _userMapper.UpdateUserDataToViewModel(model);
        }

    }
}
