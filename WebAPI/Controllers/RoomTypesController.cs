using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs.RoomTypeDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _roomTypeService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var response = await _roomTypeService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] RoomTypeAddRequestDto requestDto)
        {
            var response = await _roomTypeService.AddAsync(requestDto);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] RoomTypeUpdateRequestDto requestDto)
        {
            var response = await _roomTypeService.UpdateAsync(requestDto);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var response = await _roomTypeService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
