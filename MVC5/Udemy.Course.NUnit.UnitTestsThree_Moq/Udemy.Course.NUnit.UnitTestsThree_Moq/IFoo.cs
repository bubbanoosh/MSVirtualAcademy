using System;

namespace Udemy.Course.NUnit.UnitTestsThree_Moq
{
    public interface IFoo
    {
        // Methods
        bool DoSomething(string value);
        string ProcessString(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int amount);

        // Properties
        string FirstName { get; set; }
        IBaz SomeBaz { get; }
        int SomeOtherProperty { get; set; }
        bool ABooleanProperty { get; set; }
    }
    public interface IBaz
    {
        string Name { get; set; }
    }


}