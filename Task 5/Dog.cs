﻿
namespace Task_5
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }
}
