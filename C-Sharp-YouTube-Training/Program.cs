using System;
using System.Collections.Generic;
using System.Text;


namespace Answer_Question_GAME
{
    class Program
    {
        static void Main(string[] args)
        {

            bool startOver = true;
            Console.WriteLine("Welcome to the guessing game ");


            while (startOver == true)
            {
                Console.Write("Are you ready to play? ");
                string startQuestion = Console.ReadLine();

                switch (startQuestion.ToLower())
                {
                    case "y":
                        Console.WriteLine("congratulations you are ready to play");
                        startOver = false;
                        StartGame();
                        break;

                    case "n":
                        Console.WriteLine("the game will be terminated");
                        startOver = false;
                        break;

                    default:
                        Console.WriteLine("You did not type in Y or N, please try again");
                        break;
                }
            }
        }
        static void StartGame()
        {
            Console.Clear();
            Console.Write("What is your name? ");
            string firstName = Console.ReadLine();
            int points = 0;
            int life = 3;
            var availableCategory = new string[4]
            {
                "Technology [T]", "Nature [N]", "Biology [B]", "Medicine [M]"
            };
            Console.Clear();
            Console.WriteLine(string.Format("Welcome {0}, you have {1} points and {2} lives", firstName, points, life));
            Console.WriteLine("");
            Console.WriteLine("Please select your category");
            Console.WriteLine("Type in the letter for example N for Nature");

            for (int i = 0; i < availableCategory.Length; i++)
            {
                Console.WriteLine(availableCategory[i]);
            }

            Console.Write("> ");
            string category = Console.ReadLine();

            // the switch statement below is for selection of the question categories

            switch (category.ToLower())
            {
                case "t":
                    Console.WriteLine("technology");
                    technologyQuestion(firstName, availableCategory, points, life);
                    break;

                case "m":
                    Console.Write("Math");
                    //mathQuestion(firstName, points, life);
                    break;

                case "q":
                    GameOver(firstName, availableCategory, points, life);
                    break;


                default:
                    Console.WriteLine("You did not pick a category");
                    break;
            }
        }

        // Below is the Technology Question method

        static void technologyQuestion(string firstname, string[] availableCategory, int points, int life)
        {
            Console.Clear();
            Console.WriteLine("Technology questions");
            string answer;
            int questionCount = 0;
            var techQuestion = new string[2, 3]
            {
                {"You need this tool to type on your computer", "It displays whatever you are doing on the computer", "A form of computer you can carry around"},
                {"keyboard", "monitor", "laptop"}
            };
            int questions = 0;

            while (questions < 3)
            {
                Console.WriteLine(techQuestion[0, questionCount]);
                Console.Write("> ");
                answer = Console.ReadLine();
                if (answer == techQuestion[1, questionCount])
                {
                    points++;
                    Console.WriteLine("You answered correctly and now have " + points + " points");
                    questions++;
                    questionCount++;
                }
                else
                {
                    questions++;
                    questionCount++;
                    Console.WriteLine("Wrong answer, You now have " + points + " and " + life + " lives left");
                    life--;
                }
            }
            availableCategory[0] = "---";
            ChoseCategory(firstname, availableCategory, points, life);

        } // slut på methoden technologyQuestion


        // början på metoden ChoseCategory
        static void ChoseCategory(string firstname, string[] availableCategory, int points, int life)
        {
            Console.Clear();
            Console.WriteLine(string.Format("{0}, you have {1} points and {2} lives left", firstname, points, life));
            Console.WriteLine("");
            Console.WriteLine("Please select your category");
            Console.WriteLine("Type in the letter for example N for Nature");
            for (int i = 0; i < availableCategory.Length; i++)
            {
                Console.WriteLine(availableCategory[i]);
            }

            Console.Write("> ");
            string category = Console.ReadLine();

            // the switch statement below is for selection of the question categories

            switch (category.ToLower())
            {
                case "t":
                    if (availableCategory[0] != "---")
                    {
                        Console.WriteLine("You have selected technology questions");
                        technologyQuestion(firstname, availableCategory, points, life);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have already finished technology, please select a new category");
                        ChoseCategory(firstname, availableCategory, points, life);
                        break;
                    }

                case "m":
                    Console.Write("Math");
                    break;

                case "q":
                    GameOver(firstname, availableCategory, points, life);
                    break;


                default:
                    Console.WriteLine("You did not pick a category");
                    break;
            }

        } // slutet på metoden ChoseCategory


        // Method for GameOver where user can terminate the game or play a new game.
        static void GameOver(string firstname, string[] availableCategory, int points, int life)
        {
            Console.Clear();
            Console.WriteLine(string.Format("{0}, you have unfortunately reached the end of the road \nDo you want to play again [Y] or End the Game [N]?", firstname));
            Console.Write("> ");
            string lastAnswer = Console.ReadLine();

            switch (lastAnswer.ToLower())
            {
                case "y":
                    firstname = "";
                    points = 0;
                    life = 3;
                    StartGame();
                    break;

                case "n":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Pleas type Y if you want to play again or N if you want to end the game");
                    break;
            }
        }
    }
}
    