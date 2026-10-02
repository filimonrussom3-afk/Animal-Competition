  using System;

namespace HelloWorld
{
    public class Program
    {
		// create a new animal from user input.
		// Input format: atk spd def hlth accu evas size Name
		// Example: 60 50 5 Water 100 0.8 0.2 100 Tiger
        public static Animal MakeAnimal()
		{
            // Requires the user to enter the animal data in the required order.
			
            Console.WriteLine("Enter an Animal's Properties separated by spaces. (atk spd def Type hlth accu evas size Name)\nExample: 60 50 5 Water 100 0.8 0.2 100 Tiger");
            
			// Reads the input and splits it into separate values.
			string[] animal1Input = Console.ReadLine().Split(' ');
            
			// Converts the values to hte correct data types.
			var(attack1,speed1,defense1,health1,accuracy1,evasion1,size1,animalName1)= (int.Parse(animal1Input[0]), int.Parse(animal1Input[1]),int.Parse(animal1Input[2]),int.Parse(animal1Input[4]),double.Parse(animal1Input[5]),double.Parse(animal1Input[6]),int.Parse(animal1Input[7]), animal1Input[8]);
            
            AnimalType animalType1;//constructs animalType1 as a value outside of if statements so it does not pull a variable scope error
           
			if (string.Equals(animal1Input[3], "Fire", StringComparison.OrdinalIgnoreCase)){
	            animalType1=AnimalType.Fire;
             } //takes string input ignoring case and compares “Fire” to the input value given by animal1Input[3]. If the comparison is true, it casts the input into the fire type animaltype. 
	
            else if (string.Equals(animal1Input[3], "Water", StringComparison.OrdinalIgnoreCase)){
	            animalType1=AnimalType.Water;
                }
            else if (string.Equals(animal1Input[3], "Electric", StringComparison.OrdinalIgnoreCase)){
	            animalType1=AnimalType.Electric;
                }
            else if (string.Equals(animal1Input[3], "Ground", StringComparison.OrdinalIgnoreCase)){
	            animalType1=AnimalType.Ground;
                }
            else {
                throw new Exception("Invalid Animal Type"); //throws error message if a non-valid element is entered 
                }

            Animal animal1 = new Animal(
                attack1,
                speed1,
                defense1,
                animalType1,
                health1,
                accuracy1,
                evasion1,
                size1,
                animalName1
            );// take up to here and enter into a function and call this fucntion twice 
            Console.WriteLine($"Name: {animal1.AnimalName} | Health: {animal1.Health} | Element: {animal1.Type} | Size: {animal1.Size}");

            return animal1;
            }
        public static void Main(string[] args)
        {
            
            var p1= MakeAnimal();//doesnt need new command since it is a static method
            var p2= MakeAnimal();
            Environment battlefieldEnv = p1.EnvChoice();
            Console.WriteLine($"Current Environment: {battlefieldEnv}");
            p1.returnBonus(battlefieldEnv);
            p2.returnBonus(battlefieldEnv);
            Console.WriteLine();

            if (p1.Speed > p2.Speed)
            {
                Console.WriteLine($"{p1.AnimalName} is faster");
            }
            else if (p2.Speed > p1.Speed)
            {
                Console.WriteLine($"{p2.AnimalName} is faster");
            }
            else
            {
                Console.WriteLine("They have the same speed");
            }

            while (p1.Health > 0 && p2.Health > 0)
            {
                // Animal 1 attacks first
                if (p1.Speed > p2.Speed)
                {
                    if (p1.CheckAccuracy())
                    {
                        if (p2.CheckEvasion())
                        {
                            Console.WriteLine($"{p2.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{p1.AnimalName} attacks {p2.AnimalName}");
                            p1.AttackTarget(p2);
                            Console.WriteLine($"{p2.AnimalName} Health: " + p2.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{p1.AnimalName} missed!");
                    }

                    // Check if Animal 2 is defeated
                    if (p2.Health <= 0)
                    {
                        Console.WriteLine($"{p2.AnimalName} is defeated!");
                        break;
                    }

                    // Animal 2 attacks back
                    if (p2.CheckAccuracy())
                    {
                        if (p1.CheckEvasion())
                        {
                            Console.WriteLine($"{p1.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{p2.AnimalName} attacks {p1.AnimalName}");
                            p2.AttackTarget(p1);
                            Console.WriteLine($"{p1.AnimalName} Health: " + p1.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{p2.AnimalName} missed!");
                    }
                }

                // Animal 2 attacks first
                else
                {
                    if (p2.CheckAccuracy())
                    {
                        if (p1.CheckEvasion())
                        {
                            Console.WriteLine($"{p1.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{p2.AnimalName} attacks {p1.AnimalName}");
                            p2.AttackTarget(p1);
                            Console.WriteLine($"{p1.AnimalName} Health: " + p1.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{p2.AnimalName} missed!");
                    }

                    // Check if Animal 1 is defeated
                    if (p1.Health <= 0)
                    {
                        Console.WriteLine($"{p1.AnimalName} is defeated!");
                        break;
                    }

                    // Animal 1 attacks back
                    if (p1.CheckAccuracy())
                    {
                        if (p2.CheckEvasion())
                        {
                            Console.WriteLine($"{p2.AnimalName} evaded the attack!");
                        }
                        else
                        {
                            Console.WriteLine($"{p1.AnimalName} attacks {p2.AnimalName}");
                            p1.AttackTarget(p2);
                            Console.WriteLine($"{p2.AnimalName} Health: " + p2.Health);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{p1.AnimalName} missed!");
                    }
                }

               
                }
            }
        }
    }
