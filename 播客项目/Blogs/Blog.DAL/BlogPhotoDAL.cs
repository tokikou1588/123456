using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Blog.DBUtility;//Please add references
namespace Blog.DAL
{
	/// <summary>
	/// 数据访问类:BlogPhotoDAL
	/// </summary>
	public partial class BlogPhotoDAL
	{
		public BlogPhotoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PId", "BlogPhoto"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BlogPhoto");
			strSql.Append(" where PId=@PId");
			SqlParameter[] parameters = {
					new SqlParameter("@PId", SqlDbType.Int,4)
			};
			parameters[0].Value = PId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Blog.Model.BlogPhoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BlogPhoto(");
			strSql.Append("PAuthor,PAlbum,PTitle,PRemark,PSrc,PStatu,PAddTime,PIsdel)");
			strSql.Append(" values (");
			strSql.Append("@PAuthor,@PAlbum,@PTitle,@PRemark,@PSrc,@PStatu,@PAddTime,@PIsdel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PAuthor", SqlDbType.Int,4),
					new SqlParameter("@PAlbum", SqlDbType.Int,4),
					new SqlParameter("@PTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PRemark", SqlDbType.NVarChar,50),
					new SqlParameter("@PSrc", SqlDbType.VarChar,100),
					new SqlParameter("@PStatu", SqlDbType.Int,4),
					new SqlParameter("@PAddTime", SqlDbType.DateTime),
					new SqlParameter("@PIsdel", SqlDbType.Bit,1)};
			parameters[0].Value = model.PAuthor;
			parameters[1].Value = model.PAlbum;
			parameters[2].Value = model.PTitle;
			parameters[3].Value = model.PRemark;
			parameters[4].Value = model.PSrc;
			parameters[5].Value = model.PStatu;
			parameters[6].Value = model.PAddTime;
			parameters[7].Value = model.PIsdel;

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
		public bool Update(Blog.Model.BlogPhoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BlogPhoto set ");
			strSql.Append("PAuthor=@PAuthor,");
			strSql.Append("PAlbum=@PAlbum,");
			strSql.Append("PTitle=@PTitle,");
			strSql.Append("PRemark=@PRemark,");
			strSql.Append("PSrc=@PSrc,");
			strSql.Append("PStatu=@PStatu,");
			strSql.Append("PAddTime=@PAddTime,");
			strSql.Append("PIsdel=@PIsdel");
			strSql.Append(" where PId=@PId");
			SqlParameter[] parameters = {
					new SqlParameter("@PAuthor", SqlDbType.Int,4),
					new SqlParameter("@PAlbum", SqlDbType.Int,4),
					new SqlParameter("@PTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PRemark", SqlDbType.NVarChar,50),
					new SqlParameter("@PSrc", SqlDbType.VarChar,100),
					new SqlParameter("@PStatu", SqlDbType.Int,4),
					new SqlParameter("@PAddTime", SqlDbType.DateTime),
					new SqlParameter("@PIsdel", SqlDbType.Bit,1),
					new SqlParameter("@PId", SqlDbType.Int,4)};
			parameters[0].Value = model.PAuthor;
			parameters[1].Value = model.PAlbum;
			parameters[2].Value = model.PTitle;
			parameters[3].Value = model.PRemark;
			parameters[4].Value = model.PSrc;
			parameters[5].Value = model.PStatu;
			parameters[6].Value = model.PAddTime;
			parameters[7].Value = model.PIsdel;
			parameters[8].Value = model.PId;

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
		public bool Delete(int PId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogPhoto ");
			strSql.Append(" where PId=@PId");
			SqlParameter[] parameters = {
					new SqlParameter("@PId", SqlDbType.Int,4)
			};
			parameters[0].Value = PId;

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
		public bool DeleteList(string PIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogPhoto ");
			strSql.Append(" where PId in ("+PIdlist + ")  ");
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
		public Blog.Model.BlogPhoto GetModel(int PId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PId,PAuthor,PAlbum,PTitle,PRemark,PSrc,PStatu,PAddTime,PIsdel from BlogPhoto ");
			strSql.Append(" where PId=@PId");
			SqlParameter[] parameters = {
					new SqlParameter("@PId", SqlDbType.Int,4)
			};
			parameters[0].Value = PId;

			Blog.Model.BlogPhoto model=new Blog.Model.BlogPhoto();
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
		public Blog.Model.BlogPhoto DataRowToModel(DataRow row)
		{
			Blog.Model.BlogPhoto model=new Blog.Model.BlogPhoto();
			if (row != null)
			{
				if(row["PId"]!=null && row["PId"].ToString()!="")
				{
					model.PId=int.Parse(row["PId"].ToString());
				}
				if(row["PAuthor"]!=null && row["PAuthor"].ToString()!="")
				{
					model.PAuthor=int.Parse(row["PAuthor"].ToString());
				}
				if(row["PAlbum"]!=null && row["PAlbum"].ToString()!="")
				{
					model.PAlbum=int.Parse(row["PAlbum"].ToString());
				}
				if(row["PTitle"]!=null)
				{
					model.PTitle=row["PTitle"].ToString();
				}
				if(row["PRemark"]!=null)
				{
					model.PRemark=row["PRemark"].ToString();
				}
				if(row["PSrc"]!=null)
				{
					model.PSrc=row["PSrc"].ToString();
				}
				if(row["PStatu"]!=null && row["PStatu"].ToString()!="")
				{
					model.PStatu=int.Parse(row["PStatu"].ToString());
				}
				if(row["PAddTime"]!=null && row["PAddTime"].ToString()!="")
				{
					model.PAddTime=DateTime.Parse(row["PAddTime"].ToString());
				}
				if(row["PIsdel"]!=null && row["PIsdel"].ToString()!="")
				{
					if((row["PIsdel"].ToString()=="1")||(row["PIsdel"].ToString().ToLower()=="true"))
					{
						model.PIsdel=true;
					}
					else
					{
						model.PIsdel=false;
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
			strSql.Append("select PId,PAuthor,PAlbum,PTitle,PRemark,PSrc,PStatu,PAddTime,PIsdel ");
			strSql.Append(" FROM BlogPhoto ");
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
			strSql.Append(" PId,PAuthor,PAlbum,PTitle,PRemark,PSrc,PStatu,PAddTime,PIsdel ");
			strSql.Append(" FROM BlogPhoto ");
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
			strSql.Append("select count(1) FROM BlogPhoto ");
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
				strSql.Append("order by T.PId desc");
			}
			strSql.Append(")AS Row, T.*  from BlogPhoto T ");
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
			parameters[0].Value = "BlogPhoto";
			parameters[1].Value = "PId";
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

