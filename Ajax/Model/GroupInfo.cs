using System;
namespace Ajax.Model
{
	/// <summary>
	/// GroupInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GroupInfo
	{
		public GroupInfo()
		{}
		#region Model
		private int _groupid;
		private string _groupname;
		/// <summary>
		/// 
		/// </summary>
		public int GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		#endregion Model

	}
}

