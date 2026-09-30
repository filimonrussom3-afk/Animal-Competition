using System;
using System.Collections.Generic;

namespace HelloWorld
{
	public class Animal : IAttacker, IDefender, IAccuracy, IEvader
	{

		public int Attack {get; set;}
		public int Speed {get; set;}
		public int Defense {get; set;}
		public AnimalType Type {get; set;}
		public int Health {get; set;}
		public double Accuracy {get; set;}
		public double Evasion {get; set;}
		public int Size {get; set;}
		public string AnimalName {get; set;}
		public readonly Random random = new Random();
		public int envchance;
         
		public Animal (int attack, int speed, int defense, AnimalType type, int health, double accuracy,double evasion, int size, string name)

		{
		Attack = attack;
		Speed = speed;
		Defense = defense;
	    Type =   type;
		Health = health;
		Accuracy = accuracy;
		Evasion = evasion;
		Size = size;
		AnimalName=name;
	}
	    public void AttackTarget(Animal target)
		{
			double damage = Attack * (1- target.Defense/100);
			target.Health = target.Health - (int)damage;
		}

		public void Defend()
		{
			Console.WriteLine("Animal is defending!");
		}

		public bool CheckAccuracy()
		{
			Random random = new Random();
			double chance = random.NextDouble();

			return chance <= Accuracy;
		}

		public bool CheckEvasion()
		{
			Random random = new Random();
			double chance = random.NextDouble();

			return chance <= Evasion;
		}
        
        public Environment EnvChoice (){//references enum as datatype for method
			int envchance = random.Next(0,4);//random integer 0<=i<4 (integer from 0-3)
		    
		    Environment[] environmentsArr={Environment.Volcano, Environment.Ocean, Environment.PowerPlant, Environment.Plains};
			return environmentsArr[envchance];
		} 
		public void returnBonus(Environment currentEnvironment){
		    bool hasBonus = (currentEnvironment == Environment.Ocean && Type == AnimalType.Water) ||
                            (currentEnvironment == Environment.Volcano && Type == AnimalType.Fire) ||
                            (currentEnvironment == Environment.Plains && Type == AnimalType.Ground)||
                            (currentEnvironment == Environment.PowerPlant && Type == AnimalType.Electric);
		
		    if (hasBonus){
		    Health=(int)(Health*1.1);
		    Accuracy=Accuracy + 0.05;
		    Speed=(int)(Speed*1.1);
		    Console.WriteLine($"{AnimalName} receives a boost!");
		    }
		    
		}
		
	}
    public enum AnimalType
	{
		Fire,
		Water, 
		Electric,
		Ground,
	}
	public enum Environment
	{
		Volcano,
		Ocean, 
		PowerPlant,
		Plains
	}
} 

 

