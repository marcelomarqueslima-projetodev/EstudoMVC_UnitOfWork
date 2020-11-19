using EstudoMVC2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstudoMVC2.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork.UnitOfWorkApp _uow;
        public ProductController()
        {
            _uow = new UnitOfWork.UnitOfWorkApp();
        }

        public ActionResult Index()
        {
            return View(_uow.ProductRepository.FindAll());
        }

        public ActionResult Details(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _uow.ProductRepository.Add(product);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                _uow.ProductRepository.Edit(product);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _uow.ProductRepository.Remove(_uow.ProductRepository.FindById(id));
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
