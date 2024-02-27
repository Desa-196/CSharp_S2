using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2
{
    /*
     * Спроектируйте интерфейс для класса способного устанавливать и получать
     * значения отдельных бит в  заданном числе.
     * */
    internal interface IBits
    {
        public bool GetBits(int num);

        public void SetBits(int num, bool value);

    }
}
