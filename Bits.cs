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

        public int Count { get { return size; } }

        public void SetBits(int index, bool value)
        {
            this[index]=value;
        }
        public long Value { get; private set; } = 0;

        public Bits(long value)
        {
            this.Value = value;
            //Умножаем на 8 так как sizeof возвращает размер в байтах
            size = sizeof(long)*8;
        }

        

        //Можно в обе стороны приводить не явно так как ничего не теряем
        public static implicit operator long(Bits b) => (long)b.Value;
        public static implicit operator Bits(long b) => new Bits(b);
        
        
        //Реализуйте операторы неявного приведения из long,int,byte в Bits.

        //А вот тут при приведении из Bits в int теряем 32 бита, может получиться совсем другое число, нужно обязательно 
        //явное приведение, чтобы конечный пользователь нашего класса понимал что делает.
        public static explicit operator int(Bits b) => (int)b.Value;
        public static implicit operator Bits(int b) => new Bits(b);

        //Таже история с байт, из long в byte теряем последние 64 - 8 = 56 байт, можно облажаться, нужно обязательно явное приведение.
        public static explicit operator byte(Bits b) => (byte)b.Value;
        public static implicit operator Bits(byte b) => new Bits(b);

        
        public bool this[int index]
        {
            get
            {
                if (index > size || index < 0) throw new IndexOutOfRangeException();
                return ((Value >> index) & 1L) == 1;
            }

            set
            {
                if (index > size || index < 0) throw new IndexOutOfRangeException();
                //Тут обязательно указывать 1L, так как по умолчанию литерал 1 будет 32-х битным и при смещении, если index больше 31 еденичный байт перескочит.
                if (value == true) Value = (long)(Value | (1L << index));
                else
                {
                    var mask = (long)(1L << index);
                    mask = ~mask;
                    Value &= (long)(Value & mask);
                }
            }
        }
    }
}
