using System;
using System.Data;
using System.Collections.Generic;
using Blog.Common;
using Blog.Model;
namespace Blog.BLL
{
	/// <summary>
	/// BlogCommentPhotoBLL
	/// </summary>
	public partial class BlogCommentPhotoBLL
	{
		private readonly Blog.DAL.BlogCommentPhotoDAL dal=new Blog.DAL.BlogCommentPhotoDAL();
		public BlogCommentPhotoBLL()
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
		public bool Exists(int CmpId)
		{
			return dal.Exists(CmpId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Blog.Model.BlogCommentPhoto model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Blog.Model.BlogCommentPhoto model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CmpId)
		{
			
			return dal.Delete(CmpId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CmpIdlist )
		{
			return dal.DeleteList(CmpIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blog.Model.BlogCommentPhoto GetModel(int CmpId)
		{
			
			return dal.GetModel(CmpId);
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
		public List<Blog.Model.BlogCommentPhoto> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Blog.Model.BlogCommentPhoto> DataTableToList(DataTable dt)
		{
			List<Blog.Model.BlogCommentPhoto> modelList = new List<Blog.Model.BlogCommentPhoto>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Blog.Model.BlogCommentPhoto model;
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

