using System;
using Dapper;
using FacebookReader.Controllers;
using Npgsql;
using NUnit.Framework;

namespace TestFacebookReader
{
  [TestFixture]
  public class TestPosts
  {
    private NpgsqlConnection _connection;
    private const string Settings = "Host=localhost;Username=postgres;Password=great1;Database=SocialMediaArchive";

    [SetUp]
    public void Setup()
    {
      _connection = new NpgsqlConnection(Settings);
      _connection.Open();
      _connection.Execute("SET search_path = \"Facebook\"");
    }
    [Test]
    public void TestPost()
    {
      var postController = new PostsController();
      var results = postController.Get(1731);
      Assert.IsNotNull(results);
      Console.WriteLine(results.PostText);
    }
  }
}
