using System;
using System.Collections.Generic;
using System.Linq;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class TaskRepository:ITaskRepository
    {
        readonly TaskDbContext context;
        public TaskRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to delete task details from database based upon user's email & task id
        public int DeleteTask(string email, int? taskId)
        {
            int result = 0;
            try
            {

                var taskToDelete = context.Categories.FirstOrDefault(x => x.CategoryID == taskId);
                if (taskToDelete != null)
                {
                    context.Categories.Remove(taskToDelete);
                    result = context.SaveChanges();
                    return result;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // This method should be used to get all task details from database based upon user's email
        public IReadOnlyList<UserTask> GetAllTasks(string email)
        {
            if (context != null)
            {
                var getAllTasks = context.UserTasks.ToList();

                return getAllTasks;
            }
            return null;
        }

        // This method should be used to get task details from database based upon user's email and task id
        public UserTask GetTaskById(string email, int? taskId)
        {
            if (context != null)
            {
                var result = context.UserTasks.Find(taskId);

                return result;
            }
            return null;
        }

        // This method should be used to save task details into database 
        public int SaveTask(UserTask task)
        {
            if (context != null)
            {
                context.UserTasks.Add(task);
                context.SaveChangesAsync();
                return task.TaskId;
            }
            return 0;
        }

        // This method should be used to update task details into database
        public int UpdateTask(UserTask task)
        {
            return 0;
        }
    }
}