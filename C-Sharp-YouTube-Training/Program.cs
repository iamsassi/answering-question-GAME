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
            Console.WriteLine("Welcome to this game where you are to answer questions and collect as many points as possible");


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
                        startOver = false;
                        EndGame();
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
            var availableCategory = new string[6]
            {
                "Technology [T]", "Nature [N]", "Biology [B]", "Medicine [M]  (Currently not available)", "", "End Game [Q]"
            };
            Console.Clear();
            Console.WriteLine(string.Format("Welcome {0}, you have {1} points and {2} lives", firstName, points, life));
            Console.WriteLine("");
            Console.WriteLine("Please select your category");
            Console.WriteLine("Type in the letter for example N for Nature");
            Console.WriteLine("");

            for (int i = 0; i < availableCategory.Length; i++)
            {
                Console.WriteLine(availableCategory[i]);
            }

            Console.Write("> ");
            string category = Console.ReadLine();

            // the switch statement below is for selection of the question categories

            switch (category.ToLower())
            {

                case "b":
                    biologyQuestion(firstName, availableCategory, points, life);
                    break;

                case "t":
                    Console.WriteLine("technology");
                    technologyQuestion(firstName, availableCategory, points, life);
                    break;

                case "m":
                    Console.Write("Math");
                    //mathQuestion(firstName, points, life);
                    break;

                case "n":
                    natureQuestion(firstName, availableCategory, points, life);
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
                if (answer.ToLower() == techQuestion[1, questionCount].ToLower())
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

        } // End of the method technologyQuestion

        // Start of natureQuestion
        static void natureQuestion(string firstname, string[] availableCategory, int points, int life)
        {
            Console.Clear();
            Console.WriteLine("Nature questions");
            string answer;
            int questionCount = 0;
            var natureQuestion = new string[2, 3]
            {
                {"What is the white substance contained in the fibre cells?", "How much biospehere extends to the distance?", "What are the groups of sporangia borne on the fern leaves called?"},
                {"Cellulose", "22.5km", "Sori"}
            };
            int questions = 0;

            while (questions < 3)
            {
                Console.WriteLine(natureQuestion[0, questionCount]);
                Console.Write("> ");
                answer = Console.ReadLine();
                if (answer.ToLower() == natureQuestion[1, questionCount].ToLower())
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
            availableCategory[1] = "---";
            ChoseCategory(firstname, availableCategory, points, life);

        } // End of the method natureQuestion

        // Start of biologyQuestion
        static void biologyQuestion(string firstname, string[] availableCategory, int points, int life)
        {
            Console.Clear();
            Console.WriteLine("Nature questions");
            string answer;
            int questionCount = 0;
            var biologyQuestion = new string[2, 3]
            {
                {"In which modern-day country was the physicist and chemist Marie Curie born?", "How many wings does a mosquito have?", "Which is the largest internal organ in the human body?"},
                {"Poland", "Two", "liver"}
            };
            int questions = 0;

            while (questions < 3)
            {
                Console.WriteLine(biologyQuestion[0, questionCount]);
                Console.Write("> ");
                answer = Console.ReadLine();
                if (answer.ToLower() == biologyQuestion[1, questionCount].ToLower())
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
            availableCategory[2] = "---";
            ChoseCategory(firstname, availableCategory, points, life);

        } // End of the method biologyQuestion

        // Start of method ChoseCategory
        static void ChoseCategory(string firstname, string[] availableCategory, int points, int life)
        {
            Console.Clear();
            if(points != 0)
            {
                Console.WriteLine(string.Format("{0}, you have {1} points and {2} lives left", firstname, points, life));
                Console.WriteLine("");
                Console.WriteLine("Please select your category");
                Console.WriteLine("Type in the letter for example N for Nature");
                Console.Write("");

                for (int i = 0; i < availableCategory.Length; i++)
                {
                    Console.WriteLine(availableCategory[i]);
                }

                Console.Write("> ");
                string category = Console.ReadLine();

                // the switch statement below is for selection of the question categorie and checks if the user already done a specifik category

                switch (category.ToLower())
                {
                    case "b":
                        if (availableCategory[2] != "---")
                        {
                            Console.WriteLine("You have selected biology questions");
                            biologyQuestion(firstname, availableCategory, points, life);
                            break;
                        }
                        else
                        {
                            ChoseCategory(firstname, availableCategory, points, life);
                            break;
                        }

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

                    case "n":
                        if(availableCategory[5] != "---")
                        {
                            Console.WriteLine("You have selected nature questions");
                            natureQuestion(firstname, availableCategory, points, life);
                            break;
                        }
                        else{
                            // this lines means that the user have already done nature questions
                            ChoseCategory(firstname, availableCategory, points, life);
                            break;
                        }

                    case "q":
                        GameOver(firstname, availableCategory, points, life);
                        break;


                    default:
                        Console.WriteLine("You did not pick a category");
                        break;
                }
            }
            else
            {
                // if the user have 0 lives left, the user will be sent to the GameOver method
                GameOver(firstname, availableCategory, points, life);
            } 
            

        } // End of method ChoseCategory


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
        } // End of GameOver Method


        // Start of EndGame method - the user is sent here from StartGame method if the user select N 
        static void EndGame()
        {
            Environment.Exit(0);
        }
    }
}
    