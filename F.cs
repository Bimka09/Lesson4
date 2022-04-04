using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class F
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }

        public F(int i1, int i2, int i3, int i4, int i5)
        {
            this.i1 = i1;
            this.i2 = i2;
            this.i3 = i3;
            this.i4 = i4;
            this.i5 = i5;
        }
        public F()
        {

        }

        public string Get()
        {
            return $"i1 = {i1}; i2 = {i2}; i3 = {i3}; i4 = {i4}; i5 = {i5};";
        }
    }
}
