﻿// the ourAnimals array will store the following:
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = $"ID #: {animalID}";
    ourAnimals[i, 1] = $"Species: {animalSpecies}";
    ourAnimals[i, 2] = $"Age: {animalAge}";
    ourAnimals[i, 3] = $"Nickname: {animalNickname}";
    ourAnimals[i, 4] = $"Physical description: {animalPhysicalDescription}";
    ourAnimals[i, 5] = $"Personality: {animalPersonalityDescription}";
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    Console.WriteLine();
    if (!string.IsNullOrEmpty(readResult))
    {
        menuSelection = readResult.ToLower();
        //Console.WriteLine($"You selected menu option {menuSelection}.");
        switch (menuSelection)
        {
            case "1":
                // List all of our current pet information
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                        Console.WriteLine();
                    }
                }
                break;

            case "2":
                // Add a new animal friend to the ourAnimals array
                string anotherPet = "y";
                int petCount = 0; // Current number of pets in ourAnimals array.

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        petCount++;
                    }
                }

                if (petCount < maxPets)
                {
                    Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                }

                while (anotherPet == "y" && petCount < maxPets)
                {
                    // Get specie (cat or dog) - string animalspecies is a required field.
                    bool validEntry = default;
                    anotherPet = string.Empty;
                    do
                    {
                        Console.WriteLine($"\n\rEnter 'dog' or 'cat' to begin a new entry");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            animalSpecies = readResult.ToLower();
                            validEntry = animalSpecies is "dog" or "cat";
                        }
                    } while (validEntry == false);

                    // Build the animal ID number - for example C1, C2, D3 (for Cat 1, Cat 2 and Dog 3).
                    animalID = $"{animalSpecies.Substring(0, 1)}{petCount + 1}";

                    // Gwt the pet's age. It can be "?" at initial entry.
                    validEntry = default; // Reset variable.
                    do
                    {
                        Console.WriteLine("Enter valid pet's age or enter '?' if unknown");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            animalAge = readResult;
                            validEntry = animalAge != "?" ? int.TryParse(animalAge, out int _) : true;
                        }
                    } while (validEntry == false);

                    // Get a description of pet's physical appearance/condition - animalPhysicalDescription can be blank.
                    do
                    {
                        Console.WriteLine($"Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            animalPhysicalDescription = readResult.ToLower().Trim();
                        }
                        if (animalPhysicalDescription == "" || readResult == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    } while (animalPhysicalDescription == "");

                    // Get a description of pet's personality - animalPersonalityDescription can be blank.
                    do
                    {
                        Console.WriteLine($"Enter a description of the pet's personality (like or dislike, tricks, energy level)");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            animalPersonalityDescription = readResult.ToLower().Trim();
                        }
                        if (animalPersonalityDescription == "" || readResult == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    } while (animalPersonalityDescription == "");

                    // Get a description of pet's nickname - animalNickName can be blank.
                    do
                    {
                        Console.WriteLine($"Enter a nick name for the pet");
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrEmpty(readResult))
                        {
                            animalNickname = readResult.ToLower().Trim();
                        }
                        if (animalNickname == "" || readResult == "")
                        {
                            animalNickname = "tbd";
                        }
                    } while (animalNickname == "");

                    // Store the pet's information in the ourAnimals array (Zero based).
                    ourAnimals[petCount, 0] = $"ID #: {animalID}";
                    ourAnimals[petCount, 1] = $"Species: {animalSpecies}";
                    ourAnimals[petCount, 2] = $"Age: {animalAge}";
                    ourAnimals[petCount, 3] = $"Nickname: {animalNickname}";
                    ourAnimals[petCount, 4] = $"Physical description: {animalPhysicalDescription}";
                    ourAnimals[petCount, 5] = $"Personality: {animalPersonalityDescription}";
                    petCount++;

                    // Check maxPet limit
                    if (petCount < maxPets)
                    {
                        // Another pet?
                        do
                        {
                            Console.WriteLine("Do you want to enter info for another pet (y/n)");
                            readResult = Console.ReadLine();
                            if (!string.IsNullOrEmpty(readResult))
                            {
                                anotherPet = readResult.ToLower();
                            }
                        } while (anotherPet != "y" && anotherPet != "n");
                    }
                }

                if (petCount >= maxPets)
                {
                    Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                    Console.WriteLine("Press any key to continue...");
                    readResult = Console.ReadLine();
                }
                break;

            case "3":
                // Ensure animal ages and physical descriptions are complete
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        if (ourAnimals[i, 2] == "Age: ?")
                        {
                            bool validEntry = default;
                            do
                            {
                                Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {
                                    animalAge = readResult;
                                    validEntry = int.TryParse(animalAge, out int _);
                                    if (validEntry)
                                    {
                                        ourAnimals[i, 2] = $"Age: {animalAge}";
                                    }
                                }
                            } while (validEntry == false);
                        }

                        if (ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")
                        {
                            bool validEntry = default;
                            do
                            {
                                Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, gender, weight, housebroken)");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {
                                    animalPhysicalDescription = readResult.ToLower().Trim();
                                    if (animalPhysicalDescription != "")
                                    {
                                        ourAnimals[i, 4] = $"Physical description: {animalPhysicalDescription}";
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);
                        }
                    }
                }
                Console.WriteLine("Age and physical description fields are complete for all of our friends.");
                break;

            case "4":
                // Ensure animal nicknames and personality descriptions are complete
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        if (ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd")
                        {
                            bool validEntry = default;
                            do
                            {
                                Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {
                                    animalNickname = readResult.ToLower().Trim();
                                    if (animalNickname != "")
                                    {
                                        ourAnimals[i, 3] = $"Nickname: {animalNickname}";
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);
                        }

                        if (ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 5] == "Personality: tbd")
                        {
                            bool validEntry = default;
                            do
                            {
                                Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {
                                    animalPhysicalDescription = readResult.ToLower().Trim();
                                    if (animalPhysicalDescription != "")
                                    {
                                        ourAnimals[i, 5] = $"Personality: {animalPhysicalDescription}";
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);
                        }
                    }
                }
                Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
                break;

            case "5":
                // Edit an animal’s age
                Console.WriteLine($"UNDER CONSTRUCTION - please check back next month to see progress.");
                break;

            case "6":
                // Edit an animal’s personality description
                Console.WriteLine($"UNDER CONSTRUCTION - please check back next month to see progress.");
                break;

            case "7":
                // Display all cats with a specified characteristic
                Console.WriteLine($"UNDER CONSTRUCTION - please check back next month to see progress.");
                break;

            case "8":
                // Display all dogs with a specified characteristic
                Console.WriteLine($"UNDER CONSTRUCTION - please check back next month to see progress.");
                break;

            default:
                break;
        }
    }

    Console.WriteLine("Press the Enter key to continue...");

    // pause code execution
    _ = Console.ReadLine();
} while (menuSelection != "exit");