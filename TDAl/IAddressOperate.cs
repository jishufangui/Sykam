using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TModel;
namespace TDAl
{
    public interface IAddressOperate
    {

        #region 省
        /// <summary>
        /// 获取所有省
        /// </summary>
        /// <returns></returns>
        DataTable GetAllProvince();

        /// <summary>
        /// 根据ID获取指定省
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TProvince GetProvinceByID(int id);

        /// <summary>
        /// 根据编号获取指定省
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        TProvince GetProvinceByCode(string Code);
    
        /// <summary>
        /// 添加省
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        int AddProvince(TProvince province);

        /// <summary>
        /// 修改省
        /// </summary>
        /// <param name="province">省</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        int UpdateProvince(TProvince province,int id);

        /// <summary>
        /// 删除省
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        int DeleteProvince(int id);

        #endregion

        #region 市

        #region  获取所有市
        /// <summary>
        /// 获取所有的市
        /// </summary>
        /// <returns></returns>
        DataTable GetAllCity();
        #endregion

        #region  获取指定省下所有的市
        /// <summary>
        /// 获取省下所有的市
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        DataTable GetCityByProvince(string  code);
        #endregion

        #region 获取指定的市
        /// <summary>
        /// 根据指定ID获取市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TCity GetCityByID(int id);

        /// <summary>
        ///  根据code获取指定城市
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        TCity GetCityByCode(string Code);
        #endregion

        #region 添加市
        /// <summary>
        /// 添加城市
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        int AddCity(TCity city);
        #endregion

        #region 修改市
        /// <summary>
        /// 修改城市ID
        /// </summary>
        /// <param name="tc"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateCity(TCity tc, int id);
        #endregion

        #region 删除市
        /// <summary>
        /// 删除城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteCity(int id);
        #endregion

        #endregion

        #region 地区
            #region 获取所有Area
            DataTable GetAllArea();
            #endregion
            #region 获取city下所有地区
            DataTable GetAreaByCity(string  CityID);
            #endregion

            #region 通过ID获取指定area
            TArea GetAreaByID(int AreaID);
            #endregion

            #region 通过code获取指定area
            TArea GetAreaByCode(string Code);
            #endregion
           
            #region 添加area
            int AddArea(TArea area);
            #endregion

            #region    修改area
                int UpdateArea(TArea area, int id);
            #endregion
           
            #region  删除area
                    int DeleteArea(int id); 
            #endregion

        #endregion
    }
}
