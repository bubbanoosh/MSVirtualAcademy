using System;

namespace Udemy.Course.NUnit.UnitTestsThree_Moq
{
    public delegate void AlienAbductionEventHandler(int galaxy, bool returnOrNot);

    public interface IAnimal
    {
        event EventHandler FallsSickEvent;
        void Stumble(); // If it Stumbles it falls sick
        event AlienAbductionEventHandler AbductedByAliens;
    }

    public class Doctor
    {
        public int TimesCured;
        public int AbductionsObserved;
        
        public Doctor(IAnimal animal)
        {
            animal.FallsSickEvent += (sender, args) =>
            {
                Console.WriteLine("I will cure you I am the Doctor!");
                TimesCured++;
            };
            animal.AbductedByAliens += (galaxy, returnedOrNot) => ++AbductionsObserved;
        }

        

    }

}