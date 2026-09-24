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

	}
    public enum AnimalType
	{
		Fire,
		Water, 
		Electric,
		Ground,
	}
} 

 

