namespace template_csharp_virtual_pet
{
    public class Organic : Pet
    {
        // CONSTRUCTOR //
        public Organic(string petName, string petSpecies, string petType, int petHealth, int petHunger, int petBoredom) : base(petName, petSpecies, "Organic", petHealth, petHunger, petBoredom)
        {

        }


        // --------------------------- METHODS --------------------------- //

        // -------------- INTERACTION MENU (INDIVIDUAL)-------------- //
        public override void InteractMenu()
        {
            string userChoice;
            do
            {
                DisplayPet();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"What would you like to do with {PetName}?");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Feed");
                Console.WriteLine("3. Go to vet\n");
                Console.WriteLine("0. Go back to Main Menu\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter a selection number: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Play();
                        break;
                    case "2":
                        Feed();
                        break;
                    case "3":
                        SeeDoctor();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Your selection is invalid");
                        break;
                }
            }
            while (userChoice != "0");
        }

        public override void Feed()
        {
            PetHunger -= 10;
            DisplayPet();
            Console.WriteLine($"\nYou give {PetName} their favorite food! NOM NOM NOM!");
            Console.ReadLine();
        }
        public override void SeeDoctor()
        {
            PetHealth += 30;
            DisplayPet();
            Console.WriteLine($"\nYou make a check-up appointment for {PetName}; they are being well taken care of!");
            Console.ReadLine();
        }
        public override void Play()
        {
            PetHealth += 10;
            PetHunger += 10;
            PetBoredom -= 20;
            DisplayPet();
            Console.WriteLine($"\nYou play with {PetName}; they love the attention!");
            Console.ReadLine();
        }

        public override void DisplayPet()
        {
            Console.Clear();
            Console.WriteLine("===================================================================================");
            Console.WriteLine($"{PetName}                                                                         ");
            Console.WriteLine($"{PetType} {PetSpecies}                                                            ");
            Console.WriteLine("                                                                                   ");
            Console.WriteLine($"\tHealth: {PetHealth}\t\t Hunger: {PetHunger} \t\t Boredom: {PetBoredom}          ");
            Console.WriteLine("===================================================================================\n");
        }
    }
}
