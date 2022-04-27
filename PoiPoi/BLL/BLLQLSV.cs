using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.CodedUISupport;
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

        public List<CBBItem> GetAllLopSHAsCBBItem()
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

        public List<SV> GetAllSV()
        {
            return DALQLSV.Instance.GetAllSV();
        }

        public List<LopSH> GetAllLopSH()
        {
            return DALQLSV.Instance.GetAllLopSH();
        }
        public List<SV> GetSVByLopSH(int id)
        {
            if (id == 0)
            {
                //id==0 lay tat ca
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
            return DALQLSV.Instance.GetAllSV().Any(s => s.MSSV == mssv);
        }
        public void AddOrUpdate(SV s)
        {
            if (Check(s))
            {
                DALQLSV.Instance.AddSVDAL(s);
            }
            else
            {
                DALQLSV.Instance.UpdateSVDAL(s);
            }
        }

        public void Del(string mssv)
        {
            DALQLSV.Instance.DelSVDAL(mssv);
        }

        public void Del(SV s)
        {
            DALQLSV.Instance.DelSVDAL(s);
        }
    }
}
