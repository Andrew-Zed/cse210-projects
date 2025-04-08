using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video and add comments
        Video video1 = new Video("Object-Oriented Programming Basics", "CodeTeacher", 485);
        video1.AddComment(new Comment("JavaLover", "Great explanation of encapsulation!"));
        video1.AddComment(new Comment("BeginnnerCoder", "This finally helped me understand OOP, thanks!"));
        video1.AddComment(new Comment("CSStudent22", "Could you make a video on inheritance next?"));
        videos.Add(video1);

        // Create second video and add comments
        Video video2 = new Video("C# Tutorial for Beginners", "ProgrammingMaster", 732);
        video2.AddComment(new Comment("NewProgrammer", "This is exactly what I needed to get started."));
        video2.AddComment(new Comment("DevExpert", "Nice intro, but I'd add more about LINQ."));
        video2.AddComment(new Comment("CodeNewbie", "Is there a follow-up video planned?"));
        video2.AddComment(new Comment("SoftwareEngineer", "Great content as always!"));
        videos.Add(video2);

        // Create third video and add comments
        Video video3 = new Video("Building a Todo App with .NET", "AppDeveloper", 1250);
        video3.AddComment(new Comment("WebDev", "Can you show how to connect this to a database?"));
        video3.AddComment(new Comment("MobileDev", "Would this work for Xamarin too?"));
        video3.AddComment(new Comment("FullStackDev", "Very comprehensive tutorial!"));
        videos.Add(video3);


        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"\n{video.Title} by {video.Author} ({video.GetFormattedLength()})");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            
            Console.WriteLine(); // Add an empty line for readability
        }

    }
}