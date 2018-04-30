// AUTHOR: Nicholas Benyo
// FILENAME: Driiver.cs
// DATE: 2018-04-29
// REVISION HISTORY:  1.0

// Description: --
// This is the guessing game driver to be used in conjunction with the EncryptWord class. 
// Output is printed to screen and the user can answer. Five different encrypted words are
// initialized and the results will print when the user has guessed correctly
//
// Assumptions: The user will enter an integer when guessing and nothing else. The purpose
// of this exercise was to become familiar with the C# syntax. I feel I have accomplished this
// The game is perfunctory in nature, and defensive programming along with deep complexity was
// not required.

using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptWord
{
    class Driver
    {
        static String[] Words = { "nicholas", "arielle", "samuel", "grace", "scott" };
        static EncryptWord[] EncryptedWords = new EncryptWord[4];

        public static void Execute()
        {
            Console.WriteLine("Hello, thank you for playing the guessing game! You will be shown an \n" +
                "encrypted word and the encryption is based on a cipher shift (1-25). Each guess will be \n" +
                "tallied and when you have correctly guessed the right integer, you will be \n" +
                "notified. ENTERING ANYTHING OTHER THAN AN INTEGER WILL END THE GAME.\n");
            GuessLoop();
            Console.WriteLine("Thank you for playing the guessing game! Press any key to close.");
            Console.ReadLine();
        }

        public static void GuessLoop()
        {
            Initialize();
            foreach (EncryptWord word in EncryptedWords)
            {
                int userGuess = 0;
                while (word.CheckState() == 1)
                {
                    Console.WriteLine("Please guess the cipher shift to the following word: " + word.GetWord());
                    userGuess = Convert.ToInt32(Console.ReadLine());
                    word.GuessWord(userGuess);
                    Console.WriteLine(word.GetWord());
                }
                Console.WriteLine("Correct! The cipher shift is " + userGuess);
                Console.WriteLine("The original word was: " + word.GetWord());
                Console.WriteLine(word.Statistics());
                Console.WriteLine();

            }
        }

        public static void Initialize()
        {
            for(int i = 0; i < Words.Length-1; i++)
            {
                EncryptedWords[i] = new EncryptWord(Words[i]);
            }
        }
    }
}
