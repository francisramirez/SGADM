using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Bus;
using SGA.Application.Interfaces;
using SGA.Application.Services;

namespace SGA.Web.Controllers
{
    public class BusAdmController : Controller
    {
        private readonly IBusService _busService;

        public BusAdmController(IBusService busService)
        {
            _busService = busService;
        }
        // GET: BusAdmController
        public async Task<ActionResult> Index()
        {
           
            ServiceResult result = await _busService.GetBuses();

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }

            return View(result.Data);

           
        }

        // GET: BusAdmController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ServiceResult result = await _busService.GetBusById(id);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // GET: BusAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBusDto createBusDto)
        {
            try
            {
                ServiceResult result = await _busService.CreateBus(createBusDto);

                if (!result.Success)
                {
                    ViewBag.ErrorMessage = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusAdmController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ServiceResult result = await _busService.GetBusById(id);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // POST: BusAdmController/Edit/5-
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateBusDto updateBusDto)
        {
       

            try
            {
                updateBusDto.UsuarioActualizacion = 1; // TODO: Replace with actual user ID from session or context
                updateBusDto.FechaActualizacion = DateTime.Now;
                ServiceResult result = await _busService.UpdateBus(updateBusDto);

                if (!result.Success)
                {
                    ViewBag.ErrorMessage = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
