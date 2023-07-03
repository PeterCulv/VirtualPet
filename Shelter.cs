namespace template_csharp_virtual_pet
{
    public class Shelter
    {
        // PROPERTY //
        public List<Pet> Pets { get; set; }


        // CONSTRUCTOR //
        public Shelter()
        {
            Pets = new List<Pet>();
        }


        // --------------------------- METHODS --------------------------- //

        // ----------- DISPLAY ALL PETS ----------- //
        public void DisplayAllPets()        // Method to display all Pets in the shelter
        {
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Currently in your shelter we have the following Pets:\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===============================================================================================================");
            foreach (Pet pet in Pets)
            {
                if (pet is Organic)
                {
                    Console.WriteLine($"PET #{counter}\tName: {pet.PetName.PadRight(12)}Species: {pet.PetSpecies.PadRight(12)}Type: {pet.PetType}\tHealth: {pet.PetHealth}\t" +
                    $"Hunger: {pet.PetHunger}\tBoredom: {pet.PetBoredom}\n");
                    counter++;
                }
                else
                {
                    Console.WriteLine($"PET #{counter}\tName: {pet.PetName.PadRight(12)}Species: {pet.PetSpecies.PadRight(12)}Type: {pet.PetType}\tRust level: {pet.PetHealth}\t" +
                    $"Battery: {pet.PetHunger}\tIdleness: {pet.PetBoredom}\n");
                    counter++;
                }
            }
            Console.WriteLine("===============================================================================================================");
        }

        // ----------- INTERACTIONS (INDIVIDUAL) ----------- //
        public void Admit(Pet pet)      // Method to add a Pet to the shelter
        {
            Pets.Add(pet);
            Console.WriteLine($"You successfully added {pet.PetName} to the shelter.");
        }

        public void Adopt(Pet pet)      // Method to remove a Pet from the shelter
        {
            Pets.Remove(pet);
            Console.WriteLine($"\nYou successfully adopted {pet.PetName} from the shelter.");
        }

        public Pet GetPet()
        {
            if (Pets.Count == 0)
            {
                Console.WriteLine("There are currently no Pets in the shelter.");
                return null;
            }
            else
            {
                DisplayAllPets(); // Display all available Pets in the shelter
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter the number of the Pet you want to select: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                int petNumber = Convert.ToInt32(Console.ReadLine());

                if (petNumber >= 1 && petNumber <= Pets.Count)
                {
                    return Pets[petNumber - 1];   // Get the selected Pet from the list
                }
                else
                {
                    Console.WriteLine("Invalid Pet number.");
                    return null;
                }
            }
        }

        // -------------- INTERACTION MENU (ALL)-------------- //
        public void InteractAllMenu()
        {
            string userChoice;
            if (Pets.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have no pets in the shelter to interact with.  Admit a pet to the shelter first!");
                Console.ReadLine();
                return;
            }
            do
            {
                Console.Clear();
                DisplayAllPets();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What would you like to do with your Pets?");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1. Play with all of them!");
                Console.WriteLine("2. Feed/Recharge all of them!");
                Console.WriteLine("3. Full shelter vet/mechanic visit\n");
                Console.WriteLine("0. Go back to the Main Menu\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter a selection number: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        PlayAll();
                        break;
                    case "2":
                        FeedAll();
                        break;
                    case "3":
                        SeeDoctorAll();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Your selection is invalid");
                        break;
                }
                TickAll();
            }
            while (userChoice != "0");
        }

        public void FeedAll()
        {
            foreach (Pet pet in Pets)
            {
                if (pet is Organic)
                {
                    pet.PetHunger -= 10;
                }
                else
                {
                    pet.PetHunger += 10;
                }

            }
            Console.Clear();
            DisplayAllPets();
            Console.WriteLine("\nYou fed all the Pets their favorite food and recharged their batteries!");
            Console.ReadLine();
        }
        public void SeeDoctorAll()
        {
            foreach (Pet pet in Pets)
            {
                pet.PetHealth += 10;
            }
            Console.Clear();
            DisplayAllPets();
            Console.WriteLine("\nYou make vet and mechanic appointments for all the Pets; they are being well taken care of!");
            Console.ReadLine();
        }
        public void PlayAll()
        {
            foreach (Pet pet in Pets)
            {
                if (pet is Organic)
                {
                    pet.PetHealth += 10;
                    pet.PetHunger += 10;
                    pet.PetBoredom -= 20;
                }
                else
                {
                    pet.PetHealth += 10;
                    pet.PetHunger -= 10;
                    pet.PetBoredom -= 20;
                }
            }
            Console.Clear();
            DisplayAllPets();
            Console.WriteLine("\nYou play with all your Pets; they love the attention!");
            Console.ReadLine();
        }

        // ----------- TICK FUNCTION FOR ALL PETS ----------- //
        public void TickAll()   // Gradually decays the Pet stats. Organic pets increase it's hunger while Robotic pets decrease Battery charge
        {
            foreach (Pet pet in Pets)
            {
                if (pet is Organic)
                {
                    pet.PetHealth -= 5;
                    pet.PetHunger += 5;
                    pet.PetBoredom += 5;
                }
                else
                {
                    pet.PetHealth -= 5;
                    pet.PetHunger -= 5;
                    pet.PetBoredom += 5;
                }
            }
        }
    }
}