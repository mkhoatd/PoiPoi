using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoiPoi.DTO
{
    public class SV
    {
        public string MSSV { get; set; }
        public string Name { get; set; }
        public int ID_Lop { get; set; }
        public double DTB { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        public bool Anh { get; set; }
        public bool HocBa { get; set; }
        public bool CMND { get; set; }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                SV s = (SV) obj;
                return this.MSSV == s.MSSV;
            }
        }

        public override int GetHashCode()
        {
            return this.MSSV.GetHashCode();
        }
    }
}
