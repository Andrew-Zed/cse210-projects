public class Comment
{
    // Attributes
    private string _commenterName;
    private string _commentText;

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Properties
    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string CommentText
    {
        get { return _commentText; }
    }
}