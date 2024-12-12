namespace Task1_ZooAnimals
{
    public class Program
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>()
            {
                new Dog ("Buddy - the beagle"),
                new Cat ("Murr"),
                new Dog ("Hotdog - the dachshund"),
                new Cat ("Whiskas")
            };

            foreach (Animal animal in animals)
            {
                animal.MakeSound();
                animal.Eat();
            }
        }
    }
}