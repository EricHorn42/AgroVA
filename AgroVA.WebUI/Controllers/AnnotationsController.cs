using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgroVA.WebUI.Controllers
{
    public class AnnotationsController : Controller
    {
        private readonly IAnnotationService _service;

        public AnnotationsController(IAnnotationService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var anotations = await _service.GetAllAsync();
            return View(anotations);
        }

    }
}
