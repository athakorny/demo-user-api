using DemoAPI.Application.Command;
using DemoAPI.Application.Query;
using DemoAPI.Model;
using DemoAPI.Model.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static DemoAPI.Model.Response.GetAllUserReponseModel;

namespace DemoAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllUserCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByIdCommand { Id = id});
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand newUser)
        {
            var createdUser = await _mediator.Send(newUser);

            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateUserCommand updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest("Invalid UserId.");
            }

            var result = await _mediator.Send(updatedUser);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _mediator.Send(new DeleteUserCommand { Id = id});
            if (!deleted)
                return NotFound();

            return NoContent(); // 204 No Content
        }
    }
}
