using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Combat
{
    class Program
    {
        public static List<Character> octagonCharacters = new List<Character>
        {
            new Character
            {
                Name = ".Net Matador",
                Atack = new Random().Next(1,10),
                Nivel = new Random().Next(1,10),
                Power = new Random().Next(1,10),
                Block = new Random().Next(1,10)
            }
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Combat Hero World! for Galdino");

            octagonCharacters.ForEach(x => Console.WriteLine($"Fighters in octagon first fighter: {x.Name.ToUpper()}"));
            var showMenu = true;
            do
            {
                Console.WriteLine("Selected:");
                Console.WriteLine("1 - Create character");
                Console.WriteLine("2 - Fight");
                Console.WriteLine("3 - Exit");
                var selected = Console.ReadLine();
                var myCharacter = new Character();
                switch (Convert.ToInt32(selected))
                {
                    case 1:
                        Console.WriteLine("Create your new Character \n Name for your character");
                        myCharacter = CreateCharacter(Console.ReadLine());
                        octagonCharacters.Add(myCharacter);
                        Console.WriteLine($"{octagonCharacters[0].Name} VS {octagonCharacters[1].Name}");
                        Console.WriteLine("Let the games begin");
                        break;
                    case 2:
                        Console.WriteLine("Fight");
                        Fight(octagonCharacters[^1], octagonCharacters.First());
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        showMenu = false;
                        break;
                }

            } while (showMenu);


        }



        public static void Fight(Character a, Character b)
        {
            Console.WriteLine("Fighting..");

            if (a.Atack >= b.Power)
            {

                b.Atack = b.Power - a.Atack;
                a.Atack += b.Power;
                a.Nivel += 1;
                Console.WriteLine($"Good {a.Name} won the combat now its power and: {a.Atack}");
            }
            else
                Console.WriteLine($"You have no power to attack your opponent");
        }

        public static Character CreateCharacter(string name)
        {
            var at = new Random();
            return new Character
            {
                Name = name,
                Atack = at.Next(1, 6),
                Nivel = 0,
                Power = at.Next(2, 6),
                Block = 1
            };
        }

        public class Character
        {
            public string Name { get; set; }
            public int Power { get; set; }
            public int Atack { get; set; }
            public int Nivel { get; set; }
            public int Block { get; set; }
        }
    }
}
