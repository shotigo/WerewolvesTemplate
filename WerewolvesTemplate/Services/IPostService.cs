using System;
using System.Collections.Generic;
using TropicalTrooperTemplate.Domain;

namespace TropicalTrooperTemplate.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPostById(Guid PostId);
    }
}
