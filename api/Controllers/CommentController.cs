using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly ApplicationDBContext _context;

        public CommentController(ICommentRepository commentRepo, ApplicationDBContext context)
        {
            _commentRepo = commentRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // get all comments
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] Comment comment)
        // {
        //     await _commentRepo.CreateAsync(comment);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction(nameof(GetAll), new { id = comment.Id }, comment);
        // }
    }




}