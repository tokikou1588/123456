using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Ajax.DBUtility;//Please add references
namespace Ajax.DAL
{
	/// <summary>
	/// 数据访问类:GroupInfoDAL
	/// </summary>
	public partial class GroupInfoDAL
	{
		public GroupInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GroupId", "GroupInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GroupId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GroupInfo");
			strSql.Append(" where GroupId=@GroupId");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)
			};
			parameters[0].Value = GroupId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Ajax.Model.GroupInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GroupInfo(");
			strSql.Append("GroupName)");
			strSql.Append(" values (");
			strSql.Append("@GroupName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,300)};
			parameters[0].Value = model.GroupName;

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
		public bool Update(Ajax.Model.GroupInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GroupInfo set ");
			strSql.Append("GroupName=@GroupName");
			strSql.Append(" where GroupId=@GroupId");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,300),
					new SqlParameter("@GroupId", SqlDbType.Int,4)};
			parameters[0].Value = model.GroupName;
			parameters[1].Value = model.GroupId;

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
		public bool Delete(int GroupId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupInfo ");
			strSql.Append(" where GroupId=@GroupId");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)
			};
			parameters[0].Value = GroupId;

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
		public bool DeleteList(string GroupIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupInfo ");
			strSql.Append(" where GroupId in ("+GroupIdlist + ")  ");
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
		public Ajax.Model.GroupInfo GetModel(int GroupId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 GroupId,GroupName from GroupInfo ");
			strSql.Append(" where GroupId=@GroupId");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)
			};
			parameters[0].Value = GroupId;

			Ajax.Model.GroupInfo model=new Ajax.Model.GroupInfo();
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
		public Ajax.Model.GroupInfo DataRowToModel(DataRow row)
		{
			Ajax.Model.GroupInfo model=new Ajax.Model.GroupInfo();
			if (row != null)
			{
				if(row["GroupId"]!=null && row["GroupId"].ToString()!="")
				{
					model.GroupId=int.Parse(row["GroupId"].ToString());
				}
				if(row["GroupName"]!=null)
				{
					model.GroupName=row["GroupName"].ToString();
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
			strSql.Append("select GroupId,GroupName ");
			strSql.Append(" FROM GroupInfo ");
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
			strSql.Append(" GroupId,GroupName ");
			strSql.Append(" FROM GroupInfo ");
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
			strSql.Append("select count(1) FROM GroupInfo ");
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
				strSql.Append("order by T.GroupId desc");
			}
			strSql.Append(")AS Row, T.*  from GroupInfo T ");
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
			parameters[0].Value = "GroupInfo";
			parameters[1].Value = "GroupId";
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

