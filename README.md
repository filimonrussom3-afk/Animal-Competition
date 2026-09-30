# Overview:
Animal Competition is a two player turn based strategy game where players are able to customize the properties of animals and watch them battle each other. The goal of animal competition is to find what mixtures of modifiers and conditions lead to a winning animal or losing animal. An animal loses when it's health is less than or equal to zero. 

## Properties:
Animals have nine customizable properties: Damage, Speed, Defense, Type/Element, Accuracy, Evasion, Size and Name. Players can choose from 4 animal types/animal elements, Fire, Water, Ground, and Electric. The combinations of the Element bonuses and player configured properties can completely change the outcome of the competition. 

## Setup: 
Animal Competition is a text based game played through the I/O console. In order to play the game, it is necessary to run the files through a C# compiler. \
Suggested online compiler: \
https://www.onlinegdb.com/ \
Docs: \
https://docs.onlinegdb.com/ 
## Extension
To extend the program, view [Animal.cs](https://github.com/filimonrussom3-afk/Animal-Competition/blob/main/Animal.cs) to edit damage, health, evasion, accuracy and environment bonus algorithms.  


### Damage:

Damage can be any integer from 0 ≤ i ≤ 2,147,483,647. Every turn, the attacker’s damage is multiplied against the defender's defense stat. The calculated damage will then be subtracted from the defender’s total health.

```csharp 
public void AttackTarget(Animal target)
		{
			double damage = Attack * (1- target.Defense/100);
			target.Health = target.Health - (int)damage;
		}
```

### Speed:

Speed can be any integer from 0 ≤ i ≤ 2,147,483,647. The purpose of the speed stat is to decide which animal is faster and is able to damage first. Speed is located in the [Program.cs](https://github.com/filimonrussom3-afk/Animal-Competition/blob/main/Program.cs) file, particularly calculated on these lines:
	
```csharp
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
```
> [!NOTE]
> Speed is the only animal property calculated outside of the [Animal.cs](https://github.com/filimonrussom3-afk/Animal-Competition/blob/main/Animal.cs) class. It should be assumed all other properties are calculated within the `Animal.cs` class.

### Defense:
Defense is calculated in the `AttackTarget` method, particularly this line:
```csharp
		double damage = Attack * (1- target.Defense/100);
```
### Type/Element:

The Animal elements/types can be found and edited in the `AnimalType` enum. The purpose of the animal types are to give certain animals damage advantages over animals with opposing types. The type advantage system is calculated by the `GetTypeMultiplier` method:

```csharp
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
```

### Accuracy:
Accuracy is the probability of an attacking animal landing an attack on a defending animal. It is calculated randomly with a float with a value between 0.0 and 1.0. The attack lands if the random float is less than or equal to the Animal's accuracy property. It is calculated in this line:
```csharp
		public bool CheckAccuracy() => random.NextDouble() <= Accuracy;
```
### Evasion:
Evasion is the probability of a defending animal avoiding an attack from the attacking animal. It is calculated randomly with a float with a value between 0.0 and 1.0. The attack lands if the random float is less than or equal to the Animal's evasion property. It is calculated in this line:
```csharp
		public bool CheckEvasion() => random.NextDouble() <= Evasion;
```
### Cosmetics Properties:
Cosmetic properties provide no real battle advantage and are purely for Animal differentiation. The cosmetic properties can be found in the [Program.cs](https://github.com/filimonrussom3-afk/Animal-Competition/edit/main/README.md) class. 
#### Size:
The animal's size is a cosmetic trait players can give to animals for an added personalization factor. The user can enter an animal's size when prompted in the I/O console when the game is running. The size property is printed by:
```csharp
		 Console.WriteLine($"Name: {animal1.AnimalName} | Health: {animal1.Health} | Element: {animal1.Type} | Size: {animal1.Size}");
```
#### Name:
The animal's Name is a cosmetic trait players can give to animals for an added personalization factor. The user can enter an animal's name when prompted in the I/O console when the game is running. The Name property is printed by:
```csharp
		 Console.WriteLine($"Name: {animal1.AnimalName} | Health: {animal1.Health} | Element: {animal1.Type} | Size: {animal1.Size}");
```
