using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

string[] wordsArray = new string[10]
{ "hello", "bye", "monkey", "food", "world", "cooking", "repeat", "switch", "cars", "banana", }; // array med 10 ord

bool playAgain = false;

do
{

    #region Variables And For Loops

    ConsoleKeyInfo enter = default;

    Random randomNumber = new Random(); // variabel som genererar randim nummer

    int randomIndex = randomNumber.Next(wordsArray.Length); //programmet väljer en random siffra från 0 till 9, alltså indexen i arrayen.

    char[] randomWord = wordsArray[randomIndex].ToCharArray(); //programmet väljer ett random ord från arrayen

    char[] displayedWord = new char[randomWord.Length];

    char[] usedLetters = new char[6 + randomWord.Length - 1];

    int attempts = 6;

    int count = 0;


    for (int i = 0; i < usedLetters.Length; i++)
        usedLetters[i] = ' ';


    for (int i = 0; i < displayedWord.Length; i++)
        displayedWord[i] = '_';

    #endregion

    void GameWindow()
    {
        Console.Clear();

        foreach (char characters in displayedWord)
            Console.Write(characters + " ");
        
        Console.WriteLine("\n");

        Console.Write(" Used Letters: ");
        foreach (char letters in usedLetters)
            Console.Write(letters + " ");


        Console.WriteLine();
        Console.WriteLine($"Attempts left: {attempts}");
        Console.WriteLine();
        Console.Write("Guess a letter: ");

    }
    
    void PlayGame()
    {
        char input = char.ToLower(Console.ReadKey().KeyChar); // input är den key som trycks.
        if (!char.IsLetter(input) || usedLetters.Contains(input)) // om input inte är en bokstav eller om det redan har använts.
        {
            return; // hoppar tillbaka för att ta en input.
        }

        do
        {
            enter = Console.ReadKey(true); // enter för att välja inputen och backspace för att ångra sig
            if (enter.Key == ConsoleKey.Backspace && input != '\0')
            {
                return;
            }
        } while (enter.Key != ConsoleKey.Enter);


        if (!usedLetters.Contains(input) && char.IsLetter(input))
        {
            usedLetters[count] = input;
            count++;


            for (int i = 0; i < randomWord.Length; i++)
            {
                if (input == randomWord[i])
                {
                    displayedWord[i] = randomWord[i];
                }
            }

            if (!displayedWord.Contains(input))
                attempts--;
        }

    }
    
    void Lose()
        {
            if (attempts == 0)
            {
                Console.Clear();
                foreach (char characters in displayedWord)
                    Console.Write(characters + " ");

                Console.WriteLine("\n");

                Console.Write(" Used Letters: ");
                foreach (char letters in usedLetters)
                    Console.Write(letters + " ");

                Console.WriteLine();
                Console.WriteLine($"Attempts left: {attempts}");

                Console.WriteLine();
                Console.WriteLine($"You ran out of attempts");
                Console.Write("The word was: ");
                foreach (char letters in randomWord)
                    Console.Write(letters);
            }
        }

    void Win()
        {
            if (!displayedWord.Contains('_'))
            {
                Console.Clear();
                foreach (char characters in displayedWord)
                    Console.Write(characters + " ");

                Console.WriteLine("\n");

                Console.Write(" Used Letters: ");
                foreach (char letters in usedLetters)
                    Console.Write(letters + " ");

                Console.WriteLine("");
                Console.WriteLine($"Attempts left: {attempts}");

                Console.WriteLine();
                Console.WriteLine($"Congrats! You rock!");
                
            }
            
        }
    
    void PlayAgain()
     {
         Win();
         Lose();
         Console.WriteLine("\n");
        Console.Write("Do you want to play again? (y/n): "); 
        
        char input = char.ToLower(Console.ReadKey().KeyChar); // input är den key som trycks.
        if (!char.IsLetter(input) || input is not ('y' or 'n')) // om input inte är en bokstav eller om det redan har använts.
        {
            Console.Clear();
            GameWindow();
            PlayAgain();// hoppar tillbaka för att ta en input.
            return;
        }
        do
        {
            enter = Console.ReadKey(true); // enter för att välja inputen och backspace för att ångra sig
            if (enter.Key == ConsoleKey.Backspace && input != '\0')
            {
                Console.Clear();
                GameWindow();
                PlayAgain();// hoppar tillbaka för att ta en input.
                return;
            }
        } while (enter.Key != ConsoleKey.Enter);
        
        switch (input)
        {
            case 'y':
                playAgain = true;
                break;
            case 'n':
                playAgain = false;
                Console.WriteLine("\n");
                Console.WriteLine("Goodbye boring soul!");
                break;
        }
     }
    
    while (attempts > 0)
    {
        GameWindow();
        PlayGame();

        if (!displayedWord.Contains('_'))
        {
            break;
        }
    }
    PlayAgain();
    
}while (playAgain) ;