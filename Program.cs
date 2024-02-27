namespace sem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            IBits ibits = new Bits(55555555);
            Console.WriteLine(ibits.GetBits(0));
            Console.WriteLine(ibits.GetBits(1));
            ibits.SetBits(1, false);
            Console.WriteLine("----");
            Console.WriteLine(ibits.GetBits(0));
            Console.WriteLine(ibits.GetBits(1));
             */
            Bits bits = new Bits(3);
            bits[1] = false;
            
            long num = (long)bits;
            Console.WriteLine(num);
            Bits bits2 = num;
        }
    }
}
