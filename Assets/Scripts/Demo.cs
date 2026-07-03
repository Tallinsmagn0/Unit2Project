/* using System;

public class Animal
{
    protected string name;
    protected string sound;

    public Animal(string name, string sound)
    {
        this.name = name;
        this.sound = sound;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine($"{name} says {sound}.");
    }
}

public class Bird : Animal
{
    private double wingspan;

    public Bird(string name, string sound, double wingspan) : base(name, sound)
    {
        this.wingspan = wingspan;
    }

    public void Fly()
    {
        Console.WriteLine($"{name} flies. Its wingspan is {wingspan}m.");
    }

    public override void MakeSound()
    {
        // uses parent definition of function
        base.MakeSound();

        // do extra stuff before or after
    }
}

public class Mammal : Animal
{
    private string furColor;

    public Mammal(string name, string sound, string furColor) : base(name, sound)
    {
        this.furColor = furColor;
    }

    public void DisplayFurColor()
    {
        Console.WriteLine($"{name}'s fur color is {furColor}.");
    }
} */

/* public static class Score
{
    public static int scoreAmount;

    public static void AddScore(int amount)
    {
        scoreAmount += amount;
    }
} */

/* public class Pokemon
{
    int dexNumber;
    string speciesName;
    string type;
    int attackStat;
    int defenseStat;
    Health health;

    public Pokemon(int dexNumber, string name, string type)
    {
        this.dexNumber = dexNumber;
        this.speciesName = name;
        this.type = type;
    }

    public Pokemon(int dexNumber, string name, string type, int attackStat, int defenseStat) : this(dexNumber, name, type)
    {
        this.attackStat = attackStat;
        this.defenseStat = defenseStat;
        this.health = new Health(defenseStat);
    }

    public void TakeDamage(float damage)
    {
        this.health.DeductHealth(damage);
    }

    public void Attack(Pokemon opponent)
    {
        opponent.TakeDamage(attackStat);
    }
}

public class EvolvingPokemon : Pokemon
{
    int evoLevel;

    public EvolvingPokemon(int dexNumber, string name, string type, int evoLevel) : base(dexNumber, name, type)
    {
        this.evoLevel = evoLevel;
    }

    public EvolvingPokemon(int dexNumber, string name, string type, int attackStat, int defenseStat, int evoLevel) 
    : base(dexNumber, name, type, attackStat, defenseStat)
    {
        this.evoLevel = evoLevel;
    }

} */
