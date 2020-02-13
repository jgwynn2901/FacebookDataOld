using System.Collections.Generic;
using System.Linq;
using Dapper;
using FacebookReader.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace FacebookReader.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private const string ConnectionString =
      "Host=localhost;Username=postgres;Password=great1;Database=SocialMediaArchive";
    // GET: api/Posts
    [HttpGet]
    public IEnumerable<Posts> Get()
    {
      using var connection = new NpgsqlConnection(ConnectionString);
      connection.Open();
      connection.Execute("SET search_path = \"Facebook\"");
      return connection.Query<Posts>("SELECT Id, user_id as UserId, Title, timestamp, post as PostText, uri  FROM POSTS");
    }

    // GET: api/Posts/5
    [HttpGet("{id}", Name = "Get")]
    public Posts Get(int id)
    {
      using var connection = new NpgsqlConnection(ConnectionString);
      connection.Open();
      connection.Execute("SET search_path = \"Facebook\"");
      return connection.Query<Posts>($"SELECT Id, user_id as UserId, Title, timestamp, post as PostText, uri  FROM POSTS where id = {id}").FirstOrDefault();
    }


  }
}
