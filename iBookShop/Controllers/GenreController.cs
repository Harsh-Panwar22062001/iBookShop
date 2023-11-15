using iBookShop.Repositories.Abstract;  // Importing the namespace for the Genre service.
using Microsoft.AspNetCore.Mvc;       // Importing the necessary MVC framework.

using iBookShop.Models.Domain;        // Importing the namespace for the Genre model.

namespace iBookShop.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService service;   // Creating a variable to hold the Genre service.

        public GenreController(IGenreService service)
        {
            this.service = service;   // Constructor: Initializing the Genre service variable.
        }

        public IActionResult Index()
        {
            return View();  // Action: Display the main page for genres (view).
        }

        [HttpPost]  // Attribute indicating this action responds to HTTP POST requests.
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)   // Checking if the submitted data (model) is valid.
            {
                return View();   // If not valid, return to the same view (likely to show validation errors).
            }

            var result = service.Add(model);  // Call the service to add a genre based on the provided model.

            if (result)
            {
                TempData["msg"] = "Added Successfully";  // If the addition is successful, show a success message.
                return RedirectToAction(nameof(Add));  // Redirect to the "Add" action (likely for adding more genres).
            }

            TempData["msg"] = "Error has occurred on the server side";  // If there's an error, show an error message.

            return View(model);  // Return to the same view (likely to display an error message).
        }

        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);  // Action: Display the main page for genres (view).
        }


        [HttpPost]
        public IActionResult Update(Genre model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = service.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));


            }
            TempData["msg"] = "Error has occured on server side";

            return View(model);
        }

        


       
        public IActionResult Delete(int id)
        {



            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {



            var data = service.GetAll();
            return View(data);
        }

    }
}
