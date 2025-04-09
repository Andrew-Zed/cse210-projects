using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video and add comments
        Video cookingVideo = new Video("Easy 5-Minute Pasta Recipe", "FoodMaster", 325);
        cookingVideo.AddComment(new Comment("CookingEnthusiast", "This recipe saved my dinner tonight! So quick and tasty."));
        cookingVideo.AddComment(new Comment("NoviceChef", "I tried this and it was amazing. Can you do more quick recipes?"));
        cookingVideo.AddComment(new Comment("ItalianGrandma", "Not bad for a quick pasta, but try adding a pinch of oregano next time!"));
        cookingVideo.AddComment(new Comment("BusyParent", "My kids loved this! Thank you for the easy weeknight dinner idea."));
        videos.Add(cookingVideo);

        // Create second video and add comments
        Video techVideo = new Video("2025 Smartphone Comparison", "TechReviewer", 842);
        techVideo.AddComment(new Comment("GadgetFan", "Great comparison! I think I'll go with the Galaxy model based on your analysis."));
        techVideo.AddComment(new Comment("AppleFanatic", "But you didn't mention the new neural processor in the iPhone!"));
        techVideo.AddComment(new Comment("BudgetBuyer", "Are there any more affordable options you'd recommend?"));
        videos.Add(techVideo);

        // Create third video and add comments
        Video gamingVideo = new Video("Hidden Easter Eggs in Popular Games", "GamerPro", 1156);
        gamingVideo.AddComment(new Comment("RetroGamer", "I never knew about that secret level in Mario 64!"));
        gamingVideo.AddComment(new Comment("SpeedRunner", "The easter egg at 14:22 can actually be used for a major skip."));
        gamingVideo.AddComment(new Comment("GameDeveloper", "As someone who works in the industry, I can confirm these are intentional."));
        gamingVideo.AddComment(new Comment("CasualGamer", "Mind blown! Been playing these games for years and never noticed these."));
        videos.Add(gamingVideo);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.GetFormattedLength()}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("\nComments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            
            Console.WriteLine(); // Add an empty line for readability
        }
    }
}