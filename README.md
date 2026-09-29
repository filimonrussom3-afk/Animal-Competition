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
To extend the program, look in [classes] to edit and [attack defense speed or something] to edit the attack algorithm or property calculation 
## Damage:

Damage can be any integer from 0 ≤ i ≤ 2,147,483,647. Every turn, the attacker’s damage is multiplied against the defender's defense stat. The calculated damage will then be subtracted from the defender’s total health.

```csharp 
public void AttackTarget(Animal target)
		{
			double damage = Attack * (1- target.Defense/100);
			target.Health = target.Health - (int)damage;
		}
```
## Speed:
	Speed can be any integer from 0 ≤ i ≤ 2,147,483,647. The purpose of the speed stat is to decide who is faster to the attack and is able to damage first. 
  
Defense:
	Defense 
Type/Element:

Accuracy

Evasion:

Size

Name
