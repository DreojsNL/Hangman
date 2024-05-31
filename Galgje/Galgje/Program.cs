using System;

namespace Galgje
{
    internal class Program
    {
        static public int wordcount;
        static public string[] words;
        static List<char> rightLetters = new List<char>();
        static public string currentWord;
        static int chances = 10;
        static int currentPlayer = 1;
        static int ammountOfPlayers;
        static string input;
        static string filePath = "C:\\Users\\sfjdi\\Documents\\GitHub\\COF\\Hangman\\Galgje\\Galgje\\Words.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                words = File.ReadAllLines(filePath);
                Console.WriteLine("Welcome to galgje!");
                Console.WriteLine("How many players");
                string input1;
                input1 = Console.ReadLine();
                int inputNum = int.Parse(input1);
                if (inputNum > 4)
                {
                    Console.WriteLine("To many players max is 4");
                    Console.Clear();

                }
                else
                {
                    ammountOfPlayers = inputNum;
                    Console.Clear();
                    break;
                }

            }
            Start();
        }
        static void Start()
        {
            WordGenerator();
            wordcount = currentWord.Length;
            Console.WriteLine("Your word contains " + wordcount + " letters.");
            while (chances > 0)
            {
                LetterChoosing();
                CheckLetter(input.ToLower());
            }
            Console.WriteLine("Game over! The word was " + currentWord.ToLower());
        }
        static void LetterChoosing()
        {
            while (true)
            {
                Console.WriteLine("Current Player " + currentPlayer);
                Console.WriteLine("Chances left: " + chances);
                Console.WriteLine("Word length " + wordcount);
                Console.WriteLine("Letters guessed right: " + string.Join(", ", rightLetters));
                Console.WriteLine("Choose a letter:");
                input = Console.ReadLine();
                if (input.Length == 1)
                {
                    break;
                }
                if (input.ToLower() != currentWord.ToLower())
                {
                    Console.Clear();
                    Console.Write(input);
                    Console.WriteLine("No thats not the word.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("YOU WON! THE WORD WAS " + currentWord.ToLower());
                    currentPlayer++;
                    Console.ReadLine();
                    if(currentPlayer <= ammountOfPlayers)
                    {
                        rightLetters.Clear();
                        chances = 10;
                        Start();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("All players finiched the game");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;
                }
            }
        }

        static void CheckLetter(string checkLetter)
        {
            int count = 0;
            foreach (char c in currentWord)
            {
                if (c.ToString() == checkLetter)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                Console.WriteLine("The word contains the letter " + checkLetter + " " + count + " times.");
                for (int i = 0; i < count; i++)
                {
                    rightLetters.Add(checkLetter[0]);
                }
            }
            else
            {
                Console.WriteLine("The word does not contain the letter " + checkLetter + ".");
                chances--;
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void WordGenerator()
        {
            Random rd = new Random();
            currentWord = words[rd.Next(words.Length)];
        }
    }
}