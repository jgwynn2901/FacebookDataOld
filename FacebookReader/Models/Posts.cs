namespace FacebookReader.Models
{
  public class Posts
  {
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public int Timestamp { get; set; }
    public string PostText { get; set; }
    public string Uri { get; set; }
  }
}
