using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Original.OpenBank.Service.Controllers
{
    public class BaseController : Controller
    {
        private string _token;

        public BaseController()
        {
        }

        public void SetToken(string token)
        {
            _token = token;
        }

        public string GetToken()
        {
            if (string.IsNullOrEmpty(_token))
                return HttpContext.Request.Headers["Authorization"];
            else
                return _token;
        }
    }
}
