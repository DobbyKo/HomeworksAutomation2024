
namespace Task1_ZooAnimals
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name) 
        {
            Name = name;
        }

        public abstract void MakeSound();

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }
}
