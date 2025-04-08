public class Comment
{
    // Attributes
    private string _commenterName;
    private string _text;

    // Constructor
    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    // Properties
    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string Text
    {
        get { return _text; }
    }
}