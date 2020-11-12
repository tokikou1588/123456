using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Blog.DBUtility;//Please add references
namespace Blog.DAL
{
	/// <summary>
	/// 数据访问类:BlogCommentPhotoDAL
	/// </summary>
	public partial class BlogCommentPhotoDAL
	{
		public BlogCommentPhotoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CmpId", "BlogCommentPhoto"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CmpId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BlogCommentPhoto");
			strSql.Append(" where CmpId=@CmpId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CmpId", SqlDbType.Int,4)			};
			parameters[0].Value = CmpId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Blog.Model.BlogCommentPhoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BlogCommentPhoto(");
			strSql.Append("CmpId,CmpAuthor,CmpPhoto,CmpTitle,CmpContent,CmpAddTime,CmpIsDel)");
			strSql.Append(" values (");
			strSql.Append("@CmpId,@CmpAuthor,@CmpPhoto,@CmpTitle,@CmpContent,@CmpAddTime,@CmpIsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@CmpId", SqlDbType.Int,4),
					new SqlParameter("@CmpAuthor", SqlDbType.Int,4),
					new SqlParameter("@CmpPhoto", SqlDbType.Int,4),
					new SqlParameter("@CmpTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@CmpContent", SqlDbType.NVarChar,500),
					new SqlParameter("@CmpAddTime", SqlDbType.DateTime),
					new SqlParameter("@CmpIsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.CmpId;
			parameters[1].Value = model.CmpAuthor;
			parameters[2].Value = model.CmpPhoto;
			parameters[3].Value = model.CmpTitle;
			parameters[4].Value = model.CmpContent;
			parameters[5].Value = model.CmpAddTime;
			parameters[6].Value = model.CmpIsDel;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Blog.Model.BlogCommentPhoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BlogCommentPhoto set ");
			strSql.Append("CmpAuthor=@CmpAuthor,");
			strSql.Append("CmpPhoto=@CmpPhoto,");
			strSql.Append("CmpTitle=@CmpTitle,");
			strSql.Append("CmpContent=@CmpContent,");
			strSql.Append("CmpAddTime=@CmpAddTime,");
			strSql.Append("CmpIsDel=@CmpIsDel");
			strSql.Append(" where CmpId=@CmpId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CmpAuthor", SqlDbType.Int,4),
					new SqlParameter("@CmpPhoto", SqlDbType.Int,4),
					new SqlParameter("@CmpTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@CmpContent", SqlDbType.NVarChar,500),
					new SqlParameter("@CmpAddTime", SqlDbType.DateTime),
					new SqlParameter("@CmpIsDel", SqlDbType.Bit,1),
					new SqlParameter("@CmpId", SqlDbType.Int,4)};
			parameters[0].Value = model.CmpAuthor;
			parameters[1].Value = model.CmpPhoto;
			parameters[2].Value = model.CmpTitle;
			parameters[3].Value = model.CmpContent;
			parameters[4].Value = model.CmpAddTime;
			parameters[5].Value = model.CmpIsDel;
			parameters[6].Value = model.CmpId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CmpId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogCommentPhoto ");
			strSql.Append(" where CmpId=@CmpId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CmpId", SqlDbType.Int,4)			};
			parameters[0].Value = CmpId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CmpIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogCommentPhoto ");
			strSql.Append(" where CmpId in ("+CmpIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blog.Model.BlogCommentPhoto GetModel(int CmpId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CmpId,CmpAuthor,CmpPhoto,CmpTitle,CmpContent,CmpAddTime,CmpIsDel from BlogCommentPhoto ");
			strSql.Append(" where CmpId=@CmpId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CmpId", SqlDbType.Int,4)			};
			parameters[0].Value = CmpId;

			Blog.Model.BlogCommentPhoto model=new Blog.Model.BlogCommentPhoto();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blog.Model.BlogCommentPhoto DataRowToModel(DataRow row)
		{
			Blog.Model.BlogCommentPhoto model=new Blog.Model.BlogCommentPhoto();
			if (row != null)
			{
				if(row["CmpId"]!=null && row["CmpId"].ToString()!="")
				{
					model.CmpId=int.Parse(row["CmpId"].ToString());
				}
				if(row["CmpAuthor"]!=null && row["CmpAuthor"].ToString()!="")
				{
					model.CmpAuthor=int.Parse(row["CmpAuthor"].ToString());
				}
				if(row["CmpPhoto"]!=null && row["CmpPhoto"].ToString()!="")
				{
					model.CmpPhoto=int.Parse(row["CmpPhoto"].ToString());
				}
				if(row["CmpTitle"]!=null)
				{
					model.CmpTitle=row["CmpTitle"].ToString();
				}
				if(row["CmpContent"]!=null)
				{
					model.CmpContent=row["CmpContent"].ToString();
				}
				if(row["CmpAddTime"]!=null && row["CmpAddTime"].ToString()!="")
				{
					model.CmpAddTime=DateTime.Parse(row["CmpAddTime"].ToString());
				}
				if(row["CmpIsDel"]!=null && row["CmpIsDel"].ToString()!="")
				{
					if((row["CmpIsDel"].ToString()=="1")||(row["CmpIsDel"].ToString().ToLower()=="true"))
					{
						model.CmpIsDel=true;
					}
					else
					{
						model.CmpIsDel=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CmpId,CmpAuthor,CmpPhoto,CmpTitle,CmpContent,CmpAddTime,CmpIsDel ");
			strSql.Append(" FROM BlogCommentPhoto ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" CmpId,CmpAuthor,CmpPhoto,CmpTitle,CmpContent,CmpAddTime,CmpIsDel ");
			strSql.Append(" FROM BlogCommentPhoto ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BlogCommentPhoto ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.CmpId desc");
			}
			strSql.Append(")AS Row, T.*  from BlogCommentPhoto T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BlogCommentPhoto";
			parameters[1].Value = "CmpId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

