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