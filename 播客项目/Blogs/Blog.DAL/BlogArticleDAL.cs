using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Blog.DBUtility;//Please add references
namespace Blog.DAL
{
	/// <summary>
	/// 数据访问类:BlogArticleDAL
	/// </summary>
	public partial class BlogArticleDAL
	{
		public BlogArticleDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AId", "BlogArticle"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BlogArticle");
			strSql.Append(" where AId=@AId");
			SqlParameter[] parameters = {
					new SqlParameter("@AId", SqlDbType.Int,4)
			};
			parameters[0].Value = AId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Blog.Model.BlogArticle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BlogArticle(");
			strSql.Append("ACate,AAuthor,ATitle,AContent,AImgsrc,APlnum,AAllowPL,AIsTop,ATag,ACick,AStatu,AAddtime,AUpdatetime,AIsDel,AHtmlSrc)");
			strSql.Append(" values (");
			strSql.Append("@ACate,@AAuthor,@ATitle,@AContent,@AImgsrc,@APlnum,@AAllowPL,@AIsTop,@ATag,@ACick,@AStatu,@AAddtime,@AUpdatetime,@AIsDel,@AHtmlSrc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ACate", SqlDbType.Int,4),
					new SqlParameter("@AAuthor", SqlDbType.Int,4),
					new SqlParameter("@ATitle", SqlDbType.NVarChar,100),
					new SqlParameter("@AContent", SqlDbType.NText),
					new SqlParameter("@AImgsrc", SqlDbType.NVarChar,200),
					new SqlParameter("@APlnum", SqlDbType.Int,4),
					new SqlParameter("@AAllowPL", SqlDbType.Bit,1),
					new SqlParameter("@AIsTop", SqlDbType.Bit,1),
					new SqlParameter("@ATag", SqlDbType.NVarChar,50),
					new SqlParameter("@ACick", SqlDbType.Int,4),
					new SqlParameter("@AStatu", SqlDbType.Int,4),
					new SqlParameter("@AAddtime", SqlDbType.DateTime),
					new SqlParameter("@AUpdatetime", SqlDbType.DateTime),
					new SqlParameter("@AIsDel", SqlDbType.Bit,1),
					new SqlParameter("@AHtmlSrc", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ACate;
			parameters[1].Value = model.AAuthor;
			parameters[2].Value = model.ATitle;
			parameters[3].Value = model.AContent;
			parameters[4].Value = model.AImgsrc;
			parameters[5].Value = model.APlnum;
			parameters[6].Value = model.AAllowPL;
			parameters[7].Value = model.AIsTop;
			parameters[8].Value = model.ATag;
			parameters[9].Value = model.ACick;
			parameters[10].Value = model.AStatu;
			parameters[11].Value = model.AAddtime;
			parameters[12].Value = model.AUpdatetime;
			parameters[13].Value = model.AIsDel;
			parameters[14].Value = model.AHtmlSrc;

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
		public bool Update(Blog.Model.BlogArticle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BlogArticle set ");
			strSql.Append("ACate=@ACate,");
			strSql.Append("AAuthor=@AAuthor,");
			strSql.Append("ATitle=@ATitle,");
			strSql.Append("AContent=@AContent,");
			strSql.Append("AImgsrc=@AImgsrc,");
			strSql.Append("APlnum=@APlnum,");
			strSql.Append("AAllowPL=@AAllowPL,");
			strSql.Append("AIsTop=@AIsTop,");
			strSql.Append("ATag=@ATag,");
			strSql.Append("ACick=@ACick,");
			strSql.Append("AStatu=@AStatu,");
			strSql.Append("AAddtime=@AAddtime,");
			strSql.Append("AUpdatetime=@AUpdatetime,");
			strSql.Append("AIsDel=@AIsDel,");
			strSql.Append("AHtmlSrc=@AHtmlSrc");
			strSql.Append(" where AId=@AId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACate", SqlDbType.Int,4),
					new SqlParameter("@AAuthor", SqlDbType.Int,4),
					new SqlParameter("@ATitle", SqlDbType.NVarChar,100),
					new SqlParameter("@AContent", SqlDbType.NText),
					new SqlParameter("@AImgsrc", SqlDbType.NVarChar,200),
					new SqlParameter("@APlnum", SqlDbType.Int,4),
					new SqlParameter("@AAllowPL", SqlDbType.Bit,1),
					new SqlParameter("@AIsTop", SqlDbType.Bit,1),
					new SqlParameter("@ATag", SqlDbType.NVarChar,50),
					new SqlParameter("@ACick", SqlDbType.Int,4),
					new SqlParameter("@AStatu", SqlDbType.Int,4),
					new SqlParameter("@AAddtime", SqlDbType.DateTime),
					new SqlParameter("@AUpdatetime", SqlDbType.DateTime),
					new SqlParameter("@AIsDel", SqlDbType.Bit,1),
					new SqlParameter("@AHtmlSrc", SqlDbType.NVarChar,50),
					new SqlParameter("@AId", SqlDbType.Int,4)};
			parameters[0].Value = model.ACate;
			parameters[1].Value = model.AAuthor;
			parameters[2].Value = model.ATitle;
			parameters[3].Value = model.AContent;
			parameters[4].Value = model.AImgsrc;
			parameters[5].Value = model.APlnum;
			parameters[6].Value = model.AAllowPL;
			parameters[7].Value = model.AIsTop;
			parameters[8].Value = model.ATag;
			parameters[9].Value = model.ACick;
			parameters[10].Value = model.AStatu;
			parameters[11].Value = model.AAddtime;
			parameters[12].Value = model.AUpdatetime;
			parameters[13].Value = model.AIsDel;
			parameters[14].Value = model.AHtmlSrc;
			parameters[15].Value = model.AId;

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
		public bool Delete(int AId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogArticle ");
			strSql.Append(" where AId=@AId");
			SqlParameter[] parameters = {
					new SqlParameter("@AId", SqlDbType.Int,4)
			};
			parameters[0].Value = AId;

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
		public bool DeleteList(string AIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogArticle ");
			strSql.Append(" where AId in ("+AIdlist + ")  ");
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
		public Blog.Model.BlogArticle GetModel(int AId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AId,ACate,AAuthor,ATitle,AContent,AImgsrc,APlnum,AAllowPL,AIsTop,ATag,ACick,AStatu,AAddtime,AUpdatetime,AIsDel,AHtmlSrc from BlogArticle ");
			strSql.Append(" where AId=@AId");
			SqlParameter[] parameters = {
					new SqlParameter("@AId", SqlDbType.Int,4)
			};
			parameters[0].Value = AId;

			Blog.Model.BlogArticle model=new Blog.Model.BlogArticle();
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
		public Blog.Model.BlogArticle DataRowToModel(DataRow row)
		{
			Blog.Model.BlogArticle model=new Blog.Model.BlogArticle();
			if (row != null)
			{
				if(row["AId"]!=null && row["AId"].ToString()!="")
				{
					model.AId=int.Parse(row["AId"].ToString());
				}
				if(row["ACate"]!=null && row["ACate"].ToString()!="")
				{
					model.ACate=int.Parse(row["ACate"].ToString());
				}
				if(row["AAuthor"]!=null && row["AAuthor"].ToString()!="")
				{
					model.AAuthor=int.Parse(row["AAuthor"].ToString());
				}
				if(row["ATitle"]!=null)
				{
					model.ATitle=row["ATitle"].ToString();
				}
				if(row["AContent"]!=null)
				{
					model.AContent=row["AContent"].ToString();
				}
				if(row["AImgsrc"]!=null)
				{
					model.AImgsrc=row["AImgsrc"].ToString();
				}
				if(row["APlnum"]!=null && row["APlnum"].ToString()!="")
				{
					model.APlnum=int.Parse(row["APlnum"].ToString());
				}
				if(row["AAllowPL"]!=null && row["AAllowPL"].ToString()!="")
				{
					if((row["AAllowPL"].ToString()=="1")||(row["AAllowPL"].ToString().ToLower()=="true"))
					{
						model.AAllowPL=true;
					}
					else
					{
						model.AAllowPL=false;
					}
				}
				if(row["AIsTop"]!=null && row["AIsTop"].ToString()!="")
				{
					if((row["AIsTop"].ToString()=="1")||(row["AIsTop"].ToString().ToLower()=="true"))
					{
						model.AIsTop=true;
					}
					else
					{
						model.AIsTop=false;
					}
				}
				if(row["ATag"]!=null)
				{
					model.ATag=row["ATag"].ToString();
				}
				if(row["ACick"]!=null && row["ACick"].ToString()!="")
				{
					model.ACick=int.Parse(row["ACick"].ToString());
				}
				if(row["AStatu"]!=null && row["AStatu"].ToString()!="")
				{
					model.AStatu=int.Parse(row["AStatu"].ToString());
				}
				if(row["AAddtime"]!=null && row["AAddtime"].ToString()!="")
				{
					model.AAddtime=DateTime.Parse(row["AAddtime"].ToString());
				}
				if(row["AUpdatetime"]!=null && row["AUpdatetime"].ToString()!="")
				{
					model.AUpdatetime=DateTime.Parse(row["AUpdatetime"].ToString());
				}
				if(row["AIsDel"]!=null && row["AIsDel"].ToString()!="")
				{
					if((row["AIsDel"].ToString()=="1")||(row["AIsDel"].ToString().ToLower()=="true"))
					{
						model.AIsDel=true;
					}
					else
					{
						model.AIsDel=false;
					}
				}
				if(row["AHtmlSrc"]!=null)
				{
					model.AHtmlSrc=row["AHtmlSrc"].ToString();
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
			strSql.Append("select AId,ACate,AAuthor,ATitle,AContent,AImgsrc,APlnum,AAllowPL,AIsTop,ATag,ACick,AStatu,AAddtime,AUpdatetime,AIsDel,AHtmlSrc ");
			strSql.Append(" FROM BlogArticle ");
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
			strSql.Append(" AId,ACate,AAuthor,ATitle,AContent,AImgsrc,APlnum,AAllowPL,AIsTop,ATag,ACick,AStatu,AAddtime,AUpdatetime,AIsDel,AHtmlSrc ");
			strSql.Append(" FROM BlogArticle ");
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
			strSql.Append("select count(1) FROM BlogArticle ");
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
				strSql.Append("order by T.AId desc");
			}
			strSql.Append(")AS Row, T.*  from BlogArticle T ");
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
			parameters[0].Value = "BlogArticle";
			parameters[1].Value = "AId";
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

