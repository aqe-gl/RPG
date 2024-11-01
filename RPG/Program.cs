using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

using System.ComponentModel.Design;

namespace RPG
{
 
    
    internal class Program
    {
        static string[] typeNames = { "Unknown character", "Pinpoint Archer", "Brave Knight ", "Clever Wizard", "Sneaky Thief", "Creative Artist",
            "Daring Warrior" };
        static string[] bonusNames = { "Unknown bonus", "More HP", "More damage", "More luck" };
        static int choice;

        static void Main(string[] args)
        {
            WriteTextWithBorder("Welcome to the Console RPG");

            Character player = new Character();
            CustomiseCharacter(player, false);

            Character enemy1 = new Character();
            CustomiseCharacter(enemy1, true);

            Battle(player, enemy1);
           // GameLoop(player);
        }


        static void CustomiseCharacter(Character character, bool isEnemy)
        {
            ChooseName(character, isEnemy);

            ChooseType(character, isEnemy);
            Console.WriteLine($"You have chosen {typeNames[(int)character.type]}");

            ChooseBonus(character);
            Console.WriteLine($"You have chosen {bonusNames[(int)character.bonus]}");           
        }

        static void ChooseName(Character character, bool isEnemy)
        {
            if (isEnemy == true)
            {
                string[] names = { "Skeleton", "Kidnapper", "Goblin", "Burglar", "Soldier" };
                Random r = new Random();
                int index = r.Next(0, names.Length);
                character.name = names[index];
            }
            else
            {
                Console.WriteLine("Enter your name: ");
                character.name = Console.ReadLine();
            }
        }

            private static void WriteTextWithBorder(string text)
        {
            string top = "+";
            string middle = $"| {text} |";
            for (int i = 0; i < text.Length + 2; i++)
            {
                top = top + '-';
            }
            top = top + '+';
            Console.WriteLine($"{top}\n{middle}\n{top}");
        }

