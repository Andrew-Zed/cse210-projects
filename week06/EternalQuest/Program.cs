using System;

class Program
{

    /*
    * EXCEEDING REQUIREMENTS:
    * -----------------------
    * 
    * 1. Added a Gamification System:
    *    - Implemented a leveling system where users gain levels based on their points (every 1000 points)
    *    - Created an achievements system that awards special badges for various accomplishments:
    *      - First Step: Completing your first goal
    *      - Dedicated Quester: Reaching level 5
    *      - Goal Master: Reaching level 10
    *      - Milestone: Earning 5000 points
    *    - Added special effects for level-ups and achievements with celebratory messages
    * 
    * 2. Added a New Goal Type: Progressive Goals
    *    - These allow for incremental progress toward a large target
    *    - Users record specific amounts of progress (e.g., ran 2 miles toward a marathon)
    *    - Points are awarded proportionally to progress made
    *    - Shows percentage completion to motivate user
    *    - Provides a completion bonus when the target is reached
    * 
    * 3. Enhanced User Experience:
    *    - Added a dedicated view for player information and achievements
    *    - Designed better feedback with congratulatory messages
    *    - Improved progress visualization with percentages
    */

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Program.");

         // Create a new goal manager and start the program
        GoalManager manager = new GoalManager();
        manager.Start();
        
        Console.WriteLine("Thank you for using the Eternal Quest Program!");

    }
}