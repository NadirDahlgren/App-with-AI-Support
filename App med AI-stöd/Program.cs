namespace App_med_AI_stöd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List for storing the characters. 
            List<Character> randomCharacters = new List<Character>();

            // Controls the main menu loop.
            bool charMenu = true;

            // Menu for the characters. 
            while (charMenu)
            {
                Console.WriteLine(
                    "== Welcome to the Character Generator! ==\n" +
                    "1. Create a character.\n" +
                    "2. Display all characters.\n" +
                    "3. Remove all characters.\n" +
                    "4. Exit.\n");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int userInput)) // Validates the menu input as an integer.
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue; // ChatGPT helped me understand that continue skips the remaining code and starts the next loop iteration.
                }
                switch (userInput)
                {
                    case 1: // Add a new character to the list. 
                        Console.Clear();
                        Console.WriteLine("Name of the character:");
                        string? userName = Console.ReadLine(); // ChatGPT suggested IsNullOrWhiteSpace to prevent null, empty, or whitespace-only character names.
                        if (string.IsNullOrWhiteSpace(userName)) 
                        {
                            Console.WriteLine("Please enter a valid name.");
                            break;
                        }
                        Character newCharacter = new Character(userName);
                        randomCharacters.Add(newCharacter);
                        Console.WriteLine($"{userName} has been created and added to the list.");
                        break;

                    case 2: // Prints out every character if available, with the method. 
                        Console.Clear();
                        if (randomCharacters.Count > 0)
                        {
                            foreach (Character character in randomCharacters)
                            {
                                character.DisplayCharacter();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Character list is empty.");
                        }
                        break;
                        
                    case 3: // Clears the list if any characters have been created.  
                        Console.Clear();
                        if (randomCharacters.Count > 0)
                        {
                            randomCharacters.Clear();
                            Console.WriteLine("The list of characters has been cleared.");
                        }
                        else
                        {
                            Console.WriteLine("Character list is empty.");
                        }
                        break;

                    case 4: // Exits the iteration and closes the program. 
                        charMenu = false;
                        break;

                    default: // Handles menu choices that are not between 1 and 4.
                        Console.WriteLine("Wrong input. Please choose a number between 1-4.");
                        break;
                        
                }
            }
        }
    }
}
