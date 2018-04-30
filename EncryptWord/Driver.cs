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
                "encrypted word and the encryption is based on a cipher shift. Each guess will be \n" +
                "tallied and when you have correctly guessed the right integer, you will be \n" +
                "notified\n");
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
