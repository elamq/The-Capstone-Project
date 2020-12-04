using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Capstone_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //**********************************************************
            // Title: Mission 5: The Capsttone Project (A Journey West)
            // Application Type: Console
            // Description: This program is a game about
            //              traveling west on the Oregon Trail.
            //              It is meant to demonstrate coding skills
            // Author: Quentin Elam
            // Date Created: 11/17/2020
            // Last Modified: 12/04/2020
            // *********************************************************

            //
            // Set Theme
            //

            DisplaySetTheme();

            //
            // Opening Screen
            //

            DisplayOpeningScreen();

            //
            // Main Menu
            //

            DisplayMenuPrompt();
        }
        /// <summary>
        /// Display the main menu
        /// </summary>
        /// <returns></returns>
        private static bool DisplayMenuPrompt()
        {
            bool quitApplication = false;
            string menuChoice;
            Console.CursorVisible = true;
            do
            {

                Console.WriteLine();
                Console.WriteLine("\ta) Start Game");
                Console.WriteLine("\tb) Quit Game");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");

                menuChoice = Console.ReadLine().ToLower();
                Console.Clear();

                switch (menuChoice)
                {
                    case "a":
                        DisplayGameStart();
                        break;
                    case "b":
                        quitApplication = true;
                        DisplayClosingScreen();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter and option from the list.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);

            return quitApplication;
        }
        /// <summary>
        /// The main method for the game
        /// </summary>
        private static void DisplayGameStart()
        {
            (string char1, string char2, string char3) names;
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            Console.CursorVisible = false;

            bool gameOver = false;
            bool validResponse = false;
            bool char1Alive = true;
            bool char2Alive = true;
            bool char3Alive = true;
            bool char1Diseased = false;
            bool char2Diseased = false;
            bool char3Diseased = false;
            bool char1Poisoned = false;
            bool char2Poisoned = false;
            bool stopAndHunt = false;
            bool stopForWater = false;
            bool stopAtFort = false;
            bool attackNativeAmericans = false;
            bool antiVenom = false;
            bool shortPath = false;
            bool longPath = false;
            bool waitToCross = false;
            bool ferryRiver = false;
            bool floatWagon = false;
            bool oxDiedAtRiver = false;
            bool char2Saved = false;
            bool char2NotSaved = false;
            bool char1Saved = false;
            bool oxenKilledByLion = false;
            bool diedOfDysentery = false;

            inventory.food = 100;
            inventory.water = 100;
            inventory.supplies = 100;
            inventory.bullets = 15;
            inventory.oxen = 2;
            inventory.money = 50;
            inventory.exit = false;
            inventory.traderKilled = false;

            string userChoice;

            do
            {
                //
                // Alow the user to name their characters
                //

                names = DisplayCreateCharacterScreen();

                //
                // Show character status
                //

                DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tThe top of the screen shows the names of your characters and their status.");
                Console.WriteLine("\tIt will show up whenever there is a status change for one of your characters,");
                Console.WriteLine("\tor if it is important to know.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tYour journey begins in Kansas. You and your family own a farm, but recentely fell on hard times. You've");
                Console.WriteLine("\tdecided to pack up your things, load onto a wagon and travel west in hopes of a new and better life in Oregon.");
                Console.WriteLine("\tYou strap your two sturdy oxen to the front of your wagon in the hope that their years of plowing fields has");
                Console.WriteLine("\tprepared them for the trip. before leaving you toss your hunting rifle in the back");
                Console.WriteLine("\tand take one final look at what you're taking with you on the trip.");
                DisplayContinuePrompt();

                //
                // Show Inventory
                //

                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tThis is everything you're bringing with you on the trip, otherwise known as your inventory.");
                Console.WriteLine("\tKeep a close eye on your food and water becasue if you run out, it's game over.");
                Console.WriteLine("\tYou'll also want to pay attention to your supplies, bullets, oxen, and money, all of which are critcal to");
                Console.WriteLine("\tcompleting the trip. You will have opportunities to buy, sell, and trade items in your inventory down the road.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tAfter reviewing your inventory, you strap everything down and load everyone on to the wagon.");
                Console.WriteLine("\tEveryone is nervous, but excited for the chance at a new life.");
                Console.WriteLine("\tYou order the oxen to go, the wheels beging to spin,");
                Console.WriteLine("\tand the journey has begun...");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tYou and your family roll through forest after forest and field after field.");
                Console.WriteLine("\tThe oxen march forward as if unbothered by the weight they pull.");
                Console.WriteLine("\teventually you come to an open pasture. There is a small herd of buffalo grazing in the distance.");
                Console.WriteLine("\t\"This is a perfect opportunity to stock up on even more food,\" you think to yourself.");

                //
                // Option to stop and hunt
                //

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Stop to hunt buffalo");
                    Console.WriteLine("\tb) Continue journey");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");
                    userChoice = Console.ReadLine().ToLower();

                    switch (userChoice)
                    {
                        case "a":
                            validResponse = true;
                            inventory = DisplayHuntBuffalo(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            stopAndHunt = true;
                            break;
                        case "b":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou continue your journey and leve the buffalo to graze.");
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                //
                // Show user inventory
                //

                Console.WriteLine();
                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                DisplayContinuePrompt();
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("\tThe journey continues. As the wagon rolls across backwoods trails, you hear some rattleing from the wagon,");
                Console.WriteLine("\tbut that's a normal sound to hear given the circumstances. You continue following the trails for many miles,");
                Console.WriteLine("\tuntil stumbling across a road that appears more taveled. Clearly this road is used by many travelers,");
                Console.WriteLine("\ttraders, and the like. You beging following this trail because it leads west.");
                DisplayContinuePrompt();

                //
                // Trader encounter
                //

                Console.WriteLine("\tYou see something up the road. As you aproach, its silhouette becomes more defined, it's a person!");
                Console.WriteLine("\tA trader to be more exact. He is walking the trail with his large backpack full of various supplies.");
                Console.WriteLine("\tYou consider stopping to trade.");

                validResponse = false;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Stop to trade");
                    Console.WriteLine("\tb) Continue journey");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            validResponse = true;
                            DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            Console.WriteLine();
                            inventory = DisplayTradeWithTrader(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            break;
                        case "b":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide to continue your journey.");
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                Console.WriteLine();
                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tYou bid farewell to the trader.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tThe trail is long, but you're prepaired to handle it.");
                Console.WriteLine("\tYou're almost to Nebraska. Just a week or two more.");
                Console.WriteLine($"\t{names.char2} and {names.char3} assure you they are ready");
                Console.WriteLine("\tfor the rest of the trip.");
                DisplayContinuePrompt();

                //
                // Wagon Wheel Breaks
                //

                inventory = DisplayWagonWheelBreaks(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);

                DisplayContinuePrompt();

                //
                // Reach Nebraska
                //

                Console.WriteLine();
                Console.WriteLine("\tAfter many more miles on the trail, you and your family have begun to get used to the constant traveling.");
                Console.WriteLine("\tThe uncomfortable seats on the wagon might as well be royal thrones, and the bumps in the road have become");
                Console.WriteLine("\tlike smooth waves on the ocean.");
                Console.WriteLine();
                Console.WriteLine("\tAfter a quick check of your calendar, you realize that you've been traveling for a month and a half.");
                Console.WriteLine("\tThis means that by now you've reached Nebraska. You anounce this to your family, and they beam with joy!");
                DisplayContinuePrompt();

                inventory = DisplayResourceDrain(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);

                //
                // Starts to rain
                //

                Console.WriteLine();
                Console.WriteLine("\tNot long after you enter Nebraska, you notice the skys begin to darken.");
                Console.WriteLine("\tThere's a storm coming, you think to yourself. It would be a good chance to refil a little water.");
                Console.WriteLine("\tOn the other hand, stopping for a little water could delay your journey.");

                do
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Stop to gather water");
                    Console.WriteLine("\tb) Continue journey");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            validResponse = true;
                            stopForWater = true;
                            inventory.water = inventory.water + 10;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide it's more important to collect water than stay on schedule.");
                            Console.WriteLine("\tas the dark clouds roll in, you set up a rain catcher.");
                            Console.WriteLine("\tYou also take this opportunity to clean yourselves, as the stench was becoming noticeable.");
                            Console.WriteLine();
                            Console.WriteLine("\tAfter the rain passes, you check to see how much water you collected");
                            Console.WriteLine();
                            Console.WriteLine("\tyou gained 10 water.");
                            Console.WriteLine();
                            DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            Console.WriteLine();
                            break;
                        case "b":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide to continue your journey.");
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                DisplayContinuePrompt();


                //
                // Come across fort
                //

                validResponse = false;

                Console.WriteLine();
                Console.WriteLine("\tAs your travels bring you deeper into Nebraska, you start to notice more and more travelers on the road.");
                Console.WriteLine("\tThere must be a town or something nearby, you think to yourself.");
                Console.WriteLine("\tYou continue for a few more miles and as your wagon crests a large hill, you can see in the distance a large");
                Console.WriteLine("\tstructure. A fort! They will have lots of things to trade there. You and your family near the fort.");

                if (inventory.traderKilled == true)
                {
                    Console.WriteLine("\tAs you approach, you notice signs posted that say a trader was killed.");
                    Console.WriteLine("\tReports say that the person who discovered the body saw a family of three traveling away from the body.");
                    Console.WriteLine("\tThe signs also say to be on the lookout and report any findings to the fort.");
                }

                do
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Enter the fort to trade");
                    Console.WriteLine("\tb) Continue journey");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            gameOver = false;
                            validResponse = true;
                            stopAtFort = true;
                            if (inventory.traderKilled == true)
                            {
                                DisplayArrestedAtFort(names.char2, names.char3);
                                DisplayGameOver();
                                gameOver = true;
                                return;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("\tYou roll through the front gates of the fort.");
                                Console.WriteLine("\tThey have anything you could ever want here.");
                                Console.WriteLine("\tYou look through the different deals offered by the fort.");
                                Console.WriteLine();
                                Console.WriteLine("\tWith this trader you can trade as many times as you want as long as you have enough resources to trade.");
                                Console.WriteLine();

                                do
                                {
                                    DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                    inventory = DisplayTradeWithFort(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                } while (!inventory.exit);
                            }
                            break;
                        case "b":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide to continue your journey.");
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                Console.WriteLine();
                Console.WriteLine("\tYou continue your journey and move on from the fort.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tA few weeks go by and you remember that someone from the fort told you that");
                Console.WriteLine("\tonce you reach and get across the river you'll have arived in Wyoming.");

                //
                // food and water check
                //

                if (inventory.food <= 0 && inventory.water >= 1)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tThere is just one problem though, you've run out of food!");
                    Console.WriteLine("\tIt does not take long for starvation to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of starvation.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;

                }
                else if (inventory.water <= 0 && inventory.food >= 1)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tThere is just one problem though, you've run out of water!");
                    Console.WriteLine("\tIt does not take long for dehydration to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of dehydration.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }
                else if (inventory.food <= 0 && inventory.water <= 0)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tThere is just one problem though, you've run out of food and water!");
                    Console.WriteLine("\tIt does not take long for starvation and dehydration to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of starvation and dehydration.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }

                //
                // Come across river
                //

                inventory = DisplayResourceDrain(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);

                validResponse = false;

                if (stopAndHunt == true || stopForWater == true)
                {
                    Console.WriteLine("\tYou can hear the river from quite a distance away.");
                    Console.WriteLine("\tPeople from the fort also said that if we make it in time there is a chance we could");
                    Console.WriteLine("\ttake the ferry across.");
                    DisplayContinuePrompt();

                    Console.WriteLine();
                    Console.WriteLine("\tAs you roll up to the river you realize that, because you made so many stops, the ferry has left already,");
                    Console.WriteLine("\tthe water level has risen significantly, and the river is moving faster than you expected.");
                    Console.WriteLine("\tYou're left with only a few choices.");
                    Console.WriteLine("\tYou could float your wagon across, at the risk of damaging the wagon, losing resources,");
                    Console.WriteLine("\tor even overturning the whole wagon. Your other choices are to wait for the water level to go down enough");
                    Console.WriteLine("\tthat the wheels can touch the riverbed and can be rolled across, or you can wait for the ferry to come back.");
                    Console.WriteLine("\tIt could take days or weeks for the water level to go down and for the ferry to return.");

                    do
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tWould you like to:");
                        Console.WriteLine("\ta) Float your waggon across.");
                        Console.WriteLine("\tb) Wait to see if conditions improve or for the ferry to come back.");
                        Console.WriteLine();
                        Console.Write("\tEnter Choice:");

                        userChoice = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        switch (userChoice)
                        {
                            case "a":
                                floatWagon = true;
                                validResponse = true;
                                inventory = DisplayFloatWagon(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                Console.WriteLine("\tYou take a look at what you did lose when crossing the river.");
                                Console.WriteLine();
                                Console.WriteLine("\tIt looks like you lost 20 food and 15 water from when the wagon hit the sandbar.");
                                if (inventory.oxen == 1)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("\tAnd of course, you lost an ox...");
                                    oxDiedAtRiver = true;
                                }
                                DisplayContinuePrompt();
                                break;
                            case "b":
                                waitToCross = true;
                                validResponse = true;
                                inventory = DisplayWaitToCrossRiver(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                break;
                            default:
                                validResponse = false;
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                break;
                        }
                    } while (!validResponse);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tYou roll up to the river, and it looks like you made it just in time.");
                    Console.WriteLine("\tThere is a ferry getting ready to cross the river, but that is not the only way to get across.");

                    do
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tWould you like to:");
                        Console.WriteLine("\ta) Take the ferry across (costs 15 dollars).");
                        Console.WriteLine("\tb) Float your waggon across.");
                        Console.WriteLine("\tc) Wait to see if the water goes down to ford the river or");
                        Console.WriteLine("\t   for the ferry to go across and come back.");
                        Console.WriteLine();
                        Console.Write("\tEnter Choice:");

                        userChoice = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        switch (userChoice)
                        {
                            case "a":
                                ferryRiver = true;
                                validResponse = true;
                                DisplayTakeFerry();
                                inventory.money = inventory.money - 15;
                                break;
                            case "b":
                                validResponse = true;
                                floatWagon = true;
                                inventory = DisplayFloatWagon(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                Console.WriteLine("\tYou take a look at what you lost when crossing the river.");
                                Console.WriteLine();
                                Console.WriteLine("\tIt looks like you lost 20 food and 15 water from when the wagon hit the sandbar.");
                                if (inventory.oxen == 1)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("\tAnd of course, you lost an ox...");
                                    oxDiedAtRiver = true;
                                }
                                DisplayContinuePrompt();
                                break;
                            case "c":
                                waitToCross = true;
                                validResponse = true;
                                inventory = DisplayWaitToCrossRiver(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                break;
                            default:
                                validResponse = false;
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                break;
                        }
                    } while (!validResponse);
                }

                //
                // food and water check
                //

                if (inventory.food <= 0 && inventory.water >= 1)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tAfter crossing the river, you check your resources. Oh no, you've run out of food!");
                    Console.WriteLine("\tIt does not take long for starvation to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of starvation.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }
                else if (inventory.water <= 0 && inventory.food >= 1)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tAfter crossing the river, you check your resources. Oh no, you've run out of water!");
                    Console.WriteLine("\tIt does not take long for dehydration to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of dehydration.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }
                else if (inventory.food <= 0 && inventory.water <= 0)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tAfter crossing the river, you check your resources. Oh no, you've run out of food and water!");
                    Console.WriteLine("\tIt does not take long for starvation and dehydration to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of starvation and dehydration.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }

                //
                // Made it to Wyoming
                //

                Console.WriteLine();
                Console.WriteLine("\tAfter crossing the river you realize that you've made it to Wyoming!");
                Console.WriteLine("\tYou anounce to your family that you're about halfway there!");

                //
                // Possibility for disease
                //

                if (stopForWater == true || inventory.traderKilled == true)
                {
                    char3Diseased = true;
                    Console.WriteLine();
                    Console.WriteLine($"\tAfter the exitment settles, {names.char3} anounces that they don't feel so good.");
                    Console.WriteLine($"\tYou ask {names.char3} what symptoms they are feeling.");
                    Console.WriteLine($"\tBefore {names.char3} can finish talking, you can already guess that they have contracted dysentery.");
                    Console.WriteLine("\tYou must have picked up contaminated food or water somewhere, you think to yourself.");
                    Console.WriteLine("\tYou decide it best to throw out anything that might be contaminated.");
                    DisplayContinuePrompt();
                    if (inventory.traderKilled == true)
                    {
                        DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                        Console.WriteLine();
                        Console.WriteLine("\tYou suspect that the infected food came from the trader you killed, so you throw out what is left of");
                        Console.WriteLine("\tthe food you stole from him.");
                        Console.WriteLine("\tYou lose 25 food.");
                        if (inventory.food < 25)
                        {
                            inventory.food = 0;
                        }
                        inventory.food = inventory.food - 25;
                    }
                    else
                    {
                        DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                        Console.WriteLine();
                        Console.WriteLine("\tYou throw out some food and water that you think might be the culprit.");
                        Console.WriteLine("\tYou lose 10 food and 5 water");
                        inventory.food = inventory.food - 10;
                        inventory.water = inventory.water - 5;
                    }
                }

                DisplayContinuePrompt();

                DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);

                if (char3Diseased == true)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"\t{names.char3} has disentary.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone is still healthy and alive.");
                }

                DisplayContinuePrompt();

                //
                // Native American Encounter
                //

                Console.WriteLine();
                Console.WriteLine("\tAfter spending some time in Wyoming, you and your family are begining to settle in again.");
                Console.WriteLine("\tIt has been a while since anything significant has happened.");
                Console.WriteLine("\tYou're hoping the rest of the journey will continue without a hitch.");

                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tIt's starting to get late now, and in the distance you can just barely see the peaks of the rocky mountains,");
                Console.WriteLine("\twhich are an important milestone in the journey to Oregon.");
                Console.WriteLine("\tHowever, a much more imediate encounter apears at the treeline.");
                Console.WriteLine("\tIt appears that a small group of Native Americans are preparing to hunt wild buffalo.");
                Console.WriteLine("\tThey don't seem bothered by your presence, and they appear to be waiting for you to pass.");

                do
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Stop to greet them");
                    Console.WriteLine("\tb) (Attack them)");
                    Console.WriteLine("\tc) Continue journey");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            validResponse = true;
                            inventory = DisplayGreetNativeAmericans(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            Console.WriteLine();
                            break;
                        case "b":
                            attackNativeAmericans = true;
                            validResponse = true;
                            inventory = DisplayAttackNativeAmericans(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            if (inventory.bullets < 10)
                            {
                                gameOver = true;
                                return;
                            }
                            else
                            {
                                inventory.bullets = inventory.bullets - 10;

                                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                Console.WriteLine("\tYou gain 25 food and 20 water.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tAfter the dust settles, you check to see if your family is ok...");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine($"\tWith tears in their eyes, {names.char3}, holds {names.char2} in their arms.");
                                Console.WriteLine($"\t{names.char2} took an arrow to the heart during the fight. They died before you");
                                Console.WriteLine("\tHad a chance to say goodbye.");
                                DisplayContinuePrompt();
                                char2Alive = false;
                                DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine($"\t{names.char2} has died.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tAs you loot through the Native Americans supplies, you notice a strange bottle full of an unknown liquid.");

                                do
                                {
                                    validResponse = false;
                                    Console.WriteLine();
                                    Console.WriteLine("\tWould you like to:");
                                    Console.WriteLine();
                                    Console.WriteLine("\ta) Take Vial");
                                    Console.WriteLine("\tb) Continue journey");
                                    Console.WriteLine();
                                    Console.Write("\tEnter Choice:");

                                    userChoice = Console.ReadLine().ToLower();
                                    Console.WriteLine();
                                    switch (userChoice)
                                    {
                                        case "a":
                                            validResponse = true;
                                            Console.WriteLine();
                                            Console.WriteLine("\tYou decide to take the vial.");
                                            antiVenom = true;
                                            break;
                                        case "b":
                                            validResponse = true;
                                            Console.WriteLine();
                                            Console.WriteLine("\tYou decide to continue your journey.");
                                            break;
                                        default:
                                            validResponse = false;
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                            break;
                                    }
                                } while (!validResponse);
                            }
                            break;
                        case "c":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide to continue your journey.");
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                DisplayContinuePrompt();

                //
                // chance to buy anti-venom
                //

                if (attackNativeAmericans == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tBefore you can continue the Native Americans tell you that if you're headed toward");
                    Console.WriteLine("\tthe mountains, you should watch out for rattlesnakes.");
                    Console.WriteLine("\tThey tell you that they have anti-venom if you would like to trade for it.");
                    Console.WriteLine();

                    DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);

                    do
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tWould you like to:");
                        Console.WriteLine();
                        Console.WriteLine("\ta) Trade 30 food and 20 water for rattle snake anti-venom");
                        Console.WriteLine("\tb) Continue journey");
                        Console.WriteLine();
                        Console.Write("\tEnter Choice:");

                        userChoice = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        switch (userChoice)
                        {
                            case "a":
                                if (inventory.food < 40 || inventory.water < 30)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("\tYou do not have enough food or water to trade.");
                                    DisplayContinuePrompt();
                                }
                                else
                                {
                                    validResponse = true;
                                    antiVenom = true;
                                    Console.WriteLine();
                                    Console.WriteLine("\tYou tell them you want the anti-venom, so you give them some of your food and water.");
                                    inventory.food = inventory.food - 30;
                                    inventory.water = inventory.water - 20;
                                    Console.WriteLine();
                                    DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                    Console.WriteLine();
                                    Console.WriteLine("\tYou loose 30 food and 20 water.");
                                }
                                break;
                            case "b":
                                validResponse = true;
                                Console.WriteLine();
                                Console.WriteLine("\tYou decide to continue your journey.");
                                break;
                            default:
                                validResponse = false;
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                break;
                        }
                    } while (!validResponse);
                }

                Console.WriteLine();
                Console.WriteLine("\tYou move on from that encounter.");
                Console.WriteLine("\tNext stop: The Rocky Mountains.");
                DisplayContinuePrompt();


                //
                // Arrive at Rocky Mountains
                //

                Console.WriteLine("\tThe mountains are closer now. You can feel the air becoming colder.");
                Console.WriteLine("\tAs you approach the base of the mountain, you notice that the path diverges.");
                Console.WriteLine("\tOne leads up the mountain. One leads around.");
                Console.WriteLine("\tGoing over the mountain is surely more dangerous, but it will get you to oregon faster.");
                Console.WriteLine("\tGoing around will take longer, but it is the safest path.");
                Console.WriteLine();
                Console.WriteLine("\tYou have a decision to make.");

                do
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Take the short path over the mountian.");
                    Console.WriteLine("\tb) Take the long path around the mountian.");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            shortPath = true;
                            validResponse = true;
                            inventory = DisplayTakeShortPath(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            if (inventory.oxen == 0)
                            {
                                gameOver = true;
                                DisplayGameOver();
                                return;
                            }
                            else if (inventory.oxen == 1)
                            {
                                oxenKilledByLion = true;
                            }
                            break;
                        case "b":
                            longPath = true;
                            validResponse = true;
                            inventory = DisplayTakeLongPath(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            if (inventory.bullets == 10 && inventory.oxen == 0)
                            {
                                gameOver = true;
                                DisplayGameOver();
                                return;
                            }
                            else if (inventory.traderKilled == true)
                            {
                                if (char2Alive == false)
                                {

                                    Console.WriteLine();
                                    Console.WriteLine("\tbut no one responds.");
                                    Console.WriteLine($"\tIn the confusion, {names.char3} was shot by the Pinkertons.");
                                    Console.WriteLine("\tYou're the only one left...");
                                    char3Alive = false;
                                    DisplayContinuePrompt();
                                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                                    Console.WriteLine();
                                    Console.WriteLine($"\t{names.char3} has died.");
                                    DisplayContinuePrompt();
                                    Console.WriteLine("\tYour journey continues...");
                                }
                                else
                                {

                                    Console.WriteLine();
                                    Console.WriteLine($"\tOnly {names.char2} responds.");
                                    Console.WriteLine($"\tIn the confusion, {names.char3} was shot by the Pinkertons.");
                                    char3Alive = false;
                                    DisplayContinuePrompt();
                                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                                    Console.WriteLine();
                                    Console.WriteLine($"\t{names.char3} has died.");
                                    DisplayContinuePrompt();
                                    Console.WriteLine("\tYour journey continues...");
                                }
                            }
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                //
                // food and water check
                //

                if (inventory.food <= 0 && inventory.water >= 1)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tA few days go by, and you stop to check your resources. Oh no, you've run out of food!");
                    Console.WriteLine("\tIt does not take long for starvation to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of starvation.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }
                else if (inventory.water <= 0 && inventory.food >= 1)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tA few days go by, and you stop to check your resources. Oh no, you've run out of water!");
                    Console.WriteLine("\tIt does not take long for dehydration to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of dehydration.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }
                else if (inventory.food <= 0 && inventory.water <= 0)
                {
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tA few days go by, and you stop to check your resources. Oh no, you've run out of food and water!");
                    Console.WriteLine("\tIt does not take long for starvation and dehydration to set in...");
                    DisplayContinuePrompt();
                    char1Alive = false;
                    char2Alive = false;
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine("\tEveryone has died of starvation and dehydration.");
                    DisplayContinuePrompt();
                    DisplayGameOver();
                    gameOver = true;
                    return;
                }

                //
                // Down the mountain to Idaho
                //

                if (shortPath == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tYou continue down the west side of the mountain in the hopes that you don't encounter any more wildlife.");
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tEventually you reach the base.");
                    DisplayContinuePrompt();
                }
                if (longPath == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tYou finally make it around the mountain.");
                }

                Console.WriteLine();
                Console.WriteLine("\tYou've entered Idaho. The last leg of the journey.");
                Console.WriteLine("\tYou take a deep breath and push forward");
                DisplayContinuePrompt();
                Console.WriteLine();
                Console.WriteLine("\tYou've heard that potatos have become popular in Idaho, but you see crops of all kinds growing here.");
                Console.WriteLine("\tYou could stop and pick some. This might be your last chance to gather a little food");
                Console.WriteLine("\tbefore you make it to oregon.");

                //
                // Rattlesnake
                //

                do
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine();
                    Console.WriteLine("\ta) Stop to gather a little food");
                    Console.WriteLine("\tb) Continue journey");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou stop to pick some crops and sure up your food supplies for the last leg of the journey.");
                            Console.WriteLine("\tYou can tell that the soil here is fertile. It's good for everything they grow here.");
                            Console.WriteLine("\tAll of the crops you pull are large and healthy. It gives you hope that you made the right choice,");
                            Console.WriteLine("\tleaving everything behind for Oregon.");
                            DisplayContinuePrompt();
                            if (char2Alive == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"\tAs you load the food you gathered into the wagon, You hear {names.char2} scream in pain.");
                                Console.WriteLine($"\tYou rush over to see what's wrong. {names.char2} is sitting on the ground clutcing their ankle.");
                                Console.WriteLine($"\tYou see the tail end of a huge rattler slither into the fields.");
                                if (antiVenom == true)
                                {
                                    char2Saved = true;
                                    Console.WriteLine();
                                    Console.WriteLine("\tYou run over to the wagon to grab the anti-venom that you got form the Native Americans.");
                                    Console.WriteLine($"\tYou quickly give it to {names.char2}.");
                                    Console.WriteLine($"\tAll you can do now is hope that {names.char2} will be ok...");
                                    DisplayContinuePrompt();
                                }
                                else
                                {
                                    char2NotSaved = true;
                                    Console.WriteLine();
                                    Console.WriteLine("\tOh no, what are you going to do. There's nothing you can do.");
                                    Console.WriteLine($"\tYou know that it takes less than 48 hours for rattlesnake venom");
                                    Console.WriteLine("\tto kill a person.");
                                    DisplayContinuePrompt();
                                    Console.WriteLine();
                                    Console.WriteLine($"\tIt does not take long for {names.char2} to succumb to its deadly effects.");
                                    DisplayContinuePrompt();
                                    char2Alive = false;
                                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine($"\t{names.char2} has died.");
                                    DisplayContinuePrompt();
                                }

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("\tAs you load the food you gathered into the wagon, you hear a strange rattling.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tYou freeze. There is a rattlesnake right in front of your feet.");
                                Console.WriteLine("\tIt strikes before you can react, and it sinks its teeth into your ankle.");
                                Console.WriteLine("\tYou holler in pain. The snake slithers back into the fields.");
                                if (antiVenom == true)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("\tOh no, what are you going to do. There's nothing you can do.");
                                    Console.WriteLine($"\tYou know that it takes less than 48 hours for rattlesnake venom");
                                    Console.WriteLine("\tto kill a person.");
                                    DisplayContinuePrompt();
                                    Console.WriteLine();
                                    Console.WriteLine("\tIn your panic, you see that strange liquid you stole from the Native Americans.");

                                    do
                                    {
                                        validResponse = false;
                                        Console.WriteLine();
                                        Console.WriteLine("\tWould you like to:");
                                        Console.WriteLine();
                                        Console.WriteLine("\ta) Drink the strange liquid.");
                                        Console.WriteLine("\tb) Do nothing");
                                        Console.WriteLine();
                                        Console.Write("\tEnter Choice:");

                                        userChoice = Console.ReadLine().ToLower();
                                        Console.WriteLine();
                                        switch (userChoice)
                                        {
                                            case "a":
                                                validResponse = true;
                                                Console.WriteLine();
                                                Console.WriteLine("\tYou decide to drink the strange vial...");
                                                DisplayContinuePrompt();
                                                Console.WriteLine("\tIt soothes your pain almost instantly.");
                                                Console.WriteLine("\tYou're shocked.");
                                                Console.WriteLine("\tDid that strange liquid save you?");
                                                DisplayContinuePrompt();
                                                Console.WriteLine("\tYou realize that all you can do is wait, so you continue on.");
                                                DisplayContinuePrompt();
                                                char1Saved = true;
                                                break;
                                            case "b":
                                                validResponse = true;
                                                Console.WriteLine();
                                                Console.WriteLine("\tYou decide to do nothing.");
                                                Console.WriteLine("\tYou feel the venom coursing through your body");
                                                Console.WriteLine("\tIt does not take long for you to succumb to its deadly effects.");
                                                DisplayContinuePrompt();
                                                char1Alive = false;
                                                DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                                                Console.WriteLine();
                                                Console.WriteLine($"\t{names.char1} has died.");
                                                DisplayContinuePrompt();
                                                DisplayGameOver();
                                                gameOver = true;
                                                return;
                                                break;
                                            default:
                                                validResponse = false;
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                                break;
                                        }
                                    } while (!validResponse);

                                }
                                else
                                {
                                    Console.WriteLine("\tOh no, what are you going to do. There's nothing you can do.");
                                    Console.WriteLine($"\tYou know that it takes less than 48 hours for rattlesnake venom");
                                    Console.WriteLine("\tto kill a person.");
                                    DisplayContinuePrompt();
                                    Console.WriteLine();
                                    Console.WriteLine("\tAll you can do is wait...");
                                    DisplayContinuePrompt();
                                    char1Alive = false;
                                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                                    Console.WriteLine();
                                    Console.WriteLine($"\t{names.char1} has died.");
                                    DisplayContinuePrompt();
                                    DisplayGameOver();
                                    gameOver = true;
                                    return;
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("\tYou finish loading the food you gathered into the wagon.");
                            Console.WriteLine();
                            inventory.food = inventory.food + 15;
                            DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                            Console.WriteLine();
                            Console.WriteLine("\tYou gained 15 food.");

                            break;
                        case "b":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide to continue your journey.");
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);

                //
                // Dysentery
                //

                Console.WriteLine();
                Console.WriteLine("\tThe wagon rolls on. This has been a tough journey, but you can't stop now.");
                Console.WriteLine("\tYou know that once you get to Oregon, all your struggles will have been worth it.");
                Console.WriteLine("\tIt has to be worth it.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tThe days pass like seconds.");
                DisplayContinuePrompt();

                if (char3Diseased == true && char3Alive == true)
                {
                    Console.WriteLine($"\t{names.char3} is barely holding on.");
                    Console.WriteLine("\tThe dysentery has been brutal. You know it wont be long now");
                    Console.WriteLine("\tbefore you have to say goodbye.");
                    DisplayContinuePrompt();
                }

                Console.WriteLine();
                Console.WriteLine("\tYou've been on the road for so long now.");
                Console.WriteLine("\tYou can't wait for it to be over.");

                if (char3Diseased == true && char3Alive == true)
                {
                    Console.WriteLine($"\t{names.char3} passes in the night.");
                    DisplayContinuePrompt();
                    char3Alive = false;
                    DisplayCharacterStatus(names.char1, names.char2, names.char3, char1Alive, char2Alive, char3Alive, char1Diseased, char2Diseased, char3Diseased, char1Poisoned, char2Poisoned);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"\t{names.char3} has died of dysentery.");
                    DisplayContinuePrompt();
                    diedOfDysentery = true;
                }

                //
                // Reflection
                //

                Console.WriteLine();
                Console.WriteLine("\tYou're so close now. All your efforts might just pay off after all.");
                Console.WriteLine("\tAs your wagon rolls forward, you reflect on everythng that got you here.");
                DisplayContinuePrompt();

                if (inventory.traderKilled == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tNot long after you left Kansas, you ran into that trader, and you shot him dead.");
                    Console.WriteLine("\tYou'll never forget the look on your families faces.");
                    Console.WriteLine("\tHow could you have done such a thing...");
                    DisplayContinuePrompt();
                    Console.WriteLine();
                    Console.WriteLine("\tThen your wagon wheel fell off.");
                    Console.WriteLine("\tThere was a time when you thought that a wagon wheel falling off would be");
                    Console.WriteLine("\tthe hardest challenge that would be faced on this journey.");
                    DisplayContinuePrompt();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tThe first problem you encountered was when your wagon wheel fell off.");
                    Console.WriteLine("\tThere was a time when you thought that a wagon wheel falling off would be");
                    Console.WriteLine("\tthe hardest challenge that would be faced on this journey.");
                    DisplayContinuePrompt();
                }

                Console.WriteLine();
                Console.WriteLine("\tThen you made it to Nebraska.");

                if (stopAtFort == true)
                {
                    Console.WriteLine("\tThat fort you stoped at was impressive.");
                    Console.WriteLine("\tThey had some cool things in there.");
                }
                else
                {
                    Console.WriteLine("\tYou decided to not stop at the fort.");
                }

                Console.WriteLine("\tThat was the last sign of modern civilization that you saw after embarking on your journey.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tAfter that, you came to a river that needed crossing.");

                if (floatWagon == true)
                {
                    Console.WriteLine("\tYou chose to float your wagon across, you knew it would be risky,");

                    if (oxDiedAtRiver == true)
                    {
                        Console.WriteLine("\tand you lost an ox because of it.");
                    }

                    Console.WriteLine("\tbut you came out of it with minimal losses.");
                    DisplayContinuePrompt();
                }

                if (waitToCross == true)
                {
                    Console.WriteLine("\tYou chose to wait for a better opportunity to cross,");
                    Console.WriteLine("\tand it seemed to mostly work out for you.");
                    DisplayContinuePrompt();
                }

                if (ferryRiver == true)
                {
                    Console.WriteLine("\tYou got to ferry the river, and you got across with no problems.");
                    DisplayContinuePrompt();
                }

                Console.WriteLine();
                Console.WriteLine("\tThen you were in Wyoming.");
                Console.WriteLine("\tThe views there were gorgeous.");
                DisplayContinuePrompt();

                if (char3Diseased == true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tUnfortunately, that's where you discovered that {names.char3} contracted dysentery,");
                    Console.WriteLine("\tand in the end, there was nothing you could do for them.");
                    DisplayContinuePrompt();
                }

                Console.WriteLine();
                Console.WriteLine("\tWhen you encountered those Native Americans, you were a little worried,");

                if (attackNativeAmericans == true)
                {
                    Console.WriteLine("\tand that worry got the best of you.");
                    Console.WriteLine("\tYou killed them all. Like a monster.");
                    Console.WriteLine($"\tBecause of what you did, {names.char2} was killed.");
                    DisplayContinuePrompt();
                }
                else
                {
                    Console.WriteLine("\tbut they turned out to be nice people.");
                    DisplayContinuePrompt();
                }

                if (char2Saved == true)
                {

                    Console.WriteLine($"\tand it ended up saving {names.char2}'s life.");
                    DisplayContinuePrompt();

                }

                if (char2NotSaved == true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou didn't take their anti-venom, and it cost {names.char2} their life.");
                    DisplayContinuePrompt();
                }

                Console.WriteLine();
                Console.WriteLine("\tYou can remember the incredible sight of the rocky mountains.");
                DisplayContinuePrompt();

                if (shortPath == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tYou decided to take the short path over the mountains,");
                    Console.WriteLine("\tand your ox got attacked by a mountain lion.");
                    if (oxenKilledByLion == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tYou had to watch as your ox got mauled to death.");
                        Console.WriteLine("\tYou're just lucky it didn't come for you next.");
                        DisplayContinuePrompt();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tLuckily, you had enough bullets to save your ox.");
                        DisplayContinuePrompt();
                    }
                }

                if (longPath == true)
                {
                    Console.WriteLine("\tYou decided to take the long path around the mountain.");

                    if (inventory.traderKilled == true)
                    {
                        Console.WriteLine("\tYou barely escaped those pinkertons.");
                        Console.WriteLine($"\tbut your actions got {names.char3} killed");
                        DisplayContinuePrompt();
                    }
                    else
                    {
                        Console.WriteLine("\tIt was a long, but pleasant route.");
                        DisplayContinuePrompt();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("\tFinally, you made it to Idaho.");

                if (char1Saved == true)
                {
                    Console.WriteLine("\tYou're close encounter with that rattlesnake is still fresh in your mind.");
                    if (antiVenom == true && attackNativeAmericans == true)
                    {
                        Console.WriteLine("\tLuckily you took that strange vial.");
                    }
                    DisplayContinuePrompt();
                }

                else if (char2Saved == true)
                {
                    Console.WriteLine($"\t{names.char2}'s close encounter with that rattlesnake is still fresh in your mind.");
                    DisplayContinuePrompt();
                }
                else if (char2NotSaved == true)
                {
                    Console.WriteLine($"\tYou still haven't been able to fully grieve for {names.char2}.");
                    if (char3Diseased == true)
                    {
                        Console.WriteLine($"\tNot to mention {names.char3} who died shortly after.");
                        DisplayContinuePrompt();
                    }
                }

                if (char3Diseased == true && char2NotSaved == false && diedOfDysentery == true)
                {
                    Console.WriteLine($"\tYou still haven't been able to fully greave for {names.char3}");
                    DisplayContinuePrompt();
                }

                Console.WriteLine();
                Console.WriteLine("\tYou're long journey has almost come to a close.");
                Console.WriteLine("\tAs you finish reflecting on your journey, you see it.");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\t\tWelcome to Oregon City");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tCongratulations, you have completed your journey.");
                Console.WriteLine();
                Console.WriteLine("\tThanks for playing.");
                DisplayContinuePrompt();
                Console.WriteLine();
                Console.WriteLine("\tPlay again?");
                gameOver = true;

            } while (!gameOver);
        }

        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayResourceDrain(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            bool validResponse = false;
            string userChoice;

            Console.WriteLine();
            Console.WriteLine("\tYou've been traveling for a while now.");
            Console.WriteLine("\tYou have surely lost some resources since the last time you stoped.");

            if (inventory.food < 20)
            {
                inventory.food = 0;
            }
            else
            {
                inventory.food = inventory.food - 20;
            }

            if (inventory.water < 30)
            {
                inventory.water = 0;
            }
            else
            {
                inventory.water = inventory.water - 30;
            }


            do
            {
                validResponse = false;
                Console.WriteLine();
                Console.WriteLine("\tWould you like to:");
                Console.WriteLine();
                Console.WriteLine("\ta) Stop to check inventory");
                Console.WriteLine("\tb) Continue journey");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");

                userChoice = Console.ReadLine().ToLower();
                Console.WriteLine();
                switch (userChoice)
                {
                    case "a":
                        validResponse = true;
                        Console.WriteLine();
                        DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                        Console.WriteLine();
                        Console.WriteLine("\tIt looks like you've lost 20 food and 30 water.");
                        Console.WriteLine();
                        break;
                    case "b":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou decide to continue your journey.");
                        break;
                    default:
                        validResponse = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                        break;
                }
            } while (!validResponse);

            DisplayContinuePrompt();

            return inventory;
        }

        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayTakeLongPath(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            bool validResponse = false;
            string userChoice;

            Console.WriteLine();
            Console.WriteLine("\tYou decide to take the long way around because it should be safer.");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tIt's going to take a while to get all the way around the mountain, but at least");
            Console.WriteLine("\tthere shouldn't be any mountian lions on this path.");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tThe sights along this path are quite beautiful. Unlike anything you've seen in Kansas.");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tThis path is taking even longer than you thought, you've already burned through quite a bit of food and water.");
            inventory.food = food - 20;
            inventory.water = water - 30;
            DisplayContinuePrompt();
            DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
            Console.WriteLine();
            Console.WriteLine("\tYou have lost 20 food and 30 water.");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tAs the sun sets behind the mountains, you stop to make camp for the night.");
            DisplayContinuePrompt();
            if (traderKilled == true)
            {
                Console.WriteLine();
                Console.WriteLine("\tAs you lay awake staring at the stars, you can't help but think about the trader you killed.");
                Console.WriteLine("\tWho knows what his life was like, but before you have to much time to feel guilty, you hear someone shout");
                Console.WriteLine("\tfrom just outside your camp.");
                Console.WriteLine();
                Console.WriteLine("\t\"THIS IS THE PINKERTON DETECTIVE AGENCY. WE CAUGHT WIND OF A MURDER BACK IN KANSAS.");
                Console.WriteLine("\tCOME OUT WITH YOUR HANDS UP, AND WE WON'T HAVE A PROBLEM.\"");
                DisplayContinuePrompt();

                Console.WriteLine();
                Console.WriteLine("\tYou know you're done for if you turn yourself in. You'll have to shoot your way out.");

                do
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tWould you like to:");
                    Console.WriteLine("\ta) Use the cover of night to get the jump on them.");
                    Console.WriteLine("\tb) Attack them head on.");
                    Console.WriteLine();
                    Console.Write("\tEnter Choice:");

                    userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case "a":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou sneak off into the treeline. They'll never see you coming.");
                            if (inventory.bullets < 10)
                            {
                                validResponse = true;
                                Console.WriteLine();
                                Console.WriteLine("\tAll is silent. You line up your shot.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tBAM!");
                                DisplayContinuePrompt();
                                Console.WriteLine("\tA bullet pierces your chest. This is the end of your journey.");
                                inventory.bullets = 0;
                                inventory.oxen = 0;
                            }
                            else
                            {
                                validResponse = true;
                                Console.WriteLine();
                                Console.WriteLine("\tAll is silent. You line up your shot.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tBAM!");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tYou take them down one by one. They are too disoriented to see where they are getting shot from.");
                                Console.WriteLine("\tThe last one hits the ground...");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tYou call out to your family...");
                                inventory.bullets = bullets - 10;
                            }
                            break;
                        case "b":
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou decide to attack them head on.");
                            if (inventory.bullets < 20)
                            {
                                validResponse = true;
                                Console.WriteLine();
                                Console.WriteLine("\tAll is silent. Until you charge them head on, while screaming at the top of your lungs.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tBAM!");
                                DisplayContinuePrompt();
                                Console.WriteLine("\tA bullet pierces your chest. This is the end of your journey.");
                                inventory.bullets = 0;
                                inventory.oxen = 0;
                            }
                            else
                            {
                                validResponse = true;
                                Console.WriteLine();
                                Console.WriteLine("\tAll is silent. Until you charge them head on, while screaming at the top of your lungs.");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tBAM!");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tYou begin taking them down with unparalleled speed. They are stunned by your brazenness.");
                                Console.WriteLine("\tThey fall one by one, you must be the best shot this side of the Mississippi.");
                                Console.WriteLine("\tThe last one hits the ground...");
                                DisplayContinuePrompt();
                                Console.WriteLine();
                                Console.WriteLine("\tYou call out to your family...");
                                inventory.bullets = bullets - 20;
                            }
                            break;
                        default:
                            validResponse = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                            break;
                    }
                } while (!validResponse);
            }
            else
            {
                Console.WriteLine("\tYou look up at the night sky wondering what might be out there,");
                Console.WriteLine("\tand you hope for no further hiccups in your journey.");
                DisplayContinuePrompt();
                Console.WriteLine();
                Console.WriteLine("\tYour hopes seem to be answered, at least for the time being.");
            }
            return inventory;
        }

        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayTakeShortPath(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            bool validResponse = false;
            string userChoice;

            Console.WriteLine("\tYou decide to take the short path over the mountain.");
            if (inventory.oxen == 1)
            {
                Console.WriteLine("\tYou can see the steam coming out of the nose of your ox.");
                Console.WriteLine("\tIts pace begins to slow.");
                Console.WriteLine("\tIf only your other ox were still alive...");
            }
            else
            {
                Console.WriteLine("\tYou can see the steam coming out of the oxens noses,");
                Console.WriteLine("\tbut their pace does not slow.");
            }

            Console.WriteLine("\tIts a steap treak, but you've almost crested the peak.");

            if (inventory.oxen == 1)
            {
                Console.WriteLine("\tEveryone is feeling good, but your ox begins to stir.");
                Console.WriteLine("\tIt seems anxious about something in the bushes.");
                DisplayContinuePrompt();
            }
            else
            {
                Console.WriteLine("\tEveryone is feeling good, but your oxen begin to stir.");
                Console.WriteLine("\tThey seem anxious about something in the bushes.");
                DisplayContinuePrompt();
            }

            //
            // Mountain Lion Attack
            //

            inventory = DisplayMountainLionAttack(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);


            return inventory;
        }

        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayMountainLionAttack(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            Console.WriteLine();
            Console.WriteLine("\tYou bring the wagon to a stop, peer into the bushes,");
            Console.WriteLine("\tand listen for any sign of danger.");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tThen you see it.");
            Console.WriteLine("\tFor a split second you see the light reflect off of its eyes,");
            Console.WriteLine("\tand before you can react, a mountain lion leaps out of the bushes.");

            if (inventory.oxen == 1 && inventory.bullets >= 3)
            {
                Console.WriteLine("\tIt sinks its teath into your last remaining ox.");
                Console.WriteLine("\tYou pull your rifle out and fire a round into the mountain lion,");
                Console.WriteLine("\tbut it doesn't seem to flinch. You have to be carful not to hit your ox.");
                Console.WriteLine("\tYou fire another round, and you see its grip begin to loosen.");
                Console.WriteLine("\tAfter a third bullet, the mountain lion hits the ground.");
                Console.WriteLine("\tIt's finally dead.");
                inventory.bullets = bullets - 3;
                inventory.food = food;
                inventory.water = water;
                inventory.supplies = supplies;
                inventory.oxen = oxen;
                inventory.money = money;
                inventory.exit = exit;
                inventory.traderKilled = traderKilled;
            }
            else if (inventory.oxen == 1 && inventory.bullets < 3)
            {
                Console.WriteLine("\tIt sinks its teath into your last remaining ox.");
                if (inventory.bullets == 2)
                {
                    Console.WriteLine("\tYou pull your rifle out and fire a round into the mountain lion,");
                    Console.WriteLine("\tbut it doesn't seem to flinch. You have to be carful not to hit your ox.");
                    Console.WriteLine("\tYou fire another round, and you see its grip begin to loosen.");
                    Console.WriteLine("\tYou go to fire a third round, but you're out of bullets!");
                    Console.WriteLine("\tThere is nothing you can do. You can only watch as the mountain lion");
                    Console.WriteLine("\tmakes short work of the ox.");
                    Console.WriteLine("\tLuckily, after it kills the ox, it flees back into the bushes,");
                    Console.WriteLine("\tbut it doesn't matter, your now trapped on top of a mountain.");
                    Console.WriteLine("\tYou have no way down except to walk, but you cant carry enough food with");
                    Console.WriteLine("\tyou to make it down...");
                    Console.WriteLine("\tThis is the end of your journey...");
                    inventory.oxen = oxen - 1;
                    inventory.bullets = bullets - 2;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    DisplayContinuePrompt();
                }
                else if (inventory.bullets == 1)
                {
                    Console.WriteLine("\tYou pull your rifle out and fire a round into the mountain lion,");
                    Console.WriteLine("\tbut it doesn't seem to flinch. You have to be carful not to hit your ox.");
                    Console.WriteLine("\tYou go to fire a second round, but you're out of bullets!");
                    Console.WriteLine("\tThere is nothing you can do. You can only watch as the mountain lion");
                    Console.WriteLine("\tmakes short work of the ox.");
                    Console.WriteLine("\tLuckily, after it kills the ox, it flees back into the bushes,");
                    Console.WriteLine("\tbut it doesn't matter, your now trapped on top of a mountain.");
                    Console.WriteLine("\tYou have no way down except to walk, but you cant carry enough food with");
                    Console.WriteLine("\tyou to make it down...");
                    Console.WriteLine("\tThis is the end of your journey...");
                    inventory.oxen = oxen - 1;
                    inventory.bullets = bullets - 1;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    DisplayContinuePrompt();
                }
                else if (inventory.bullets == 0)
                {
                    Console.WriteLine("\tYou pull your rifle out to fire a round into the mountain lion,");
                    Console.WriteLine("\tbut you're out of bullets!");
                    Console.WriteLine("\tThere is nothing you can do. You can only watch as the mountain lion");
                    Console.WriteLine("\tmakes short work of the ox.");
                    Console.WriteLine("\tLuckily, after it kills the ox, it flees back into the bushes,");
                    Console.WriteLine("\tbut it doesn't matter, your now trapped on top of a mountain.");
                    Console.WriteLine("\tYou have no way down except to walk, but you cant carry enough food with");
                    Console.WriteLine("\tyou to make it down...");
                    Console.WriteLine("\tThis is the end of your journey...");
                    inventory.oxen = oxen - 1;
                    inventory.bullets = bullets;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    DisplayContinuePrompt();
                }
            }
            else if (inventory.oxen == 2 && inventory.bullets >= 3)
            {
                Console.WriteLine("\tIt sinks its teath into one of your oxen.");
                Console.WriteLine("\tYou pull your rifle out and fire a round into the mountain lion,");
                Console.WriteLine("\tbut it doesn't seem to flinch. You have to be carful not to hit your ox.");
                Console.WriteLine("\tYou fire another round, and you see its grip begin to loosen.");
                Console.WriteLine("\tAfter a third bullet, the mountain lion hits the ground.");
                Console.WriteLine("\tIt's finally dead.");
                inventory.bullets = bullets - 3;
                inventory.oxen = oxen;
                inventory.food = food;
                inventory.water = water;
                inventory.supplies = supplies;
                inventory.money = money;
                inventory.exit = exit;
                inventory.traderKilled = traderKilled;
            }
            else if (inventory.oxen == 2 && inventory.bullets < 3)
            {
                if (inventory.bullets == 2)
                {
                    Console.WriteLine("\tYou pull your rifle out and fire a round into the mountain lion,");
                    Console.WriteLine("\tbut it doesn't seem to flinch. You have to be carful not to hit your ox.");
                    Console.WriteLine("\tYou fire another round, and you see its grip begin to loosen.");
                    Console.WriteLine("\tYou go to fire a third round, but you're out of bullets!");
                    Console.WriteLine("\tThere is nothing you can do. You can only watch as the mountain lion");
                    Console.WriteLine("\tmakes short work of the ox.");
                    Console.WriteLine("\tLuckily, after it kills the ox, it flees back into the bushes,");
                    Console.WriteLine("\tAt least you still have one ox.");
                    Console.WriteLine("\tIt should be able to complete the rest of the journey.");
                    inventory.oxen = oxen - 1;
                    inventory.bullets = bullets - 2;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    DisplayContinuePrompt();
                }
                else if (inventory.bullets == 1)
                {
                    Console.WriteLine("\tYou pull your rifle out and fire a round into the mountain lion,");
                    Console.WriteLine("\tbut it doesn't seem to flinch. You have to be carful not to hit your ox.");
                    Console.WriteLine("\tYou go to fire a second round, but you're out of bullets!");
                    Console.WriteLine("\tThere is nothing you can do. You can only watch as the mountain lion");
                    Console.WriteLine("\tmakes short work of the ox.");
                    Console.WriteLine("\tLuckily, after it kills the ox, it flees back into the bushes,");
                    Console.WriteLine("\tAt least you still have one ox.");
                    Console.WriteLine("\tIt should be able to complete the rest of the journey.");
                    inventory.oxen = oxen - 1;
                    inventory.bullets = bullets - 1;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    DisplayContinuePrompt();
                }
                else if (inventory.bullets == 0)
                {
                    Console.WriteLine("\tYou pull your rifle out to fire a round into the mountain lion,");
                    Console.WriteLine("\tbut you're out of bullets!");
                    Console.WriteLine("\tThere is nothing you can do. You can only watch as the mountain lion");
                    Console.WriteLine("\tmakes short work of the ox.");
                    Console.WriteLine("\tLuckily, after it kills the ox, it flees back into the bushes,");
                    Console.WriteLine("\tAt least you still have one ox.");
                    Console.WriteLine("\tIt should be able to complete the rest of the journey.");
                    inventory.oxen = oxen - 1;
                    inventory.bullets = bullets;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    DisplayContinuePrompt();
                }

            }
            return inventory;
        }

        /// <summary>
        /// Attack Native Americans
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="exit"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayAttackNativeAmericans(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            Console.WriteLine();
            Console.WriteLine("\tYou begin firing rounds at the Native Americans,");
            if (inventory.bullets < 10)
            {
                Console.WriteLine("\tbut you are quickly overwhelmed.");
                Console.WriteLine("\tTheir arrows strike you down with almost no effort.");
                Console.WriteLine("\tRight before your eyes, your journey comes to an end.");
                Console.WriteLine();
                DisplayGameOver();
            }
            else
            {
                Console.WriteLine("\tand they panic as they are shot down one by one.");
                Console.WriteLine("\tTheir arrows are no match for your rifle.");
                DisplayContinuePrompt();
                Console.WriteLine();
                Console.WriteLine("\tYou loot through their supplies.");
                DisplayContinuePrompt();
                inventory.food = food + 25;
                inventory.water = water + 20;
            }

            return inventory;

        }

        /// <summary>
        /// Greet Native Americans
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="exit"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayGreetNativeAmericans(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            bool validResponse = false;
            string userChoice;

            Console.WriteLine();
            Console.WriteLine("\tYou approach the Native Americans.");
            Console.WriteLine("\tThey appear stoic, but not hostile.");
            Console.WriteLine("\tYou greet them with a simle, and they greet you back.");
            Console.WriteLine("\tThey ask if you are looking to trade.");

            do
            {
                validResponse = false;
                Console.WriteLine();
                Console.WriteLine("\tWould you like to:");
                Console.WriteLine("\ta) Trade with them");
                Console.WriteLine("\tb) Continue journey");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");

                userChoice = Console.ReadLine().ToLower();
                Console.WriteLine();
                switch (userChoice)
                {
                    case "a":
                        validResponse = true;
                        inventory = DisplayTradeWithNativeAmericans(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                        Console.WriteLine();
                        break;
                    case "b":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou decide to continue your journey.");
                        break;
                    default:
                        validResponse = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                        break;
                }
            } while (!validResponse);


            return inventory;
        }

        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayTradeWithNativeAmericans(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            bool validResponse = false;
            string userChoice;

            Console.WriteLine("\tYou tell them that you are looking to trade, and they show you their goods.");
            Console.WriteLine();
            Console.WriteLine("\tYou can only make one trade with this trader.");
            do
            {
                Console.WriteLine();
                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                Console.WriteLine();
                Console.WriteLine("\tHere are their offers:");
                Console.WriteLine();
                Console.WriteLine("\ta) They will give you 20 food for 10 water.");
                Console.WriteLine("\tb) They will give you 50 food for 30 water.");
                Console.WriteLine("\tc) They will give you 25 water for 35 food.");
                Console.WriteLine("\td) (Decide not to trade and continue journey.)");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "a":
                        if (inventory.water < 10)
                        {
                            Console.WriteLine();
                            Console.WriteLine("\tYou do not have enough water to trade.");
                        }
                        else
                        {
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou give them 10 water.");
                            Console.WriteLine("\tthey give you 20 food.");
                            Console.WriteLine();
                            inventory.bullets = bullets;
                            inventory.food = food + 20;
                            inventory.water = water - 10;
                            inventory.supplies = supplies;
                            inventory.oxen = oxen;
                            inventory.money = money;
                            inventory.exit = exit;
                            inventory.traderKilled = traderKilled;
                        }
                        break;
                    case "b":
                        if (inventory.water < 30)
                        {
                            Console.WriteLine();
                            Console.WriteLine("\tYou do not have enough water to trade.");
                        }
                        else
                        {
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou give them 30 water.");
                            Console.WriteLine("\tThey give you 50 food.");
                            Console.WriteLine();
                            inventory.bullets = bullets;
                            inventory.food = food + 50;
                            inventory.water = water - 30;
                            inventory.supplies = supplies;
                            inventory.oxen = oxen;
                            inventory.money = money;
                            inventory.exit = exit;
                            inventory.traderKilled = traderKilled;
                        }
                        break;
                    case "c":
                        if (inventory.food < 35)
                        {
                            Console.WriteLine();
                            Console.WriteLine("\tYou do not have enough food to trade.");
                        }
                        else
                        {
                            validResponse = true;
                            Console.WriteLine();
                            Console.WriteLine("\tYou give them 35 food.");
                            Console.WriteLine("\tThey give you 25 water.");
                            Console.WriteLine();
                            inventory.bullets = bullets;
                            inventory.food = food - 35;
                            inventory.water = water + 25;
                            inventory.supplies = supplies;
                            inventory.oxen = oxen;
                            inventory.money = money;
                            inventory.exit = exit;
                            inventory.traderKilled = traderKilled;
                        }
                        break;
                    case "d":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou decide not to trade after all.");
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                        break;
                    default:
                        Console.Clear();
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                        break;
                }

            } while (!validResponse);




            return inventory;
        }

        /// <summary>
        /// Wait to cross river
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="exit"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayWaitToCrossRiver(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = false;
            inventory.traderKilled = traderKilled;

            string userChoice;
            bool validResponse = false;

            Console.WriteLine();
            Console.WriteLine("\tYou decide to wait for a better opportunity to cross.");


            for (int counter = 1; counter <= 10; counter++)
            {
                Console.WriteLine();
                Console.WriteLine($"\tYou wait {counter} day(s)");

                if (counter == 5)
                {
                    Console.WriteLine("\tThe water level seems to have gone down enough to ford the river and roll across the bottom");
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tWould you like to:");
                        Console.WriteLine("\ta) Ford the river.");
                        Console.WriteLine("\tb) Continue waiting.");
                        Console.WriteLine();
                        Console.Write("\tEnter Choice:");

                        userChoice = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        switch (userChoice)
                        {
                            case "a":
                                validResponse = true;
                                counter = 11;
                                inventory = DisplayFordRiver(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                DisplayContinuePrompt();
                                break;
                            case "b":
                                validResponse = true;
                                Console.WriteLine("\tYou decide to keep waiting.");
                                DisplayContinuePrompt();
                                break;
                            default:
                                validResponse = false;
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                break;
                        }
                    } while (!validResponse);

                }
                else if (counter == 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tThe ferry has pulled up to your side of the river bank.");
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tWould you like to:");
                        Console.WriteLine("\ta) Take ferry across (costs 15 dollars).");
                        Console.WriteLine("\tb) Ford the river.");
                        Console.WriteLine();
                        Console.Write("\tEnter Choice:");

                        userChoice = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        switch (userChoice)
                        {
                            case "a":
                                if (inventory.money < 15)
                                {
                                    validResponse = false;
                                    Console.WriteLine("\tYou do not have enough money to take the ferry.");
                                }
                                else
                                {
                                    DisplayTakeFerry();
                                    inventory.money = money - 15;
                                    Console.WriteLine("\tYou lost 15 dollars");
                                    Console.WriteLine();
                                    DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                    DisplayContinuePrompt();
                                }
                                break;
                            case "b":
                                validResponse = true;
                                inventory = DisplayFordRiver(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                Console.WriteLine();
                                DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);
                                DisplayContinuePrompt();
                                break;
                            default:
                                validResponse = false;
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                                break;
                        }
                    } while (!validResponse);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tnothing happens.");
                }
                DisplayContinuePrompt();
            }



            return inventory;
        }
        /// <summary>
        /// Ferry wagon across river
        /// </summary>
        private static void DisplayTakeFerry()
        {
            Console.WriteLine();
            Console.WriteLine("\tYou decide to take the ferry across. You pay 15 dollars, and you load your wagon onto the ferry.");
            Console.WriteLine("\tIt takes you across and drops you off on the other side.");
        }
        /// <summary>
        /// Ford wagon across river
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="exit"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayFordRiver(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            string userChoice;
            bool validResponse = false;

            Console.WriteLine("\tYou decide to ford the river.");
            Console.WriteLine("\tYou strap down everything that you can and prepare to cross");
            Console.WriteLine("\tThe oxen begin to pull the wagon across the river, so far, so good.");
            Console.WriteLine("\tYou're about halfway across now, with no problems yet,");
            Console.WriteLine("\tuntil your wheel gets stuck in some mud that has built up on the riverbed.");
            Console.WriteLine("\tThe oxen pull harder and harder, but the wagon won't budge.");
            Console.WriteLine("\tWater starts to build up on the side of the wagon and before long, it begins to");
            Console.WriteLine("\tenter the wagon.");
            Console.WriteLine("\tWith a loud holler you order the oxen to pull even harder.");
            Console.WriteLine("\tIt works! The wagon begins to roll again, and before you know it you've reached the river bank.");
            Console.WriteLine("\tThat water that got in must have damaged some resources.");

            DisplayContinuePrompt();

            Console.WriteLine();
            Console.WriteLine("\tYou take a look at what you lost when crossing the river.");
            Console.WriteLine();
            Console.WriteLine("\tIt looks like you lost 10 food and 5 water from when the wagon got stuck in the mud.");

            inventory.food = food - 10;
            inventory.water = water - 5;

            return inventory;
        }
        /// <summary>
        /// Float wagon across river
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="exit"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayFloatWagon(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            string userChoice;
            bool validResponse = false;

            Console.WriteLine();
            Console.WriteLine("\tYou decide that floating the wagon across is the best course of action.");
            Console.WriteLine("\tYou strap down everything that you can to the wagon");
            Console.WriteLine("\tThe oxen seem apprehensive, but there is no other choice.");
            Console.WriteLine("\tYou tie them to the rear of the wagon so they can swim along as you cross.");

            DisplayContinuePrompt();

            Console.WriteLine();
            Console.WriteLine("\tYou push the wagon into the river and hop on with oxen in tow.");
            Console.WriteLine("\tEverything is going well, until you see ahead of you a shallow sandbar");
            Console.WriteLine("\tYou try to redirect the wagon, but there is nothing you can do.");
            Console.WriteLine("\tThe wagon slams into the sandbar! you hear a loud crack from the wood.");
            Console.WriteLine("\tYou hop out to dislodge the wagon, but water has started build up and");
            Console.WriteLine("\tand flow into the wagon! You give the wagon a hard shove and it finally comes loose");
            Console.WriteLine("\tfrom the sandbar. That was a close one. some of your resources were surely damaged, but");
            Console.WriteLine("\tYou'll have to wait until you're safely across the river to check.");

            if (inventory.food < 20)
            {
                inventory.food = food = 0;
            }
            else
            {
                inventory.food = food - 20;
            }

            if (inventory.water < 15)
            {
                inventory.water = 0;
            }
            else
            {
                inventory.water = water - 15;
            }


            DisplayContinuePrompt();

            Console.WriteLine();
            Console.WriteLine("\tYou're nearly there. Just a little further to go.");
            Console.WriteLine("\tEveryones hopes rise, but the wagon begins to slow.");
            Console.WriteLine("\tYou look to see why, and one of your oxen has slowed down.");
            Console.WriteLine("\tIt's struggling to stay with the wagon, and it's barely keeping its head above water.");
            Console.WriteLine("\tYou have to act fast.");

            do
            {
                Console.WriteLine();
                Console.WriteLine("\tDo you:");
                Console.WriteLine("\ta) Cut the rope in the hope that the ox will swim swim across by itself.");
                Console.WriteLine("\tb) Leave the ox tied to the wagon in the hope that you will help pull it across.");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");

                userChoice = Console.ReadLine().ToLower();
                Console.WriteLine();
                switch (userChoice)
                {
                    case "a":
                        validResponse = true;
                        Console.WriteLine("\tYou decide to cut the rope. The ox falls behind, but its head is above the water,");
                        Console.WriteLine("\tand it seems to be swimming with ease now.");
                        break;
                    case "b":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou decide it will be better to pull the ox along,");
                        Console.WriteLine("\tbut the ox continues to struggle. It's head is barely above the surface now.");
                        Console.WriteLine("\tYou hold out hope that you will make it to the shore in time, but the ox goes completely under.");
                        Console.WriteLine("\tYou wait... and wait... and wait... but the ox does not resurface, so you cut the rope.");
                        Console.WriteLine("\tIt's to late now, the ox is dead.");
                        inventory.oxen = oxen - 1;
                        DisplayContinuePrompt();
                        break;
                    default:
                        validResponse = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                        break;
                }
            } while (!validResponse);

            if (inventory.oxen < 2)
            {
                Console.WriteLine();
                Console.WriteLine("\tYou slide into shore. You and your family mourn the passing of the ox.");
                Console.WriteLine("\tYou hope that just the one will be enough for the rest of the journey.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\tYou slide into shore. You've made it with minimal losses, and your ox is still swimming comfortably.");
                Console.WriteLine("\tIt does not take long for the ox to make it to shore as well, so you still have two healthy oxen.");
            }

            DisplayContinuePrompt();

            return inventory;
        }

        /// <summary>
        /// Method for trading with the fort
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="events"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayTradeWithFort(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            inventory.bullets = bullets;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            string userChoice;
            bool validResponse = true;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tWhat would you like to trade?");
            Console.WriteLine();
            Console.WriteLine("\ta) Trade 25 food for 50 supplies.");
            Console.WriteLine("\tb) Trade 50 food for 30 water.");
            Console.WriteLine("\tc) Trade 25 supplies for 10 water.");
            Console.WriteLine("\td) Trade 30 water for 50 food.");
            Console.WriteLine("\te) Trade 10 bullets for 35 food and 20 water.");
            Console.WriteLine("\tf) Pay 40 dollars for 50 food, 30 water.");
            Console.WriteLine("\tg) Pay 15 dollars for 5 bullets.");
            Console.WriteLine("\th) Pay 20 dollars for 40 water.");
            Console.WriteLine("\ti) (Exit Trade Menu.)");
            Console.WriteLine();
            Console.Write("\tEnter Choice:");
            userChoice = Console.ReadLine().ToLower();

            switch (userChoice)
            {
                case "a":
                    if (inventory.food < 25)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough food to trade.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 25 food.");
                        Console.WriteLine("\tHe hands you 50 supplies.");
                        Console.WriteLine();
                        inventory.bullets = bullets;
                        inventory.food = food - 25;
                        inventory.water = water;
                        inventory.supplies = supplies + 50;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                        Console.WriteLine();
                    }
                    break;
                case "b":
                    if (inventory.food < 50)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough food to trade.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 50 food.");
                        Console.WriteLine("\tThe trader hands you 30 water.");
                        Console.WriteLine();
                        inventory.bullets = bullets;
                        inventory.food = food - 50;
                        inventory.water = water + 30;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "c":
                    if (inventory.supplies < 25)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough supplies to trade.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 25 supplies.");
                        Console.WriteLine("\tThe trader hands you 10 water.");
                        Console.WriteLine();
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water + 10;
                        inventory.supplies = supplies - 25;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "d":
                    if (inventory.water < 30)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough water to trade.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 30 water.");
                        Console.WriteLine("\tThe trader hands you 50 food.");
                        Console.WriteLine();
                        inventory.bullets = bullets;
                        inventory.food = food + 50;
                        inventory.water = water - 30;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "e":
                    if (inventory.bullets < 10)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough bullets to trade.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 10 bullets.");
                        Console.WriteLine("\tThe trader hands you 35 food and 20 water.");
                        Console.WriteLine();
                        inventory.bullets = bullets - 10;
                        inventory.food = food + 35;
                        inventory.water = water + 20;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "f":
                    if (inventory.money < 30)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have money to pay.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou pay the trader 40 dollars.");
                        Console.WriteLine("\tThe trader hands you 50 food and 30 water.");
                        Console.WriteLine();
                        inventory.bullets = bullets;
                        inventory.food = food + 50;
                        inventory.water = water + 30;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money - 30;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "g":
                    if (inventory.money < 5)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough money to pay.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou pay the trader 15 dollars.");
                        Console.WriteLine("\tThe trader hands you 5 bullets.");
                        Console.WriteLine();
                        inventory.bullets = bullets + 5;
                        inventory.food = food;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money - 15;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "h":
                    if (inventory.money < 20)
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou do not have enough money to pay.");
                    }
                    else
                    {
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tYou pay the trader 20 dollars.");
                        Console.WriteLine("\tThe trader hands you 40 water.");
                        Console.WriteLine();
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water + 40;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money - 20;
                        inventory.exit = exit;
                        inventory.traderKilled = traderKilled;
                    }
                    break;
                case "i":
                    validResponse = true;
                    Console.WriteLine();
                    Console.WriteLine("\tYou decide to move on from the fort.");
                    inventory.bullets = bullets;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.oxen = oxen;
                    inventory.money = money;
                    inventory.exit = true;
                    inventory.traderKilled = traderKilled;
                    break;
                default:
                    Console.Clear();
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                    inventory.bullets = bullets;
                    inventory.food = food;
                    inventory.water = water;
                    inventory.supplies = supplies;
                    inventory.oxen = oxen;
                    inventory.money = money;
                    inventory.exit = exit;
                    inventory.traderKilled = traderKilled;
                    break;
            }

            inventory = DisplayInventory(inventory.food, inventory.water, inventory.supplies, inventory.bullets, inventory.oxen, inventory.money, inventory.exit, inventory.traderKilled);

            DisplayContinuePrompt();

            return inventory;
        }
        /// <summary>
        /// Game over
        /// </summary>
        private static void DisplayGameOver()
        {
            Console.WriteLine("\t\tGAME OVER");
            Console.WriteLine();
            Console.WriteLine("\tYou did not make it to Oregon.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// Arrests user at the fort and displays game over
        /// </summary>
        private static void DisplayArrestedAtFort(string char2, string char3)
        {
            Console.WriteLine();
            Console.WriteLine("\tYou roll through the front gates of the fort.");
            Console.WriteLine("\tYou try not to draw attention to yourself, but you notice the guards whispering to each other.");
            Console.WriteLine("\tYou hear someone shout \"Hey stop!\" You look around and see a guard running toward your wagon.");
            Console.WriteLine("\tYou bring the wagon to a halt.");
            Console.WriteLine("\tThe guard tells you that you and your family need to come with him for questioning.");
            Console.WriteLine($"\tBefore you know it {char2} and {char3} are being detained, and you have no choice but to comply.");
            Console.WriteLine("\tThe guards find a suspicious amount of supplies in your wagon.");
            Console.WriteLine($"\tThey tell you that {char2} and {char3} confessed that you killed the trader.");
            Console.WriteLine("\tThat, along with the additional supplies they found in your wagon has lead them to convict you of murder.");
            Console.WriteLine("\tThe guards give you a life sentance, but they let your family go.");
            Console.WriteLine("\tThis is the end of your journey.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// Method for breaking off the wagon wheel
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="events"></param>
        /// <param name="traderKilled"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayWagonWheelBreaks(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            Console.WriteLine();
            Console.WriteLine("\tAs you continue along, that rattling you heard from the wagon gets louder.");
            Console.WriteLine("\tIt starts to worry you more now, and as you consider stoping to check where it's");
            Console.WriteLine("\tcoming from the back right wheel pops off!");
            Console.WriteLine("\tYou get out to see the damage. It's not too bad. It will take some supplies to repair,");
            Console.WriteLine("\tand a little food and water fell out. You put the wheel back on, but the food and water cant be");
            Console.WriteLine("\tsaved.");
            Console.WriteLine();
            Console.WriteLine("\tYou lose 30 supplies, 5 food, and 5 water.");
            Console.WriteLine();

            inventory.food = food - 5;
            inventory.water = water - 5;
            inventory.supplies = supplies - 30;
            inventory.bullets = bullets;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;

            return inventory;
        }

        /// <summary>
        /// Method for trading goods.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayTradeWithTrader(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            string userChoice;
            bool validResponse = true;

            Console.WriteLine();
            Console.WriteLine("\tYou greet the trader.");
            Console.WriteLine("\tHe lays out his goods for you to see.");
            Console.WriteLine();
            Console.WriteLine("\tYou can only make one trade with this trader.");

            do
            {

                Console.WriteLine();
                Console.WriteLine("\tHere are his offers:");
                Console.WriteLine();
                Console.WriteLine("\ta) He will give you 25 food for 50 supplies.");
                Console.WriteLine("\tb) He will give you 50 food for 30 water.");
                Console.WriteLine("\tc) He will give you 25 supplies for 10 water.");
                Console.WriteLine("\td) He will give you 30 water for 50 food.");
                Console.WriteLine("\te) He will give you 10 bullets for 25 food and 20 water.");
                Console.WriteLine("\tf) (Decide not to trade and continue journey.)");
                Console.WriteLine("\tg) (Kill the trader and take all his goods.)");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "a":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 50 supplies.");
                        Console.WriteLine("\tHe hands you 25 food.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose 50 supplies and gain 25 food");
                        inventory.bullets = bullets;
                        inventory.food = food + 25;
                        inventory.water = water;
                        inventory.supplies = supplies - 50;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                    case "b":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 30 water.");
                        Console.WriteLine("\tThe trader hands you 50 food.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose 30 water, and you gain 50 food.");
                        inventory.bullets = bullets;
                        inventory.food = food + 50;
                        inventory.water = water - 30;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                    case "c":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 10 water.");
                        Console.WriteLine("\tThe trader hands you 25 supplies.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose 10 water, and you gain 25 supplies.");
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water - 10;
                        inventory.supplies = supplies + 25;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                    case "d":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 50 food.");
                        Console.WriteLine("\tThe trader hands you 30 water.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose 50 food, and you gain 30 water.");
                        inventory.bullets = bullets;
                        inventory.food = food - 50;
                        inventory.water = water + 30;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                    case "e":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou give the trader 30 food and 20 water.");
                        Console.WriteLine("\tThe trader hands you 10 bullets.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose 25 food and 10 water, and you gain 5 bullets.");
                        inventory.bullets = bullets + 10;
                        inventory.food = food - 30;
                        inventory.water = water - 20;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                    case "f":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou decide not to trade after all.");
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                    case "g":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou decide you want all the traders supplies,");
                        Console.WriteLine("\tso before the trader has time to react you pull out your rifle and");
                        Console.WriteLine("\tfire a round into the trader...");
                        Console.WriteLine("\tHis eyes go dark and he slumps onto the supplies he had gotten out to show you.");
                        Console.WriteLine("\tYou roll his body over and loot through his things.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou gain 50 food, 25 supplies, 25 water, and 5 bullets.");
                        inventory.bullets = bullets + 10;
                        inventory.food = food + 50;
                        inventory.water = water + 25;
                        inventory.supplies = supplies + 25;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = true;
                        Console.WriteLine("\tYour family is shocked...");
                        Console.WriteLine("\tThey had never seen anything so horiffic...");
                        Console.WriteLine("\tThe wagon rolls on.");
                        break;
                    default:
                        Console.Clear();
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                }

            } while (!validResponse);

            return inventory;
        }

        /// <summary>
        /// Method for hunting buffalo
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayHuntBuffalo(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;

            string userChoice;
            bool validResponse = true;

            Console.WriteLine();
            Console.WriteLine("\tYou dismount the wagon and take your hunting rifle out of the back.");
            Console.WriteLine("\tYou steady yourself on the wagon and line up your shot.");
            Console.WriteLine("\tIn your sights is the broad side of a large buffalo.");
            Console.WriteLine("\tYou have a decision to make. Do you aim for the heart, which is a sure shot,");
            Console.WriteLine("\tbut you risk not downing the animal in one shot, or do you aim for the head?");
            Console.WriteLine("\tThis would surely drop the animal where it stands, but you risk missing your shot");
            Console.WriteLine("\tand wasting your bullet.");



            do
            {
                Console.WriteLine();
                Console.WriteLine("\tWould you like to:");
                Console.WriteLine("\ta) Aim for the heart");
                Console.WriteLine("\tb) Aim for the head");
                Console.WriteLine();
                Console.Write("\tEnter Choice:");
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "a":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou shoot at the heart and the bullet connects, but the buffalo starts to run.");
                        Console.WriteLine("\tIt hasn't gotten far, so you take another shot and the buffalo topples to the ground.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose two bullets and gain 25 food.");
                        inventory.bullets = bullets - 2;
                        inventory.food = food + 25;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;

                        break;
                    case "b":
                        validResponse = true;
                        Console.WriteLine();
                        Console.WriteLine("\tYou shoot at the head, but the bullet misses!");
                        Console.WriteLine("\tThe small herd is spooked, and as you fumble to load another bullet into your rifle");
                        Console.WriteLine("\tthe buffalo trample their way out of your rifles range.");
                        Console.WriteLine();
                        Console.WriteLine("\tYou lose one bullet, and you continue without additional food.");
                        inventory.bullets = bullets - 1;
                        inventory.food = 100;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;

                    default:
                        Console.Clear();
                        validResponse = false;
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter \"a\" or \"b\"");
                        inventory.bullets = bullets;
                        inventory.food = food;
                        inventory.water = water;
                        inventory.supplies = supplies;
                        inventory.oxen = oxen;
                        inventory.money = money;
                        inventory.exit = exit;
                        inventory.traderKilled = false;
                        break;
                }

            } while (!validResponse);

            return inventory;
        }
        /// <summary>
        /// Method for dispalying inventory
        /// </summary>
        /// <param name="food"></param>
        /// <param name="water"></param>
        /// <param name="supplies"></param>
        /// <param name="bullets"></param>
        /// <param name="oxen"></param>
        /// <param name="money"></param>
        /// <param name="events"></param>
        private static (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) DisplayInventory(int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled)
        {
            (int food, int water, int supplies, int bullets, int oxen, int money, bool exit, bool traderKilled) inventory;
            inventory.food = food;
            inventory.water = water;
            inventory.supplies = supplies;
            inventory.bullets = bullets;
            inventory.oxen = oxen;
            inventory.money = money;
            inventory.exit = exit;
            inventory.traderKilled = traderKilled;
            Console.Write($"\tFood: {food}\tWater: {water}\tSupplies: {supplies}\tBullets: {bullets}\tOxen: {oxen}\t\tMoney: {money}");
            Console.WriteLine();
            return inventory;
        }
        /// <summary>
        /// Method for displaying character status
        /// </summary>
        /// <param name="plr1"></param>
        /// <param name="plr2"></param>
        /// <param name="plr3"></param>
        /// <param name="char1Alive"></param>
        /// <param name="char2Alive"></param>
        /// <param name="char3Alive"></param>
        /// <param name="char1Diseased"></param>
        /// <param name="char2Diseased"></param>
        /// <param name="char3Diseased"></param>
        /// <param name="char3Poisoned"></param>
        /// <returns></returns>
        private static (string char1, string char2, string char3) DisplayCharacterStatus(string plr1, string plr2, string plr3, bool char1Alive, bool char2Alive, bool char3Alive, bool char1Diseased, bool char2Diseased, bool char3Diseased, bool char1Poisoned, bool char2Poisoned)
        {
            (string char1, string char2, string char3) names;

            names.char1 = plr1;
            names.char2 = plr2;
            names.char3 = plr3;

            if (char1Alive == true && char1Poisoned == false)
            {
                Console.Write($"\t{plr1}: Alive");
            }
            else if (char1Diseased == true)
            {
                Console.Write($"\t{plr1}: Diseased");
            }
            else if (char1Poisoned == true && char1Alive == true)
            {
                Console.Write($"\t{plr1}: Poisoned");
            }
            else
            {
                Console.Write($"\t{plr1}: Dead");
            }

            if (char2Alive == true && char2Poisoned == false)
            {
                Console.Write($"\t{plr2}: Alive");
            }
            else if (char2Diseased == true)
            {
                Console.Write($"\t{plr2}: Diseased");
            }
            else if (char2Poisoned == true && char2Alive == true)
            {
                Console.Write($"\t{plr2}: Poisoned");
            }
            else
            {
                Console.Write($"\t{plr2}: Dead");
            }

            if (char3Alive == true && char3Diseased == false)
            {
                Console.Write($"\t{plr3}: Alive");
            }
            else if (char3Diseased == true && char3Alive == true)
            {
                Console.Write($"\t{plr3}: Diseased");
            }
            else
            {
                Console.Write($"\t{plr3}: Dead");
            }

            return names;
        }
        /// <summary>
        /// Displays Create character screen
        /// </summary>
        /// <returns></returns>
        private static (string char1, string char2, string char3) DisplayCreateCharacterScreen()
        {
            (string char1, string char2, string char3) names;

            Console.CursorVisible = true;

            Console.WriteLine();
            Console.WriteLine("\t\tCharacter Creation");
            Console.WriteLine();
            Console.WriteLine("\tYou're a setteler from Kansas. What is your name?");
            Console.WriteLine();

            Console.Write("\tEnter Name:");
            names.char1 = Console.ReadLine();
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine($"\tYour name is {names.char1}");

            Console.WriteLine();
            Console.WriteLine("\tWhat is your partners name?");

            Console.WriteLine();
            Console.Write("\tEnter Name:");
            names.char2 = Console.ReadLine();
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine($"\tYour partners name is {names.char2}");

            Console.WriteLine();
            Console.WriteLine("\tWhat is your childs name?");

            Console.WriteLine();
            Console.Write("\tEnter Name:");
            names.char3 = Console.ReadLine();
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine($"\tYour childs name is {names.char3}");

            DisplayContinuePrompt();

            return names;
        }
        /// <summary>
        /// Displays the closing screen
        /// </summary>
        private static void DisplayClosingScreen()
        {


            Console.WriteLine();
            Console.WriteLine("\tThanks for checking out \"A Journey West\"");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to exit.");
            Console.ReadKey();

        }
        /// <summary>
        /// Sets the theme
        /// </summary>
        private static void DisplaySetTheme()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
        }
        /// <summary>
        /// Displays the opening screen
        /// </summary>
        private static void DisplayOpeningScreen()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tA Journey West");
            Console.WriteLine();
            Console.WriteLine("\tWelcome to \"A Journey West.\" This is a text based story adventure");
            Console.WriteLine("\tinspired by \"The Oregon Trail\" (Originally released in 1971).");
            Console.WriteLine("\tIn this game you play as a setteler heading west on the oregon trail in search");
            Console.WriteLine("\tof a better life.");

        }
        /// <summary>
        /// Displays the continue prompt
        /// </summary>
        private static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress Any Key To Continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
