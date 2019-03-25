using System.Threading.Tasks;
using BotEventManagement.Models.API;
using BotEventManagement.Web.Api;
using BotEventManagement.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Web.Controllers
{
    [CustomAuthorization]
    public class EventController : Controller
    {
        private readonly IEventManagerApi _eventManagerApi;

        public EventController(IEventManagerApi eventManagerApi)
        {
            _eventManagerApi = eventManagerApi;
        }
        // GET: Event
        public async Task<ActionResult> Index()
        {
            TempData.Remove("EventId");

            var events = await _eventManagerApi.GetAllEventsAsync(TempData.Peek("userToken").ToString());
            return View(events);
        }

        // GET: Event/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var specificEvent = await _eventManagerApi.GetSpecificEventAsync(id);

            TempData["EventId"] = id;

            return View(specificEvent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventRequest eventRequest)
        {
            try
            {
                await _eventManagerApi.CreateAnEventAsync(TempData.Peek("userToken").ToString(), eventRequest);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var specificEvent = await _eventManagerApi.GetSpecificEventAsync(id);
            return View(specificEvent);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EventRequest eventRequest)
        {
            try
            {
                await _eventManagerApi.UpdateAnEventAsync(id, eventRequest);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}