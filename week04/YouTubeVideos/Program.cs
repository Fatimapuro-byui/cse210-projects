using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Video video1 = new Video("Arepas: The Venezuelan Staple", "CocinaVenezolana", 600);
            Video video2 = new Video("Exploring Caracas", "Travel Adventures", 600);
            Video video3 = new Video("Making Pabellon Criollo", "Foodie Adventures", 900);
            Video video4 = new Video("Venezuelan Chocolate: From Bean to Bar", "ChocoConnoisseur", 720);


        
            video1.Comments.Add(new Comment("ArepaLover1", "This looks delicious!"));
            video1.Comments.Add(new Comment("Foodie2", "I need to try this!"));
            video1.Comments.Add(new Comment("HomeCook3", "My grandma used to make these."));

            
            video2.Comments.Add(new Comment("Miguel Alvarez", "Beautiful city!"));
            video2.Comments.Add(new Comment("Emily Rivas", "I'd love to visit someday."));
            video2.Comments.Add(new Comment("Traveler3", "What's the best time to travel to Caracas?"));

            
            video3.Comments.Add(new Comment("Chef1", "Awesome recipe!"));
            video3.Comments.Add(new Comment("FoodBlogger2", "I'm trying this tonight."));
            video3.Comments.Add(new Comment("FamilyCook3", "My family loves pabellón!"));

             
            video4.Comments.Add(new Comment("Chocoholic1", "This is amazing"));
            video4.Comments.Add(new Comment("ChocolateLover2", "I love the flavor."));
            video4.Comments.Add(new Comment("SweetTooth3", "Will buy some!"));

            
            List<Video> videos = new List<Video> { video1, video2, video3, video4 };

            
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
                }

                Console.WriteLine("------------------------");
            }

           Console.ReadLine();  

        }
    }
}
