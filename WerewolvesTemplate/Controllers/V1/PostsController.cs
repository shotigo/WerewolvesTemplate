﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TropicalTrooperTemplate.Contracts.V1;
using TropicalTrooperTemplate.Contracts.V1.Requests;
using TropicalTrooperTemplate.Contracts.V1.Responses;
using TropicalTrooperTemplate.Domain;
using TropicalTrooperTemplate.Services;

namespace TropicalTrooperTemplate.Controllers.V1
{
    public class PostsController : Controller
    {
        private IPostService _postService;
        public PostsController(IPostService postService)
        {
            this._postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }


        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if (post == null) return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { Id = postRequest.Id };

           if (post.Id != Guid.Empty) post.Id = Guid.NewGuid();
 
            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };

            return Created (locationUri, response);
        }
    }
}  