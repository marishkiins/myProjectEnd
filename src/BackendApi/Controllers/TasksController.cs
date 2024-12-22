using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BackendApi.Contracts;
using BackendApi.Contracts.User;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using BusinessLogic.Services;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BackendApi.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private ITasksService _taskService;
        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Все задачи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GETall /Todo
        ///
        /// </remarks>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _taskService.GetAll());
        }

        /// <summary>
        /// Поиск задачи по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GETbyId /Todo
        ///     {
        ///        "id" : "1"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _taskService.GetById(id);
            var response = new GetTaskResponse()
            {
                Id = result.Id,
                description = result.Description,
                deadline = result.Deadline,
            };
            return Ok(response);
        }



        /// <summary>
        /// Создание новой задачи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "UserId" : "1",
        ///        "TypeId" : "1",
        ///        "PriorityId" : "1",
        ///        "StatusId" : "1",
        ///        "SubjectId" : "1",
        ///        "CategoryId" : "1",
        ///        "Description" : "Description",
        ///        "Deadline" : "01.01.2030",
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTaskRequest request)
        {
            var taskDto = new Domain.Models.Task()
            {
                UserId = request.userId,
                TypeId = request.typeId,
                PriorityId = request.priorityId,
                StatusId = request.statusId,
                SubjectId = request.subjectId,
                CategoryId = request.categoryId,
                Description = request.description,
                Deadline = request.deadline,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await _taskService.Create(taskDto);
            return Ok();
        }



        /// <summary>
        /// Изменение данных задач
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///        "userId" : "1",
        ///        "TypeId" : "1",
        ///        "PriorityId" : "1",
        ///        "StatusId" : "1",
        ///        "SubjectId" : "1",
        ///        "CategoryId" : "1",
        ///        "Description" : "Description",
        ///        "Deadline" : "01.01.2030",
        ///     }
        ///
        /// </remarks>
        /// <param name="id">id задачи</param>
        /// <param name="userId">id пользователя</param>
        /// <param name="typeId">id типа задачи</param>
        /// <param name="priorityId">id приоритета задачи</param>
        /// <param name="statusId">id статуса задачи</param>
        /// <param name="subjectId">id предмета</param>
        /// <param name="categoryId">id</param>
        /// <param name="description"></param>
        /// <param name="deadline"></param>
        /// <returns></returns>

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(int id, int userId, int typeId, int priorityId, int statusId, int subjectId, int categoryId, string description, DateTime deadline)
        {
            var task = await _taskService.GetById(id);
            task.UserId = userId;
            task.TypeId = typeId;
            task.PriorityId = priorityId;
            task.StatusId = statusId;
            task.SubjectId = subjectId;
            task.CategoryId = categoryId;
            task.Description = description;
            task.Deadline = deadline;
            var response = new UpdateTaskRequest()
            {
                userId = task.UserId,
                typeId = task.TypeId,
                priorityId = task.PriorityId,
                statusId = task.StatusId,
                subjectId = task.SubjectId,
                categoryId = task.CategoryId,
                description = task.Description,
                deadline = task.Deadline,
                createdAt = task.CreatedAt,
                updatedAt = DateTime.Now,
            };
            await _taskService.Update(task);
            return Ok(response);

        }


        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     DELETE /Todo
        ///     {
        ///         "id" : "1",
        ///        "email" : "A4Tech Bloody B188",
        ///        "password" : "!Pa$$word123@",
        ///     }
        ///
        /// </remarks>
        /// <param name="id">id задачи</param>
        /// <returns></returns>

        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.GetById(id);
            var response = new GetTaskResponse()
            {
                Id = result.Id,
                description = result.Description,
                deadline = result.Deadline,
            };
            await _taskService.Delete(id);
            return Ok(response);
        }
    }
}
