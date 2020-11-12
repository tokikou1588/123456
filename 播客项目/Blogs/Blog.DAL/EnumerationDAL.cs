using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Blog.DBUtility;//Please add references
namespace Blog.DAL
{
	/// <summary>
	/// 数据访问类:EnumerationDAL
	/// </summary>
	public partial class EnumerationDAL
	{
		public EnumerationDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("e_id", "Enumeration"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int e_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Enumeration");
			strSql.Append(" where e_id=@e_id");
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.Int,4)
			};
			parameters[0].Value = e_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Blog.Model.Enumeration model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Enumeration(");
			strSql.Append("e_ename,e_cname,e_type,e_remark,e_addtime,e_isDel)");
			strSql.Append(" values (");
			strSql.Append("@e_ename,@e_cname,@e_type,@e_remark,@e_addtime,@e_isDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ename", SqlDbType.VarChar,50),
					new SqlParameter("@e_cname", SqlDbType.VarChar,50),
					new SqlParameter("@e_type", SqlDbType.VarChar,50),
					new SqlParameter("@e_remark", SqlDbType.VarChar,200),
					new SqlParameter("@e_addtime", SqlDbType.DateTime),
					new SqlParameter("@e_isDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.e_ename;
			parameters[1].Value = model.e_cname;
			parameters[2].Value = model.e_type;
			parameters[3].Value = model.e_remark;
			parameters[4].Value = model.e_addtime;
			parameters[5].Value = model.e_isDel;

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
		public bool Update(Blog.Model.Enumeration model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Enumeration set ");
			strSql.Append("e_ename=@e_ename,");
			strSql.Append("e_cname=@e_cname,");
			strSql.Append("e_type=@e_type,");
			strSql.Append("e_remark=@e_remark,");
			strSql.Append("e_addtime=@e_addtime,");
			strSql.Append("e_isDel=@e_isDel");
			strSql.Append(" where e_id=@e_id");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ename", SqlDbType.VarChar,50),
					new SqlParameter("@e_cname", SqlDbType.VarChar,50),
					new SqlParameter("@e_type", SqlDbType.VarChar,50),
					new SqlParameter("@e_remark", SqlDbType.VarChar,200),
					new SqlParameter("@e_addtime", SqlDbType.DateTime),
					new SqlParameter("@e_isDel", SqlDbType.Bit,1),
					new SqlParameter("@e_id", SqlDbType.Int,4)};
			parameters[0].Value = model.e_ename;
			parameters[1].Value = model.e_cname;
			parameters[2].Value = model.e_type;
			parameters[3].Value = model.e_remark;
			parameters[4].Value = model.e_addtime;
			parameters[5].Value = model.e_isDel;
			parameters[6].Value = model.e_id;

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
		public bool Delete(int e_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Enumeration ");
			strSql.Append(" where e_id=@e_id");
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.Int,4)
			};
			parameters[0].Value = e_id;

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
		public bool DeleteList(string e_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Enumeration ");
			strSql.Append(" where e_id in ("+e_idlist + ")  ");
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
		public Blog.Model.Enumeration GetModel(int e_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 e_id,e_ename,e_cname,e_type,e_remark,e_addtime,e_isDel from Enumeration ");
			strSql.Append(" where e_id=@e_id");
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.Int,4)
			};
			parameters[0].Value = e_id;

			Blog.Model.Enumeration model=new Blog.Model.Enumeration();
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
		public Blog.Model.Enumeration DataRowToModel(DataRow row)
		{
			Blog.Model.Enumeration model=new Blog.Model.Enumeration();
			if (row != null)
			{
				if(row["e_id"]!=null && row["e_id"].ToString()!="")
				{
					model.e_id=int.Parse(row["e_id"].ToString());
				}
				if(row["e_ename"]!=null)
				{
					model.e_ename=row["e_ename"].ToString();
				}
				if(row["e_cname"]!=null)
				{
					model.e_cname=row["e_cname"].ToString();
				}
				if(row["e_type"]!=null)
				{
					model.e_type=row["e_type"].ToString();
				}
				if(row["e_remark"]!=null)
				{
					model.e_remark=row["e_remark"].ToString();
				}
				if(row["e_addtime"]!=null && row["e_addtime"].ToString()!="")
				{
					model.e_addtime=DateTime.Parse(row["e_addtime"].ToString());
				}
				if(row["e_isDel"]!=null && row["e_isDel"].ToString()!="")
				{
					if((row["e_isDel"].ToString()=="1")||(row["e_isDel"].ToString().ToLower()=="true"))
					{
						model.e_isDel=true;
					}
					else
					{
						model.e_isDel=false;
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
			strSql.Append("select e_id,e_ename,e_cname,e_type,e_remark,e_addtime,e_isDel ");
			strSql.Append(" FROM Enumeration ");
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
			strSql.Append(" e_id,e_ename,e_cname,e_type,e_remark,e_addtime,e_isDel ");
			strSql.Append(" FROM Enumeration ");
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
			strSql.Append("select count(1) FROM Enumeration ");
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
				strSql.Append("order by T.e_id desc");
			}
			strSql.Append(")AS Row, T.*  from Enumeration T ");
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
			parameters[0].Value = "Enumeration";
			parameters[1].Value = "e_id";
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

