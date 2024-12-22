using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BackendApi.Contracts;
using BackendApi.Contracts.User;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route (template:"api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Все пользователи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GETall /Todo
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }


        /// <summary>
        /// Поиск пользователя по id
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
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet(template:"{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                Id=result.Id,
                Email=result.Email,
                Password=result.Password,   
                CreatedAt=DateTime.Now,
            };
            return Ok(response);
        }



        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "email" : "A4Tech Bloody B188",
        ///        "password" : "!Pa$$word123@",
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {
                Email = request.Email,
                Password = request.Password,
                CreatedAt=DateTime.Now,
            };
            await _userService.Create(userDto);
            return Ok();
        }


        /// <summary>
        /// Изменение данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///        "id" : "1",
        ///        "email" : "vjt13hh",
        ///        "password" : "!Pa$$word123@",
        ///     }
        ///
        /// </remarks>
        /// <param name="id">id пользователя</param>
        /// <param name="email">логин пользователя</param>
        /// <param name="password">пароль пользователя</param>
        /// <returns></returns>

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(int id, string email, string password)
        {
            var user = await _userService.GetById(id);
            user.Email = email;
            user.Password = password;
            var response = new UpdateUserRequest()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
            };
            await _userService.Update(user);
            return Ok(response);

        }


        /// <summary>
        /// Удаление пользователя
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
        /// <param name="id">id пользователя</param>
        /// <returns></returns>

        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                Id = result.Id,
                Email = result.Email,
                Password = result.Password,
                CreatedAt = DateTime.Now,
            };
            await _userService.Delete(id);
            return Ok(response);
        }
    }
}
