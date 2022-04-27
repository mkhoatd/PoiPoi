using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoiPoi.DTO;

namespace PoiPoi.DAL    
{
    public class DALQLSV
    {
        private static DALQLSV _Instance;
        private DALQLSV(){}
        public static DALQLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DALQLSV();
                }

                return _Instance;
            }
            private set{}
        }

        public SV GetSVByDataRow(DataRow i)
        {
            return new SV
            {
                MSSV = i["MSSV"].ToString(),
                Name = i["NameSV"].ToString(),
                ID_Lop = Convert.ToInt32(i["LopId"].ToString()),
                Gender = Convert.ToBoolean(i["Gender"].ToString()),
                NS = Convert.ToDateTime(i["NS"].ToString()),
                DTB = Convert.ToDouble(i["DTB"].ToString()),
                Anh = Convert.ToBoolean(i["Anh"].ToString()),
                HocBa = Convert.ToBoolean(i["HB"].ToString()),
                CMND = Convert.ToBoolean(i["CCCD"].ToString())
            };
        }

        public LopSH GetLopSHByDataRow(DataRow i)
        {
            return new LopSH
            {
                ID_Lop = Convert.ToInt32(i["Id"].ToString()),
                NameLop = i["NameLop"].ToString()
            };
        }

        public List<SV> GetAllSV()
        {
            List<SV> data = new List<SV>();
            string query = "select * from SV";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetSVByDataRow(i));
            }

            return data;
        }
        public List<LopSH> GetAllLopSH()
        {
            List<LopSH> data = new List<LopSH>();
            string query = "select * from LopSH";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetLopSHByDataRow(i));
            }

            return data;
        }

        public void AddSVDAL(SV s)
        {
            string query = $"update SV set NameSV='{s.Name}', LopId={s.ID_Lop}, Gender={(s.Gender?1:0)}, " +
                           $"NS='{s.NS.ToString("yyyy/MM/dd")}', DTB={s.DTB}, Anh={(s.Anh?1:0)}, HB={(s.HocBa?1:0)} " +
                           $", CCCD={(s.CMND?1:0)} where MSSV={s.MSSV}";
            DBHelper.Instance.ExcuteDb(query);
        }

        public void UpdateSVDAL(SV s)
        {
            string query = $"insert into SV values ({s.MSSV}, '{s.Name}', {s.ID_Lop}, {(s.Gender?1:0)}, " +
                           $"'{s.NS.ToString("yyyy/MM/dd")}', {s.DTB}, {(s.Anh?1:0)}, {(s.HocBa?1:0)}, {(s.CMND?1:0)})";
            DBHelper.Instance.ExcuteDb(query);
        }
        public void DelSVDAL(SV s)
        {
            string query = "delete from SV where MSSV=" + s.MSSV;
            DBHelper.Instance.ExcuteDb(query);
        }

        public void DelSVDAL(string MSSV)
        {
            string query = "delete from SV where MSSV=" + MSSV;
            DBHelper.Instance.ExcuteDb(query);
        }

    }

}
