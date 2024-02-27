using System.Collections;

namespace sem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bits bits = new Bits(47);

            for (int i = 0; i < bits.Count; i++)
            {
                Console.Write(bits[i]?1:0);
            }
            Console.WriteLine("");

            bits[38] = true;

            for (int i = 0; i < bits.Count; i++)
            {
                Console.Write(bits[i] ? 1 : 0);
            }

            //Из bits в лонг можно неявно преобразовывать, так как размерность одинаковая, ничего не потеряем, компилятор не ругается так как мы оператор приведения сделали implicit
            long a = bits;
            //А вот в int не стоит разрешать неявное приведение так как bits 64-битный, а int 32-х.
            int b = (int)bits;
            Console.WriteLine("\n"+a);
        }
    }
}
