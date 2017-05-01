using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface ICustomerStorage<T>
    {
        void Write(List<T> date);
        List<T> Read();
    }
}
