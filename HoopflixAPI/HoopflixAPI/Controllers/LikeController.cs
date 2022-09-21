﻿using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository IlikeRepository)
        {
            _likeRepository = IlikeRepository;
        }
        [HttpGet("{id}")]
        public List<Like> GetLikesFromUser(int id)
        {
            return _likeRepository.GetLikesFromUser(id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Like>> Delete(int id)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            await _likeRepository.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Like>> Create([FromBody] Like like)
        {
            var newUser = await _likeRepository.Create(like);
            return null;
        }
    }
}