        private static void GameLoop(Character player)
        {
            Random r = new Random();

            for (int day = 1; day < 6; day++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("1 - Walk, 2 - Talk, 3 - Rest, 4 - Train, 5 - Read, 6 - Eat,  7 - Duel, 8 - Finish the day ");
                    Console.WriteLine("Choose an action: ");
                    int numOfAction = int.Parse(Console.ReadLine());
                    //Console.WriteLine($"{playerName} made an action: {numOfAction}");
                    // Writing a switch conditional for ACTIONS
                    switch (numOfAction)
                    {
                        case 1:
                            int loop = r.Next(1, 11);
                            for (int reps = r.Next(1, 6); i < loop; i++)
                            {
                                int distance = r.Next(1, 6);
                                Console.WriteLine($"{player.name} the {player.type} walked somewhere {distance} kilometers away");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Choose someone to talk to: 1 - Friend 2 - Mother 3 - Wife 4 - Boss");
                            int talkingTime = r.Next(1, 6);
                            int talkToSomeone = int.Parse(Console.ReadLine());
                            switch (talkToSomeone)
                            {
                                case 1:
                                    Console.WriteLine($"{player.name} the {player.type} talked to his friend {talkingTime} times");
                                    break;
                                case 2:
                                    Console.WriteLine($"{player.name} the {player.type} talked to his mother {talkingTime} times");
                                    break;
                                case 3:
                                    Console.WriteLine($"{player.name} the {player.type} talked to his wife {talkingTime} times");
                                    break;
                                case 4:
                                    Console.WriteLine($"{player.name} the {player.type} talked to his boss {talkingTime} times");
                                    break;
                                default:
                                    Console.WriteLine($"{player.name} has not met this person yet");
                                    break;
                            }
                            break;
                        case 3:
                            int hour = r.Next(1, 6);
                            Console.WriteLine($"{player.name} the {player.type} has gone to rest for {hour} hours");
                            break;
                        case 4:
                            Console.WriteLine("Choose an area to train:");
                            Console.WriteLine("1 - Archery, 2 - SwordFighting, 3 - Wizardry, 4 - Strength, 5 - Battle preparation");
                            int training = int.Parse(Console.ReadLine());
                            int trainingTimes = r.Next(1, 6);
                            switch (training)
                            {
                                case 1:
                                    Console.WriteLine($"{player.name} the {player.type} has trained archery {trainingTimes} times");
                                    break;
                                case 2:
                                    Console.WriteLine($"{player.name} the {player.type} has trained swordfighting {trainingTimes} times");
                                    break;
                                case 3:
                                    Console.WriteLine($"{player.name} the {player.type} has trained wizardry {trainingTimes} times");
                                    break;
                                case 4:
                                    Console.WriteLine($"{player.name} the {player.type} has trained strength {trainingTimes} times");
                                    break;
                                case 5:
                                    Console.WriteLine($"{player.name} the {player.type} has trained battle preparation {trainingTimes} times");
                                    break;
                            }
                            break;
                        case 5:
                            Console.WriteLine("Choose a book to read:");
                            Console.WriteLine("1 - Fairy Tales, 2 - Fact Book, 3 - Knight Stories, 4 - Wizard Tellings, 5 - How to slay dragons");
                            int bookNumber = int.Parse(Console.ReadLine());
                            int readingTime = r.Next(2, 60);
                            switch (bookNumber)
                            {
                                case 1:
                                    Console.WriteLine($"{player.name} read fairy tales for {readingTime} minutes");
                                    break;
                                case 2:
                                    Console.WriteLine($"{player.name} read a fact book for {readingTime} minutes");
                                    break;
                                case 3:
                                    Console.WriteLine($"{player.name} read knight stories for {readingTime} minutes");
                                    break;
                                case 4:
                                    Console.WriteLine($"{player.name} read wizard tellings for {readingTime} minutes");
                                    break;
                                case 5:
                                    Console.WriteLine($"{player.name} read How to slay dragons for {readingTime} minutes");
                                    break;
                                default:
                                    Console.WriteLine($"{player.name} does not own this book");
                                    break;
                            }
                            i = 10;
                            break;
                        case 6:
                            Console.WriteLine("Choose a food to eat: 1 - Chicken 2 - Fruit 3 - Vegetables" +
                                " 4 - Cheese 5 - Oats" +
                                " 6 - Beans 7 - Go to the knight canteen");
                            int foodChoice = int.Parse(Console.ReadLine());
                            if (foodChoice == 1)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked on some chicken {amount} times");
                                }
                            }
                            else if (foodChoice == 2)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked on some fruit {amount} times");
                                }
                            }
                            else if (foodChoice == 3)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked on some vegetables {amount} times");
                                }
                            }
                            else if (foodChoice == 4)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked on some cheese {amount} times");
                                }
                            }
                            else if (foodChoice == 5)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked on some oats {amount} times");
                                }
                            }
                            else if (foodChoice == 6)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked on some beans {amount} times");
                                }
                            }
                            else if (foodChoice == 7)
                            {
                                int cycle = r.Next(1, 11);
                                for (int Noideas = r.Next(1, 6); i < cycle; i++)
                                {
                                    int amount = r.Next(1, 7);
                                    Console.WriteLine($"{player.name} the {player.type} has snacked in the knight canteen {amount} times");
                                }
                            }
                            else
                            {
                                Console.WriteLine("This food is not available");
                            }
                            break;
                        case 7:
                            break;
                        case 8:
                            Console.WriteLine($"{player.name} the {player.type} has went to sleep");
                            i = 10;
                            break;
                        default:
                            Console.WriteLine($"{player.name} has not been educated to do this");
                            break;
                    }

                }
                Console.WriteLine($"{player.name} has finished day {day}");
                Console.WriteLine("To continue press enter, to exit press 0");
                if (Console.ReadLine() == "0")
                {
                    break;
                }
            }
        }

        static void Battle(Character player, Character enemy)
        {
            while (player.hp > 0 && enemy.hp > 0)
            {

                player.Attack(enemy);
                if (enemy.hp > 0)
                {
                    enemy.Attack(player);
                }
                Console.ReadLine();
            }
        }

        static void ChooseType(Character player, bool isEnemy)
        {
            int choice;
            while (player.type == TypeOfCharacter.None)
            {
                if (isEnemy == true)
            {
                    Random r = new Random();
                    choice = r.Next(1, typeNames.Length);
            }
            else
            {
                    Console.WriteLine("Choose a character");
                    WriteTextWithBorder($"1 - {typeNames[1]}, 2 - {typeNames[2]}, 3 - {typeNames[3]}");
                    WriteTextWithBorder($"4 - {typeNames[4]}, 5 - {typeNames[5]}, 6 - {typeNames[6]}");
                    choice = int.Parse(Console.ReadLine());
                }

            
             
                switch (choice)
                {
                    case 1:
                        player.type = TypeOfCharacter.Archer;
                        break;
                    case 2:
                        player.type = TypeOfCharacter.Knight;
                        break;
                    case 3:
                        player.type = TypeOfCharacter.Wizard;
                        break;
                    case 4:
                        player.type = TypeOfCharacter.Thief;
                        break;
                    case 5:
                        player.type = TypeOfCharacter.Artist;
                        break;
                    case 6:
                        player.type = TypeOfCharacter.Warrior;
                        break;
                    default:
                        Console.WriteLine("This character is not available");
                        break;

                }
            }
        }
        static void ChooseBonus(Character player)
        {
            while (player.bonus == TypeOfBonus.None)
            {
                Console.WriteLine("Choose a bonus");
                Console.WriteLine($"1 - {bonusNames[1]}, 2 - {bonusNames[2]}, 3 - {bonusNames[3]}");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        player.bonus = TypeOfBonus.HP;
                        player.hp = player.hp * 2;
                        break;
                    case 2:
                        player.bonus = TypeOfBonus.Damage;
                        player.damage = player.damage * 2;
                        break;
                    case 3:
                        player.bonus = TypeOfBonus.Luck;
                        player.luck = player.luck * 2;
                        break;
                    default:
                        Console.WriteLine("This bonus is not available");
                        break;
                }
            }

        }
    }

}

