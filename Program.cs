  using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Animal animal1 = new Animal(
                80,
                70,
                60,
                AnimalType.Fire,
                100,
                0.80,
                0.20,
                5,
                "Harry"
            );

            Console.WriteLine($"Name: {animal1.AnimalName} Health: {animal1.Health} Element: {animal1.Type} Size: {animal1.Size}");

            Animal animal2 = new Animal(
                75,
                70,
                50,
                AnimalType.Water,
                100,
                0.90,
                0.20,
                6,
                "Filimon"
            );

            Console.WriteLine($"Name: {animal2.AnimalName} Health: {animal2.Health} Element: {animal2.Type} Size: {animal2.Size}");

            if (animal1.Speed > animal2.Speed)
            {
                Console.WriteLine($"{animal1.AnimalName} is faster");
            }
            else if (animal2.Speed > animal1.Speed)
            {
                Console.WriteLine($"{animal2.AnimalName} is faster");
            }
            else
            {
                Console.WriteLine("They have the same speed");
            }

            while (animal1.Health > 0 && animal2.Health > 0)
            {
                // Animal 1 attacks first
                if (animal1.Speed > animal2.Speed)
                {
                    if (animal1.CheckAccuracy())
                    {
                        if (animal2.CheckEvasion())
                        {
                            Console.WriteLine($"{animal2.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{animal1.AnimalName} attacks {animal2.AnimalName}");
                            animal1.AttackTarget(animal2);
                            Console.WriteLine($"{animal2.AnimalName} Health: " + animal2.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{animal1.AnimalName} missed!");
                    }

                    // Check if Animal 2 is defeated
                    if (animal2.Health <= 0)
                    {
                        Console.WriteLine($"{animal2.AnimalName} is defeated!");
                        break;
                    }

                    // Animal 2 attacks back
                    if (animal2.CheckAccuracy())
                    {
                        if (animal1.CheckEvasion())
                        {
                            Console.WriteLine($"{animal1.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{animal2.AnimalName} attacks {animal1.AnimalName}");
                            animal2.AttackTarget(animal1);
                            Console.WriteLine($"{animal1.AnimalName} Health: " + animal1.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{animal2.AnimalName} missed!");
                    }
                }

                // Animal 2 attacks first
                else
                {
                    if (animal2.CheckAccuracy())
                    {
                        if (animal1.CheckEvasion())
                        {
                            Console.WriteLine($"{animal1.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{animal2.AnimalName} attacks {animal1.AnimalName}");
                            animal2.AttackTarget(animal1);
                            Console.WriteLine($"{animal1.AnimalName} Health: " + animal1.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{animal2.AnimalName} missed!");
                    }

                    // Check if Animal 1 is defeated
                    if (animal1.Health <= 0)
                    {
                        Console.WriteLine($"{animal1.AnimalName} is defeated!");
                        break;
                    }

                    // Animal 1 attacks back
                    if (animal1.CheckAccuracy())
                    {
                        if (animal2.CheckEvasion())
                        {
                            Console.WriteLine($"{animal2.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{animal1.AnimalName} attacks {animal2.AnimalName}");
                            animal1.AttackTarget(animal2);
                            Console.WriteLine($"{animal2.AnimalName} Health: " + animal2.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{animal1.AnimalName} missed!");
                    }
                }

               
                }
            }
        }
    }
