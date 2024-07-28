using Business.Abstract;
using Entities.DTOs.RoomDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _roomService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _roomService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] RoomAddRequestDto roomAddRequestDto)
        {
            var result = await _roomService.AddAsync(roomAddRequestDto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] RoomUpdateRequestDto roomUpdateRequestDto)
        {
            var result = await _roomService.UpdateAsync(roomUpdateRequestDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _roomService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetRoomDetails([FromRoute] Guid id)
        {
            var result = await _roomService.GetRoomDetails(id);
            return Ok(result);
        }
    }
}
