using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using TDAl;
using TModel;
namespace TBLL
{
    public class AddressBLL
    {
        IAddressOperate iap = null;
        public AddressBLL()
        {
            TDAl.DatabaseProvider DataProvider = new TDAl.DatabaseProvider();
            iap = DataProvider.GetAddressOperate();
        }

        /// <summary>
        /// 获取所有的省份
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllProvince()
        {
            return iap.GetAllProvince();
        }

        /// <summary>
        /// 根据ID获得指定省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TProvince GetProvinceByID(int id)
        {
            return iap.GetProvinceByID(id);
        }


        /// <summary>
        /// 根据code获得省份
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public TProvince GetProvinceByCode(string Code)
        {
            return iap.GetProvinceByCode(Code);
        }


        /// <summary>
        /// 根据省的编码获取下面的市
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetCityByProvince(string code)
        {
            return iap.GetCityByProvince(code);
        }

        /// <summary>
        /// 根据城市ID获取城市
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public TCity GetCityByID(int cityid)
        {
            return iap.GetCityByID(cityid);
        }

        /// <summary>
        /// 根据code获取城市
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public TCity GetCityByCode(string Code)
        {
            return iap.GetCityByCode(Code);
        }
        /// <summary>
        /// 根据城市code获取地区
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetAreaByCity(string code)
        {
            return iap.GetAreaByCity(code);
        }

        /// <summary>
        /// 根据ID获取地区
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public TArea GetAreaById(int areaId)
        {
            return iap.GetAreaByID(areaId);
        }


        public TArea GetAreaByCode(string Code)
        {
            return iap.GetAreaByCode(Code);
        }



    }
}
