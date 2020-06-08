using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskRepository _repository;
        string email = "m.karn@gmail.com";

        /*
* Implement the below mentioned methods as per mentioned requiremetns.
*/

        // Index action method should return view along with all tasks based upon the logged in user


        // Details action method should retrieve tasks data from database based upon the logged in user and id
        // if success, return view with task details else return not found status


        // Create action method should get all categories from database based upon logged in user
        // and return view


        // Create action method should handle post request and store task details in database. 
        // If success redirect to index action method else return view with model


        // Edit action method should retrieve task details from database based upon logged in user and id
        // If success return view along with task details else return not found status

        // Edit action should handle post request and modify the task details into database.
        // If success redirect to index action method else return view with model.


        // Delete action method should retrieve task details from database based upon logged in user and id
        // If success return view with task details else return not found status

        // DeleteConfirmed action method should handle post request. Action name should be given as Delete using attribute.
        // This method should delete task details from database based upon logged in user and id then return to index

        public TasksController()
        {
            _repository = new TaskRepository();
        }
        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }
        //public TasksController()
        //{

        //}
        // GET: AllTasks
        public ActionResult Index()
        {
            try
            {
                var getAllTasks = _repository.GetAllTasks(email);
                return View(getAllTasks);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Tasks/GetTaskById/5
        public ActionResult GetTaskById(string emailid, int? id)
        {

            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var getTaskById = _repository.GetTaskById(emailid, id);
                if (getTaskById == null)
                {
                    return HttpNotFound();
                }
                return View(getTaskById);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[Route("SaveTask")]
        public ActionResult SaveTask(UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = _repository.SaveTask(userTask);
                    if (postId > 0)
                    {
                        return View(postId);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                catch (Exception)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        //[Route("DeleteTask/{id}")]
        public ActionResult DeleteTask(string emailid, int? id)
        {
            int result = 0;
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                result = _repository.DeleteTask(emailid, id);
                if (result == 0)
                {
                    return HttpNotFound();
                }
                return View(result);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
