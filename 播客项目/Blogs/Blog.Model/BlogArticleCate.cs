using System;
namespace Blog.Model
{
	/// <summary>
	/// BlogArticleCate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogArticleCate
	{
		public BlogArticleCate()
		{}
		#region Model
		private int _id;
		private int _author;
		private string _name;
		private string _remark;
		private int _statu=1;
		private bool _isdel= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 文章类别表
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 作者id
		/// </summary>
		public int Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 博客分类名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 博客分类介绍
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 状态 1-公开2-隐藏3-好友公开
		/// </summary>
		public int Statu
		{
			set{ _statu=value;}
			get{return _statu;}
		}
		/// <summary>
		/// 删除标志
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 新增时间
		/// </summary>
		public DateTime Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

