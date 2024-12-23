using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepository;
        private readonly ApplicationDBContext _context;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepository, ApplicationDBContext context)
        {
            _commentRepo = commentRepo;
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentDto)
        // {
        //     var commentModel = commentDto.ToCommentFromCreateDTO();
        //     await _commentRepo.CreateAsync(commentModel);
        //     return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        // }
        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentRequestDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _stockRepository.StockExists(stockId))
            {
                return BadRequest("Stock not found.");
            }

            var commentModel = commentDto.ToCommentFromCreateDTO(stockId);
            commentModel.StockId = stockId;
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var commentModel = await _commentRepo.UpdateAsync(id, comment);
            if (commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var commentModel = await _commentRepo.DeleteAsync(id);
            if (commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
        }
    }




}