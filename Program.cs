namespace template_csharp_virtual_pet
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            bool running = true;
            Shelter shelter = new Shelter();

            while (running)
            {
                Console.Clear();
                Console.WriteLine(@"
                                                                              __.-/|
                                                                              \`o_O'
                     .                                                         =( )=  +-----+
                    / V\                                                         U|   | Hi! |
                  / `  /                      /\   /\                  /\  /\   / |   +-----+    /|_/|
                 <<   |                      //\\_//\\     ____       ) /^\) ^\/ _)\     |      / ^ ^(_o
                 /    |                      \_     _/    /   /       )   /^\/   _) \    |     /    __.'
               /      |           ((`\        / * * \    /^^^]        )   _ /  / _)  \___|_    /     \
             /        |        ___ \\ '--._   \_\O/_/    [   ]    /\  )/\/ ||  | )_)\___,|))  (_) (_) '._
           /    \  \ /      .'`   `'    o  )   /   \_    [   /   <  >      |(,,) )__)    |      '.__     '. .-''-'.
          (      ) | |     /    \   '. __.'    \     \_  /  /     ||      /    \)___)\             ( '.   ('.____.''
  ________|   _/_  | |    _|   / _  \ \_\_      [ [ /  \/ _/      | \____(      )___) )____        _) )'_, )
<__________\______)\__)  {_\______\-'\__\_     _[ [ \  /_/         \______(_______;;;)__;;;)      (__/ (__/
");

                int screenWidth = Console.WindowWidth;
                int centered = (screenWidth - "WELCOME TO THE VIRTUAL PET SHELTER!".Length) / 2;
                Console.SetCursorPosition(centered, Console.CursorTop);
                Console.WriteLine("WELCOME TO THE VIRTUAL PET SHELTER!");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWhat would you like to do?\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1. Admit a new Organic Pet");
                Console.WriteLine("2. Admit a new Robotic Pet");
                Console.WriteLine("3. See all the Pets that are currently here");
                Console.WriteLine("4. Interact with a single Pet");
                Console.WriteLine("5. Interact with all Pets");
                Console.WriteLine("6. Adopt a Pet\n");
                Console.WriteLine("Press 'Q' to quit.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter your selection here: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                string mainMenuSelection = Console.ReadLine().ToLower();

                switch (mainMenuSelection)
                {
                    case "1":
                        Pet newOrganicPet = CreateNewPet(true);
                        shelter.Admit(newOrganicPet);
                        newOrganicPet.DisplayPet();
                        Console.ReadLine();
                        break;

                    case "2":
                        Pet newRoboticPet = CreateNewPet(false);
                        shelter.Admit(newRoboticPet);
                        newRoboticPet.DisplayPet();
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        shelter.DisplayAllPets();
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        Pet selectedPet = shelter.GetPet();
                        if (selectedPet != null)
                        {
                            selectedPet.InteractMenu();
                        }
                        else
                        {
                            Console.WriteLine("You have no pets to interact with.  Admit a pet to the shelter first!");
                            Console.ReadLine();
                        }
                        break;

                    case "5":
                        shelter.InteractAllMenu();
                        break;

                    case "6":
                        Console.Clear();
                        Pet adoptedPet = shelter.GetPet();
                        if (adoptedPet != null)
                        {
                            shelter.Adopt(adoptedPet);
                        }
                        else
                        {
                            Console.WriteLine("You have no pets to interact with.  Admit a pet to the shelter first!");
                        }
                        Console.ReadLine();
                        break;

                    case "q":
                        running = false;
                        Console.WriteLine("\nGood-bye! Come back anytime!");
                        break;

                    default:
                        break;
                }
                shelter.TickAll();
            }
        }

        static Pet CreateNewPet(bool isOrganic)
        {
            Console.Clear();
            string petName = NameMenu();
            string petSpecies = SpeciesMenu();
            if (isOrganic)
            {
                Organic newPet = new Organic(petName, petSpecies, "Organic", 60, 60, 60);
                return newPet;
            }
            else
            {
                Robotic newPet = new Robotic(petName, petSpecies, "Robotic", 60, 60, 60);
                return newPet;
            }
        }

        // Method to get the name of the Pet from the user
        static string NameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What is the name of your Pet?");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string nameInput = Console.ReadLine();
            return nameInput;
        }

        // Method to get the species of the Pet from the user
        static string SpeciesMenu()
        {
            int speciesSelection;
            string animal;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What is the species of your new Pet?");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1. Wolf");
                Console.WriteLine("2. Fox");
                Console.WriteLine("3. Red Panda");
                Console.WriteLine("4. Dragon");
                Console.WriteLine("5. Rabbit\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter a line number: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                speciesSelection = Convert.ToInt32(Console.ReadLine());
            }
            while (speciesSelection < 1 || speciesSelection > 5);

            switch (speciesSelection)
            {
                case 1:
                    animal = "Wolf";
                    break;
                case 2:
                    animal = "Fox";
                    break;
                case 3:
                    animal = "Red Panda";
                    break;
                case 4:
                    animal = "Dragon";
                    break;
                case 5:
                    animal = "Rabbit";
                    break;
                default:
                    animal = string.Empty;
                    break;
            }
            return animal;
        }
    }
}