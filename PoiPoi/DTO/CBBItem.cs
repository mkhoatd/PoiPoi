using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoiPoi.DTO
{
    public class CBBItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CBBItem s = (CBBItem)obj;
                return this.Value == s.Value && this.Text == s.Text;
            }
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
