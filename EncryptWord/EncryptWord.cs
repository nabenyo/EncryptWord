// AUTHOR: Nicholas Benyo
// FILENAME: EncryptWord.cs
// DATE: 2018-04-29
// REVISION HISTORY:  1.0
// REFERENCES (optional): Design extracted from original EncryptWord.h/Encryptword.cpp submitted in CPSC 5011

// Description: --
// EncryptWord is designed for a simple Caesar Cipher game. Words are shifted
// by an integer ranging from 1 to 25. Word can be set, encrypted, decrypted,
// reset, status can be checked to meet assumptions, and statistics can be
// generated on guesses. Decryption is only possible by passing through the
// appropriate shift. Shift and word are purposefully obscured from user
// until guessed correctly. Statistics are generated on the number of times
// guessWord() is called and the result of integer passed through the function.
// Object state - The object state is teh status data member. An object will 
// be in state 1 when the object is currently encrypted and the shift has not
// been correctly called using the guessWord() method. After the integer has been
// passed through, the state will change until the word is reset.
//
// Assumptions:
// -Words passed to the object using setWord() are comprised of only chars a-z
// -guessWord() method is not called prior to calling setWord correctly
// -reset() is not called prior to setting the word
// -Only integers will be passed to the guessWord() function
// -Application programmer does not intend to decrypt word through any other
// means than guessing the appropriate shift
// -Application programmer does not intend to view word or encrypted word out
// of state (on will only return encrypted, off will only return unencrypted)

using System;

namespace EncryptWord

    {
        public class EncryptWord
        {
            private string word;
            private int shift;
            private int guesses;
            private int highGuess;
            private int lowGuess;
            private string encryptedWord;
            private int status;
            private int guessSum;

            public EncryptWord(string Word)
            // description: class constructor
            // preconditions: This constructor is only guaranteed to function
            // properly when the programmer calls [rand() % 25 (or constant = 25) +
            // 1] in order to properly seed and generate a random number with each
            // construction and obscure the cipher shift. Shift will still occur when
            // random variable is called beyond the bounds but will not behave as
            // expected.
            // postconditions: Status will default to 0, shift will be set to equal
            // shiftNumber and EncryptWord will be ready to receive and encrypt a string
            {
                this.word = Word;
                Reset();
            }

            public bool SetWord(string userWord)
            // description: Sets a word and generates the encryption, returns bool of
            // true if setWord is successful, and false if unsuccessful. Used for
            // both initialization and setting a new word.
            // preconditions: Passed through word is greater than 4 characters
            // characters and contains only a-z letters (will not work
            // with any other characters). Encryption converts to lower case before
            // shifting
            // postconditions: Status will be set to 1 if word is set successfully,
            // word will be changed to userWord, and encryptedWord will be populated
            // with ciphered word.
            {
                if (userWord.Length > 3)
                {
                    this.word = userWord;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            // description: Resets word by changing status to on and encrypting the
            // word with a new cipher. Can be used on a word that is still encrypted.
            // an EnryptWord object cannot have word set to null after the initial
            // call of setWord(). Changing the word requires calling setWord().
            // preconditions: setWord() has been initialized to pass through the
            // initial word for this to method to function properly. The object need not
            // be in 0 (off) status to reset.
            // postconditions: Word will remain the same, statistics will be set to
            // 0, a new cipher will be chosen, and word will be encrypted with new
            // cipher
            {
                this.status = 1;
                Random shifter = new Random();
                this.shift = shifter.Next(1, 25);
                foreach (char c in word)
                {
                    int ascii = (int)c;
                    if(ascii + this.shift > 122)
                    {
                    //Console.WriteLine(c);
                    //Console.WriteLine((ascii + this.shift) - 122);
                    ascii = 97 + ((ascii + this.shift) - 122);
                    //Console.WriteLine(ascii);
                    //Console.WriteLine();
                    }
                    else
                    {
                    ascii = ascii + this.shift;
                    }
                    char newChar = (char)ascii;
                    String newLetter = newChar.ToString();
                    this.encryptedWord += newLetter;
                }
            }

            public int GuessWord(int guess)
            // description: User can guess the shift being used to encrypt word.
            // Guesses are captured in statistics. Guess will result in three
            // integers (1: high, 0: correct guess, -1: low). Programmer should use
            // return value to indicate directionality of guess.
            // preconditions: Word has been set, without setWord(), method will not
            // function as expected.
            // postconditions: highGuess and lowGuess may increment by 1. Status may
            // change to 0 if guess == shift. guesses will be incremented by one and
            // guess will be added to guessSum;
            {
                //to be implemented later
                if (guess < this.shift)
                {
                    lowGuess++;
                    guessSum++;
                    return -1;
                }
                else if (guess > this.shift)
                {
                    highGuess++;
                    guessSum++;
                    return 1;
                }
                else
                {
                    guessSum++;
                    DecryptWord();
                    return 0;
                }
            }

            public string GetWord()
            // description: Returns a string depending on the state of the object
            // preconditions: setWord has defined a word. Will not function properly
            // without a set word
            // postconditions: Depnding on the state of the object, a string is
            // returned. If the object remains in "On" state then word returned will
            // be encrypted. If in off state, returned word will be unencrypted.
            {
                if (this.encryptedWord == null)
                {
                    return this.word;
                }
                else
                {
                    return this.encryptedWord;
                }
            }

            public string Statistics()
            // description: Returns total number of guesses, average guess, high
            // guess, and low guess in string format. Each time the guessWord()
            // function is called statistics are recorded [see guessWord for
            // additional documentation]. Average word is (sum of all guesses made)
            // /total number of guesses
            // preconditions: guessWord() must have run in order for method to
            // function properly
            // postconditions: String returned with statistics
            {
                //to be implemented later
                String stats = "High guesses: " + this.highGuess + ", Low guesses: " + this.lowGuess + ", Total guesses: " + guessSum;
                return stats;
            }

            public int CheckState()
            // description: Returns the state of the object. "On" represents the state
            // of having a word and being encrypted. "Off" is the state of not having a
            // word or having a word and not being encrypted
            // preconditions: none
            // postconditions: Returns string status of object
            {
                //to be implemented later
                return status;
            }

            private void DecryptWord()
            // description: Private function for decryption of word. To be embedded within
            // the GuessWord fuction. When cipher is correctly guessed, word is decrypted.
            // Because this is a private function, no pre/post conditions necessary
            {
                this.status = 0;
                this.encryptedWord = null;
            }
        }
    }

