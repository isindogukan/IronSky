using Microsoft.AspNetCore.Http;

namespace IronSky.Areas.Admin.Helpers
{
    public interface IAdminChecker
    {
        bool Check(HttpRequest request); 
    }
}