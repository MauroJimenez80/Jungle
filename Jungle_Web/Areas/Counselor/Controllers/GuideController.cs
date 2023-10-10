using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jungle_Web.Areas.Counselor.Controllers
{
    public class GuideController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GuideController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: GuideController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Guide> listGuide = await _unitOfWork.Guide.GetAllAsync();
            return View(listGuide);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Guide guide = new Guide();

            if (id == null)
            {
                //CREATE
                return View(guide);
            }
            else
            {
                //EDIT
                guide = await _unitOfWork.Guide.FirstOrDefaultAsync(a => a.Id == id);

                if (guide == null)
                {
                    return NotFound();
                }
                return View(guide);
            }

        }

        //UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Guide guide)
        {
            if (ModelState.IsValid)
            {

                if (guide.Id == 0)
                {
                    _unitOfWork.Guide.AddAsync(guide);
                }
                else
                {
                    //updating
                    var objFromDb = _unitOfWork.Country.FirstOrDefaultAsync(a => a.Id == guide.Id);

                    _unitOfWork.Guide.Update(guide);

                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(guide);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _unitOfWork.Guide.GetAsync(id);
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
            var obj = await _unitOfWork.Guide.GetAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Guide.RemoveAsync(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
