

using System;

namespace Udemy.Course.NUnit.UnitTestsThree_Moq
{
    public class BarMoq : IEquatable<BarMoq>
    {
        public string Name;

        public bool Equals(BarMoq other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BarMoq) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }

    public interface IBaz
    {
        string Name { get; }
    }

    public interface IFoo
    {
        // Methods
        bool DoSomething(string value);
        string ProcessString(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref BarMoq bar);
        int GetCount();
        bool Add(int amount);

        // Properties
        string Name { get; set; }
        IBaz SomeBaz { get; }
        int SomeOtherProperty { get; set; }
    }
}
