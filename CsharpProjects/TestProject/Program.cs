// Declaring variables that ourAnimals array will store
using System.IO.Pipelines;

string animalID = "";
string animalSpecies = "";
string animalAge = "";
string animalNickname = "";
string animalPersonalityDescription = "";
string animalPhysicalDescription = "";

//variable for data entry

int maxPets = 8;
string? readResult;  //readResult is a variable that stores user's input temporarily
string menuSelection = "";
int petCount = 0;
string anotherPet = "y";
bool validEntry = false;
int petAge = 0;

//array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

//innitial array of pets

for(int i = 0; i < maxPets; i++)
{
    switch(i)
    {
        case 0:
            animalSpecies = "Dog";
            animalID = "D1";
            animalAge = "2";
            animalPersonalityDescription = "funny";
            animalPhysicalDescription = "black cane corso";
            animalNickname = "Lordy";
            break;

        case 1:
            animalSpecies = "Dog";
            animalID = "D2";
            animalAge = "2";
            animalPersonalityDescription = "evil";
            animalPhysicalDescription = "white chihuahua";
            animalNickname = "lily";
            break;

        case 2:
            animalSpecies = "Cat";
            animalID = "C1";
            animalAge = "3";
            animalPersonalityDescription = "Moody af";
            animalPhysicalDescription = "white";
            animalNickname = "Mia";
            break;
        
        case 3:
            animalSpecies = "Cat";
            animalID = "C2";
            animalAge = "2";
            animalPersonalityDescription = "Cute cat with big eyes. ";
            animalPhysicalDescription = "black";
            animalNickname = "Django";
            break; 
        
        default:
            animalSpecies = "";
            animalAge = "";
            animalID = "";
            animalPersonalityDescription = "";
            animalPhysicalDescription = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription; 
}

// array of pets
for(int i = 0; i < maxPets; i++)
{
    switch(i)
    {
        case 0:
            animalID = "D1";
            animalSpecies = "Dog";
            animalAge = "2";
            animalPersonalityDescription = "funny";
            animalPhysicalDescription = "black cane corso";
            animalNickname = "Lordy";
            break;
            
        case 1:
            animalID = "D2";
            animalSpecies = "Dog";
            animalAge = "2";
            animalPersonalityDescription = "evil";
            animalPhysicalDescription = "white chihuahua";
            animalNickname = "lily";
            break;
            
        case 2:
            animalID = "C1";
            animalSpecies = "Cat";
            animalAge = "1";
            animalPersonalityDescription = "Moody af";
            animalPhysicalDescription = "white";
            animalNickname = "Mia";
            break;
            
        case 3:
            animalID = "C2";
            animalSpecies = "Cat";
            animalAge = "2";
            animalPersonalityDescription = "Cute cat with big eyes. ";
            animalPhysicalDescription = "black";
            animalNickname = "Django";
            break;
            
        default:
            animalID = "";
            animalSpecies = "";
            animalAge = "";
            animalPersonalityDescription = "";
            animalPhysicalDescription = "";
            animalNickname = "";
            break;
    }
}

do
{
    Console.WriteLine("Choose an option from the following list:");
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
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < maxPets; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }
            Console.WriteLine("\n\tPress Enter to proceed");
            readResult = Console.ReadLine();
            break;

        case "2":
            anotherPet = "y";
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currentlu have {petCount} animals. we can have {(maxPets - petCount)} more");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                do
                {
                    Console.WriteLine("Enter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                do
                {
                    Console.WriteLine("Enter pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                do
                {
                    Console.WriteLine("Enter personality");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (validEntry == false);


                do
                {
                    Console.WriteLine("Enter physical Description");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }

                } while (validEntry == false);

                do
                {
                    Console.WriteLine("Enter Nickname");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }

                } while (validEntry == false);

                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical info: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality info: " + animalPersonalityDescription;

                petCount += 1;

                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to add more?");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our Limit of pets");
                Console.WriteLine("Press Enter to continue");
                readResult = Console.ReadLine();
            }
            break;

        case "3":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 2] == "Age: ?" && ourAnimals[i, 0] != "ID #: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                    } while (validEntry == false);
                    ourAnimals[i, 2] = "Age: " + animalAge.ToString();
                }

                if (ourAnimals[i, 4] == "Physical info: " && ourAnimals[i, 0] != "ID #: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult.ToLower();
                            if (animalPhysicalDescription == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);

                    ourAnimals[i, 4] = "Physical info: " + animalPhysicalDescription;
                }
            }
            Console.WriteLine("\n\tAge and physical info fields are complete\n\tPress Enter to continue");
            readResult = Console.ReadLine();
            break;

        case "4":
            //Nickname and personality
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 3] == "Nickname: " && ourAnimals[i, 0] != "ID #: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalNickname = readResult;
                            if (animalNickname == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);
                    ourAnimals[i, 3] = "Nickname: " + animalNickname;
                }

                if (ourAnimals[i, 5] == "Personality: " && ourAnimals[i, 0] != "ID #: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter Personality description for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult.ToLower();
                            if (animalPersonalityDescription == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);

                    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                }
            }
            Console.WriteLine("\n\tNickname and personality description fields are complete\n\tPress Enter to continue");
            readResult = Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("Enter pet ID to edit their age");
            readResult = Console.ReadLine();
            bool found = false;
            string searchID = "ID #: " + readResult.ToUpper();
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == searchID)
                {
                    found = true;
                    Console.WriteLine($"Current age: {ourAnimals[i, 2]}");
                    Console.WriteLine("Enter new age");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            validEntry = int.TryParse(animalAge, out petAge);
                            if (!validEntry)
                            {
                                Console.WriteLine("Please enter valid number");
                            }
                        }
                    } while (validEntry == false);
                    ourAnimals[i, 2] = "Age: " + animalAge;
                    Console.WriteLine("Age successfully updated");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("pet ID not found");
            }
            Console.WriteLine("Press enter to continue");
            readResult = Console.ReadLine();
            break;


        case "6":
        // Edit an animal’s personality description");
            Console.WriteLine("Enter pet ID to edit their personality description");
            readResult = Console.ReadLine();
            found = false;
            searchID = readResult.ToUpper();
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == searchID)
                {
                    found = true;
                    Console.WriteLine("Enter new description");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult;
                            validEntry = true;
                            if (!validEntry)
                            {
                                Console.WriteLine("please enter valid input");
                            }
                        }
                    } while (validEntry == false);
                    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                    Console.WriteLine("Personality description updated successfully");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("pet ID not found");
            }
            Console.WriteLine("Press enter to continue");
            readResult = Console.ReadLine();
            break;
            
    }
} while (menuSelection != "exit");
