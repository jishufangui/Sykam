using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Data.Common;
using DataHelper;
using CommonLibrary;
using TModel;
namespace TDAl.sqlserver
{
    public  class AddressOperate:IAddressOperate
    {
        private static string _connection = string.Empty;
        DataHelper.DbHelper dh;
        public AddressOperate()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
            dh = new SqlHelper(_connection);
        }

        #region  省
        /// <summary>
        /// 获取所有省
        /// </summary>
        /// <returns></returns>
        public  DataTable GetAllProvince()
        {

            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, "Select ID,code,name from province order by ID asc", null);
            dh.Close();
            return dt;
        }
        /// <summary>
        /// 通过指定ID获取省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TProvince GetProvinceByID(int id)
        {
            TProvince tp = new TProvince();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ID",id.ToString());
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select ID,code,name from province where ID=@ID", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    int provinceid = 0;
                    Int32.TryParse(dr[0].ToString().Trim(), out  provinceid);
                    tp.ID = provinceid;
                    tp.code = dr[1].ToString().Trim();
                    tp.name = dr[2].ToString();

                }
            }
            dh.Close();
            return tp;
        }

        public TProvince GetProvinceByCode(string Code)
        {
            TProvince tp = new TProvince();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code", Code);
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select ID,code,name from province where code=@code", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    int provinceid = 0;
                    Int32.TryParse(dr[0].ToString().Trim(), out  provinceid);
                    tp.ID = provinceid;
                    tp.code = dr[1].ToString().Trim();
                    tp.name = dr[2].ToString();

                }
            }
            dh.Close();
            return tp;
        }

        /// <summary>
        /// 添加省份
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public int AddProvince(TProvince province)
        {
            int stat = 0;
            #region 变量
            string code = province.code;
            string name = province.name;
            #endregion
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code",code);
            nvc.Add("@name",name);
            dh.Open();
            dh.ExecuteNonQuery(CommandType.Text, "Insert into province(code,name)values(@code,@name)", nvc);
            dh.Close();
            return stat;
        }

        /// <summary>
        /// 更新 省
        /// </summary>
        /// <param name="province"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateProvince(TProvince province, int id)
        {
            int stat = 0;
            #region  变量
            string code = province.code;
            string name = province.name;
            #endregion
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code", code);
            nvc.Add("@name", name);
            nvc.Add("@id",id.ToString());
            dh.Open();
            dh.ExecuteNonQuery(CommandType.Text, "Update province set code=@code,name=@name where id=@id", nvc);
            dh.Close();
            return stat;
        }

        /// <summary>
        /// 删除省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteProvince(int id)
        {
            int stat = 0;
            string provincecode = GetProvinceByID(id).code;
            DataTable dt = GetCityByProvince(provincecode);
            if (dt.Rows.Count > 0)
            {
                CommonLibrary.RunJs.AlertAndBack("请先删除该省下面的城市");
            }
            else
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("@ID",id.ToString());
                dh.Open();
                stat = dh.ExecuteNonQuery(CommandType.Text, "Delete from city where ID=@ID", nvc);
                dh.Close();
            }

            return stat;
        }

        #endregion

        #region 市
        /// <summary>
        /// 获取所有市
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCity()
        {
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, "Select ID,code,name from city order by ID asc", null);
            dh.Close();
            return dt;
        }

        public DataTable GetCityByProvince(string code)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@provinceId",code);
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, "Select ID,code,name,provinceId from city where provinceId=@provinceId", nvc);
            dh.Close();
            return dt;
        }

        #region 获取指定的市
        /// <summary>
        /// 根据指定ID获取市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public TCity GetCityByID(int id)
        {
            NameValueCollection nvc=new NameValueCollection();
            nvc.Add("@ID",id.ToString());
            TCity tc = new TCity();
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select  ID,code,name,provinceId  from city where ID=@ID", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    tc.ID = id;
                    tc.code = dr[1].ToString();
                    tc.name = dr[2].ToString();
                    tc.provinceId = dr[3].ToString();
                }
            }
            dh.Close();
            return tc;
        }

        public TCity GetCityByCode(string Code)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code", Code);
            TCity tc = new TCity();
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select  ID,code,name,provinceId  from city where code=@code", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    tc.ID = Convert.ToInt32(dr[0].ToString());
                    tc.code = dr[1].ToString();
                    tc.name = dr[2].ToString();
                    tc.provinceId = dr[3].ToString();
                }
            }
            dh.Close();
            return tc;
        }
        public int AddCity(TCity city)
        {
            int stat = 0;
            string code = city.code;
            string name = city.name;
            string provinceId = city.provinceId;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code",code);
            nvc.Add("@name",name);
            nvc.Add("@provinceId",provinceId);
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Insert into city (code,name,provinceId) values(@code,@name,@provinceId)", nvc);
            dh.Close();
            return stat;
            
        }

        public int UpdateCity(TCity tc, int id)
        {
            int stat = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code",tc.code);
            nvc.Add("@name", tc.name);
            nvc.Add("@provinceId",tc.provinceId);
            nvc.Add("@ID",tc.ID.ToString());
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Update city set code=@code,name=@name,provinceId=@provinceId where ID=@ID", nvc);
            dh.Close();

            return stat;
        }
        #endregion


        public int DeleteCity(int id)
        {
            int stat = 0;
            string citycode = GetCityByID(id).code;
            DataTable dt = GetAreaByCity(citycode);
            if (dt.Rows.Count > 0)
            {
                CommonLibrary.RunJs.AlertAndBack("请先删除该城市下的地区");
            }
            else
            {   NameValueCollection nvc=new NameValueCollection();
                nvc.Add("@ID",id.ToString());
                dh.Open();
                stat=dh.ExecuteNonQuery(CommandType.Text,"delete from area where ID=@ID",nvc);
                dh.Close();
            }
            return stat;
        }

        #endregion

        #region  地区

        public DataTable GetAllArea()
        {
           
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, "Select ID,code,name,cityId from area", null);
            dh.Close();
            return dt;
        }

        public DataTable GetAreaByCity(string  CityID)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@cityId",CityID);
            dh.Open();
            DataTable dt = dh.GetDataTable(CommandType.Text, "Select ID,code,name,cityId from area where cityId=@cityId", nvc);
            dh.Close();
            return dt; 
        }

        public TArea GetAreaByID(int AreaID)
        {
            TArea ta = new TArea();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ID", AreaID.ToString());
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select ID,code,name,cityId from area where ID=@ID", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    ta.id = AreaID;
                    ta.code = dr[1].ToString().Trim();
                    ta.name = dr[2].ToString().Trim();
                    ta.cityId = dr[3].ToString().Trim();
                }
            }
            dh.Close();
            return ta;
        }

        public TArea GetAreaByCode(string Code)
        {
            TArea ta = new TArea();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code", Code);
            dh.Open();
            using (DbDataReader dr = dh.ExecuteReader(CommandType.Text, "Select ID,code,name,cityId from area where code=@code", nvc))
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    ta.id = Convert.ToInt32(dr[0].ToString());
                    ta.code = dr[1].ToString().Trim();
                    ta.name = dr[2].ToString().Trim();
                    ta.cityId = dr[3].ToString().Trim();
                }
            }
            dh.Close();
            return ta;
        }

        public int AddArea(TArea area)
        {
            int stat = 0;
            string code = area.code;
            string name = area.name;
            string cityId = area.cityId;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code",code);
            nvc.Add("@name",name);
            nvc.Add("@cityId",cityId);
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Insert into area (code,name,cityId) value(@code,@name,@cityId)", nvc); 
            dh.Close();
            return stat;
        }


        public int UpdateArea(TArea area, int id)
        {
            int stat = 0;
            string code = area.code;
            string name = area.name;
            string cityId = area.cityId;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@code",code);
            nvc.Add("@name",name);
            nvc.Add("@cityId",cityId);
            nvc.Add("@ID",id.ToString());
            dh.Open();
            stat= dh.ExecuteNonQuery(CommandType.Text, "Update area set code=@code,name=@name,cityId=@cityId where ID=@ID", nvc);
            dh.Close();
            return stat;
        }

        public int DeleteArea(int id)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@ID",id.ToString());
            int stat = 0;
            dh.Open();
            stat = dh.ExecuteNonQuery(CommandType.Text, "Delete from area where ID=@ID", nvc);
            dh.Close();
            return stat;
        }
        #endregion

    }
}
