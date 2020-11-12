using System;
using System.Data;
using System.Collections.Generic;
using Blog.Common;
using Blog.Model;
namespace Blog.BLL
{
	/// <summary>
	/// EnumerationBLL
	/// </summary>
	public partial class EnumerationBLL
	{
		private readonly Blog.DAL.EnumerationDAL dal=new Blog.DAL.EnumerationDAL();
		public EnumerationBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int e_id)
		{
			return dal.Exists(e_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Blog.Model.Enumeration model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Blog.Model.Enumeration model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int e_id)
		{
			
			return dal.Delete(e_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string e_idlist )
		{
			return dal.DeleteList(e_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blog.Model.Enumeration GetModel(int e_id)
		{
			
			return dal.GetModel(e_id);
		}
        		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Blog.Model.Enumeration> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Blog.Model.Enumeration> DataTableToList(DataTable dt)
		{
			List<Blog.Model.Enumeration> modelList = new List<Blog.Model.Enumeration>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Blog.Model.Enumeration model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

