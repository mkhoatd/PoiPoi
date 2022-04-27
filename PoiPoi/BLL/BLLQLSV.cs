using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoiPoi.DAL;
using PoiPoi.DTO;

namespace PoiPoi.BLL
{
    public class BLLQLSV
    {
        private static BLLQLSV _Instance;

        private BLLQLSV()
        {
        }

        public static BLLQLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLQLSV();
                }

                return _Instance;
            }
            private set { }
        }

        public List<CBBItem> GetAllCBB()
        {
            List<CBBItem> data = new List<CBBItem>();
            foreach (var i in DALQLSV.Instance.GetAllLopSH())
            {
                data.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }

            return data;
        }

        public List<SV> GetSVByLopSH(int id)
        {
            if (id == 0)
            {
                return DALQLSV.Instance.GetAllSV();
            }
            else return DALQLSV.Instance.GetAllSV().Where(s => s.ID_Lop == id).ToList();
        }

        public List<SV> GetSVByLopSHAndName(int id, string name)
        {
            return DALQLSV.Instance.GetAllSV().Where(s => s.ID_Lop == id).Where(s => s.Name.Contains(name)).ToList();
        }

        public bool Check(SV s)
        {
            return (DALQLSV.Instance.GetAllSV().Any(sv => sv.MSSV == s.MSSV));
        }

        public bool Check(string mssv)
        {
            return DALQLSV.Instance.GetAllSV().Any(s => s.MSSV == s.MSSV);
        }
        public void Update(SV s)
        {

        }
    }
}
