using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jungle_Web.Areas.Destination.Controllers
{
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CountryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: CountryController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Country> listCountry = await _unitOfWork.Country.GetAllAsync();
            return View(listCountry);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Country country = new Country();

            if (id == null)
            {
                //CREATE
                return View(country);
            }
            else
            {
                //EDIT
                country = await _unitOfWork.Country.FirstOrDefaultAsync(a => a.Id == id);

                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            }

        }

        //UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Country country)
        {
            if (ModelState.IsValid)
            {

                if (country.Id == 0)
                {
                    _unitOfWork.Country.AddAsync(country);
                }
                else
                {
                    //updating
                    var objFromDb = _unitOfWork.Country.FirstOrDefaultAsync(a => a.Id == country.Id);

                    _unitOfWork.Country.Update(country);

                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(country);
        }


        // GET: CountryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _unitOfWork.Country.GetAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var obj = await _unitOfWork.Country.GetAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Country.RemoveAsync(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
