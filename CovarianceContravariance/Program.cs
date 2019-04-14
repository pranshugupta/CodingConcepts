namespace CovarianceContravariance
{
    class Program
    {
        public delegate T DOut<out T>();
        public delegate void DIn<in T>(T arg);
        static void Main(string[] args)
        {
            var parenRef = new GenericClass<Parent>();
            var childRef = new GenericClass<Child>();

            IIn<Child> Ci = parenRef;
            I<Parent> p = parenRef;

            IOut<Parent> Po = childRef;
            I<Child> c = childRef;





            DOut<Parent> DGetP = GetParent;
            DOut<Child> DGetC = GetChild;
            DGetP = DGetC;

            DIn<Parent> DSetP = SetParent;
            DIn<Child> DSetC = SetChild;
            DSetC = DSetP;


        }

        public static Parent GetParent() { return new Parent(); }

        public static Child GetChild() { return new Child(); }


        public static void SetParent(Parent p) { }

        public static void SetChild(Child c) { }
    }
}

interface I<T> { }
interface IIn<in T> { }
interface IOut<out T> { }
interface IInOut<T> : IIn<T>, IOut<T> { }
class GenericClass<T> : I<T>, IInOut<T> { }

class Parent { }
class Child : Parent { }