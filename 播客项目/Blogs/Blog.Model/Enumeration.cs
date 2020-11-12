using System;
namespace Blog.Model
{
	/// <summary>
	/// Enumeration:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Enumeration
	{
		public Enumeration()
		{}
		#region Model
		private int _e_id;
		private string _e_ename;
		private string _e_cname;
		private string _e_type;
		private string _e_remark;
		private DateTime _e_addtime= DateTime.Now;
		private bool _e_isdel= false;
		/// <summary>
		/// 枚举表id
		/// </summary>
		public int e_id
		{
			set{ _e_id=value;}
			get{return _e_id;}
		}
		/// <summary>
		/// 枚举英文名
		/// </summary>
		public string e_ename
		{
			set{ _e_ename=value;}
			get{return _e_ename;}
		}
		/// <summary>
		/// 枚举中文名
		/// </summary>
		public string e_cname
		{
			set{ _e_cname=value;}
			get{return _e_cname;}
		}
		/// <summary>
		/// 父枚举id
		/// </summary>
		public string e_type
		{
			set{ _e_type=value;}
			get{return _e_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_remark
		{
			set{ _e_remark=value;}
			get{return _e_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime e_addtime
		{
			set{ _e_addtime=value;}
			get{return _e_addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool e_isDel
		{
			set{ _e_isdel=value;}
			get{return _e_isdel;}
		}
		#endregion Model

	}
}

