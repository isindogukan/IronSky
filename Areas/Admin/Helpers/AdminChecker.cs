using  Business.Helpers;
using  Business.Services;
using  Entities;
using Microsoft.AspNetCore.Http;

namespace IronSky.Areas.Admin.Helpers
{
    public class AdminChecker : IAdminChecker
    {
        //private static AdminChecker adminChecker = new AdminChecker();

        //public static AdminChecker GetMethods()
        //{
        //    return adminChecker;
        //}

        ICookieHelper _cookieHelper;
        IUserService _userService;
        IUserTokenService _userTokenService;
        public AdminChecker(ICookieHelper cookieHelper, IUserService userService, IUserTokenService userTokenService)
        {
            _cookieHelper = cookieHelper;
            _userService = userService;
            _userTokenService = userTokenService;
        }

        public bool Check(HttpRequest request)
        {
            var token = _cookieHelper.Get(CookieTypes.admin, request);
            if (token != null)
            {
                var userId = _userTokenService.Get(token).UserId;
                var user = _userService.GetById(userId);
                if (user.IsAdmin) return true;
                return false;

            }
            return false;

        }



    }
}
