using System.Threading.Tasks;
using BotEventManagement.Models.API;
using BotEventManagement.Web.Api;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEventManagerApi _eventManagerApi;
        public AccountController(IEventManagerApi eventManagerApi)
        {
            _eventManagerApi = eventManagerApi;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRequest userRequest)
        {
            await _eventManagerApi.RegisterUser(userRequest);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserAuthenticationRequest userAuthenticationRequest)
        {
            var authenticatedUser = await _eventManagerApi.AuthenticateUser(userAuthenticationRequest);
            TempData["userToken"] = authenticatedUser.Token;
            TempData["userName"] = authenticatedUser.FirstName;

            return RedirectToAction("Index", "Event");
        }
        public IActionResult Logout()
        {
            TempData.Remove("userToken");
            TempData.Remove("userName");
            TempData.Remove("eventId");

            return RedirectToAction("Index", "Home");
        }
    }
}