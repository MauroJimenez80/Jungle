using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jungle_Web.Areas.Counselor.Controllers
{
    public class TravelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TravelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: CountryController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Travel> listTravel = await _unitOfWork.Travel.GetAllAsync();
            return View(listTravel);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Travel travel = new Travel();

            if (id == null)
            {
                //CREATE
                return View(travel);
            }
            else
            {
                //EDIT
                travel = await _unitOfWork.Travel.FirstOrDefaultAsync(a => a.Id == id);

                if (travel == null)
                {
                    return NotFound();
                }
                return View(travel);
            }

        }

        //UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Travel travel)
        {
            if (ModelState.IsValid)
            {

                if (travel.Id == 0)
                {
                    _unitOfWork.Travel.AddAsync(travel);
                }
                else
                {
                    //updating
                    var objFromDb = _unitOfWork.Travel.FirstOrDefaultAsync(a => a.Id == travel.Id);

                    _unitOfWork.Travel.Update(travel);

                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(travel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _unitOfWork.Travel.GetAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var obj = await _unitOfWork.Travel.GetAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Travel.RemoveAsync(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
