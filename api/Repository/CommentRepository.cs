using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class CommentRepository(ApplicationDBContext context) : ICommentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FindAsync(id);
            if (commentModel != null)
            {
                _context.Comments.Remove(commentModel);
                await _context.SaveChangesAsync();
            }
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
        {
            var commentModel = await _context.Comments.FindAsync(id);
            if (commentModel == null)
            {
                return null;
            }
            commentModel.Title = commentDto.Title;
            commentModel.Content = commentDto.Content;
            // commentModel.CreatedOn = commentDto.CreatedOn;
            // commentModel.StockId = commentDto.StockId;
            await _context.SaveChangesAsync();
            return commentModel;
        }
    }
}