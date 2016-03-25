using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationBug
{
    [Serializable]
    public class CustomObject
    {
        public int Value { get; set; }
    }
}
