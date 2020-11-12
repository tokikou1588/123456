using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Blog.DBUtility;//Please add references
namespace Blog.DAL
{
	/// <summary>
	/// 数据访问类:BlogCommentArticleDAL
	/// </summary>
	public partial class BlogCommentArticleDAL
	{
		public BlogCommentArticleDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CmaId", "BlogCommentArticle"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CmaId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BlogCommentArticle");
			strSql.Append(" where CmaId=@CmaId");
			SqlParameter[] parameters = {
					new SqlParameter("@CmaId", SqlDbType.Int,4)
			};
			parameters[0].Value = CmaId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Blog.Model.BlogCommentArticle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BlogCommentArticle(");
			strSql.Append("CmaArticle,CmaAuthor,CmaTitle,CmaContent,CmaAddTime,CmaIsDel)");
			strSql.Append(" values (");
			strSql.Append("@CmaArticle,@CmaAuthor,@CmaTitle,@CmaContent,@CmaAddTime,@CmaIsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CmaArticle", SqlDbType.Int,4),
					new SqlParameter("@CmaAuthor", SqlDbType.Int,4),
					new SqlParameter("@CmaTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@CmaContent", SqlDbType.NVarChar,500),
					new SqlParameter("@CmaAddTime", SqlDbType.DateTime),
					new SqlParameter("@CmaIsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.CmaArticle;
			parameters[1].Value = model.CmaAuthor;
			parameters[2].Value = model.CmaTitle;
			parameters[3].Value = model.CmaContent;
			parameters[4].Value = model.CmaAddTime;
			parameters[5].Value = model.CmaIsDel;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Blog.Model.BlogCommentArticle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BlogCommentArticle set ");
			strSql.Append("CmaArticle=@CmaArticle,");
			strSql.Append("CmaAuthor=@CmaAuthor,");
			strSql.Append("CmaTitle=@CmaTitle,");
			strSql.Append("CmaContent=@CmaContent,");
			strSql.Append("CmaAddTime=@CmaAddTime,");
			strSql.Append("CmaIsDel=@CmaIsDel");
			strSql.Append(" where CmaId=@CmaId");
			SqlParameter[] parameters = {
					new SqlParameter("@CmaArticle", SqlDbType.Int,4),
					new SqlParameter("@CmaAuthor", SqlDbType.Int,4),
					new SqlParameter("@CmaTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@CmaContent", SqlDbType.NVarChar,500),
					new SqlParameter("@CmaAddTime", SqlDbType.DateTime),
					new SqlParameter("@CmaIsDel", SqlDbType.Bit,1),
					new SqlParameter("@CmaId", SqlDbType.Int,4)};
			parameters[0].Value = model.CmaArticle;
			parameters[1].Value = model.CmaAuthor;
			parameters[2].Value = model.CmaTitle;
			parameters[3].Value = model.CmaContent;
			parameters[4].Value = model.CmaAddTime;
			parameters[5].Value = model.CmaIsDel;
			parameters[6].Value = model.CmaId;

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
		public bool Delete(int CmaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogCommentArticle ");
			strSql.Append(" where CmaId=@CmaId");
			SqlParameter[] parameters = {
					new SqlParameter("@CmaId", SqlDbType.Int,4)
			};
			parameters[0].Value = CmaId;

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
		public bool DeleteList(string CmaIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogCommentArticle ");
			strSql.Append(" where CmaId in ("+CmaIdlist + ")  ");
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
		public Blog.Model.BlogCommentArticle GetModel(int CmaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CmaId,CmaArticle,CmaAuthor,CmaTitle,CmaContent,CmaAddTime,CmaIsDel from BlogCommentArticle ");
			strSql.Append(" where CmaId=@CmaId");
			SqlParameter[] parameters = {
					new SqlParameter("@CmaId", SqlDbType.Int,4)
			};
			parameters[0].Value = CmaId;

			Blog.Model.BlogCommentArticle model=new Blog.Model.BlogCommentArticle();
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
		public Blog.Model.BlogCommentArticle DataRowToModel(DataRow row)
		{
			Blog.Model.BlogCommentArticle model=new Blog.Model.BlogCommentArticle();
			if (row != null)
			{
				if(row["CmaId"]!=null && row["CmaId"].ToString()!="")
				{
					model.CmaId=int.Parse(row["CmaId"].ToString());
				}
				if(row["CmaArticle"]!=null && row["CmaArticle"].ToString()!="")
				{
					model.CmaArticle=int.Parse(row["CmaArticle"].ToString());
				}
				if(row["CmaAuthor"]!=null && row["CmaAuthor"].ToString()!="")
				{
					model.CmaAuthor=int.Parse(row["CmaAuthor"].ToString());
				}
				if(row["CmaTitle"]!=null)
				{
					model.CmaTitle=row["CmaTitle"].ToString();
				}
				if(row["CmaContent"]!=null)
				{
					model.CmaContent=row["CmaContent"].ToString();
				}
				if(row["CmaAddTime"]!=null && row["CmaAddTime"].ToString()!="")
				{
					model.CmaAddTime=DateTime.Parse(row["CmaAddTime"].ToString());
				}
				if(row["CmaIsDel"]!=null && row["CmaIsDel"].ToString()!="")
				{
					if((row["CmaIsDel"].ToString()=="1")||(row["CmaIsDel"].ToString().ToLower()=="true"))
					{
						model.CmaIsDel=true;
					}
					else
					{
						model.CmaIsDel=false;
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
			strSql.Append("select CmaId,CmaArticle,CmaAuthor,CmaTitle,CmaContent,CmaAddTime,CmaIsDel ");
			strSql.Append(" FROM BlogCommentArticle ");
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
			strSql.Append(" CmaId,CmaArticle,CmaAuthor,CmaTitle,CmaContent,CmaAddTime,CmaIsDel ");
			strSql.Append(" FROM BlogCommentArticle ");
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
			strSql.Append("select count(1) FROM BlogCommentArticle ");
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
				strSql.Append("order by T.CmaId desc");
			}
			strSql.Append(")AS Row, T.*  from BlogCommentArticle T ");
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
			parameters[0].Value = "BlogCommentArticle";
			parameters[1].Value = "CmaId";
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

