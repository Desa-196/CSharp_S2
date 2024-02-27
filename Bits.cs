using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sem2
{
    /*
 * 1 реализовать интерфейс из прошлой задачи применив
 * его к классу bits из примера предыдущей лекции.
 * 2 опитмизировать под long
 * */
    internal class Bits : IBits
    {
        private readonly int size = 0;
        public bool GetBits(int index)
        {
            return this[index];
        }

        public void SetBits(int index, bool value)
        {
            this[index]=value;
        }
        public long Value { get; private set; } = 0;

        public Bits(long value)
        {
            this.Value = value;
            size = sizeof(long);
        }

        

        public static explicit operator long(Bits b) => (long)b.Value;
        public static implicit operator Bits(long b) => new Bits(b);
        //Реализуйте операторы неявного приведения из long,int,byt в Bits.
        public static explicit operator int(Bits b) => (int)b.Value;
        public static implicit operator Bits(int b) => new Bits(b);

        public static explicit operator byte(Bits b) => (byte)b.Value;
        public static implicit operator Bits(byte b) => new Bits(b);

        public bool this[int index]
        {
            get
            {
                if (index > size || index < 0) return false;
                return ((Value >> index) & 1) == 1;
            }

            set
            {
                if (index > size || index < 0) return;
                if (value == true)
                    Value = (byte)
                    (Value | (1 << index));
                else
                {
                    var mask = (long)(1 << index);
                    mask = ~mask;
                    Value &= (long)(Value & mask);
                    /*
                    var mask = (long)
                        (1 << index);
                    mask = (long)(0xffffffffffffffff ^ mask);
                    Value &=(long)
                        (Value & mask);
                    */
                }
            }
        }
    }
}
