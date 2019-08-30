﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TropicalTrooperTemplate.Contracts.V1;
using TropicalTrooperTemplate.Contracts.V1.Requests;
using TropicalTrooperTemplate.Contracts.V1.Responses;
using TropicalTrooperTemplate.Domain;

namespace TropicalTrooperTemplate.Controllers.V1
{
    public class PostsController : Controller
    {
        private List<Post> _posts;

        public PostsController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Post Name {i}"
                });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }


        [HttpGet(ApiRoutes.Posts.Get )]
        public IActionResult Get()
        {
            return Ok(_posts);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { Id = postRequest.Id };

            if (string.IsNullOrEmpty(post.Id)) post.Id = Guid.NewGuid().ToString();

            _posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id);

            var response = new PostResponse { Id = post.Id };

            return Created (locationUri, response);
        }
    }
}  