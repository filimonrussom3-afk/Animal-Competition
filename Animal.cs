using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class Animal : IAttacker, IDefender, IAccuracy, IEvader
    {
        private static readonly Random random = new Random();

        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Defense { get; set; }
        public AnimalType Type { get; set; }
        public int Health { get; set; }
        public double Accuracy { get; set; }
        public double Evasion { get; set; }
        public int Size { get; set; }
        public string AnimalName { get; set; }

        public Animal(int attack, int speed, int defense, AnimalType type, int health, double accuracy, double evasion, int size, string name)
        {
            Attack = attack;
            Speed = speed;
            Defense = defense;
            Type = type;
            Health = health;
            Accuracy = accuracy;
            Evasion = evasion;
            Size = size;
            AnimalName = name;
        }

        //TYPE ADVANTAGE SYSTEM ---
        public double GetTypeMultiplier(AnimalType defenderType)
        {
            return (this.Type, defenderType) switch
            {
                // Fire attacker
                (AnimalType.Fire, AnimalType.Ground) => 2.0,
                (AnimalType.Fire, AnimalType.Water) => 0.5,

                // Water attacker
                (AnimalType.Water, AnimalType.Fire) => 2.0,
                (AnimalType.Water, AnimalType.Electric) => 0.5,

                // Electric attacker
                (AnimalType.Electric, AnimalType.Water) => 2.0,
                (AnimalType.Electric, AnimalType.Ground) => 0.5,

                // Ground attacker
                (AnimalType.Ground, AnimalType.Electric) => 2.0,
                (AnimalType.Ground, AnimalType.Fire) => 0.5,

                // Default neutral multiplier
                _ => 1.0
            };
        }

        // ATTACK METHOD WITH TYPE MULTIPLIER ---
        public void AttackTarget(Animal target)
        {
            double typeMultiplier = GetTypeMultiplier(target.Type);
            
            if (typeMultiplier > 1.0)
            {
                Console.WriteLine("It's super effective!");
            }
            else if (typeMultiplier < 1.0)
            {
                Console.WriteLine("It's not very effective...");
            }

            double defenseMultiplier = Math.Max(0, 1.0 - (target.Defense / 100.0));
            int damage = (int)(Attack * defenseMultiplier * typeMultiplier);
            
            target.Health -= damage;
        }

        public void Defend()
        {
            Console.WriteLine($"{AnimalName} is defending!");
        }

        public bool CheckAccuracy() => random.NextDouble() <= Accuracy;

        public bool CheckEvasion() => random.NextDouble() <= Evasion;

        public Environment EnvChoice()
        {
            Environment[] environments = (Environment[])Enum.GetValues(typeof(Environment));
            return environments[random.Next(environments.Length)];
        }

        public void returnBonus(Environment currentEnvironment)
        {
            bool hasBonus = (currentEnvironment, Type) switch
            {
                (Environment.Ocean, AnimalType.Water) => true,
                (Environment.Volcano, AnimalType.Fire) => true,
                (Environment.Plains, AnimalType.Ground) => true,
                (Environment.PowerPlant, AnimalType.Electric) => true,
                _ => false
            };

            if (hasBonus)
            {
                Health = (int)(Health * 1.1);
                Accuracy = Math.Min(1.0, Accuracy + 0.05);
                Speed = (int)(Speed * 1.1);
                Console.WriteLine($"{AnimalName} receives an environmental boost!");
            }
        }
    }

    public enum AnimalType
    {
        Fire,
        Water,
        Electric,
        Ground
    }

    public enum Environment
    {
        Volcano,
        Ocean,
        PowerPlant,
        Plains
    }
}

