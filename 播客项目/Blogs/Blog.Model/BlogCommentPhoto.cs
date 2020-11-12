using System;
namespace Blog.Model
{
	/// <summary>
	/// BlogCommentPhoto:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogCommentPhoto
	{
		public BlogCommentPhoto()
		{}
		#region Model
		private int _cmpid;
		private int _cmpauthor;
		private int _cmpphoto;
		private string _cmptitle;
		private string _cmpcontent;
		private DateTime _cmpaddtime= DateTime.Now;
		private bool _cmpisdel= false;
		/// <summary>
		/// 照片评论表id
		/// </summary>
		public int CmpId
		{
			set{ _cmpid=value;}
			get{return _cmpid;}
		}
		/// <summary>
		/// 评论人
		/// </summary>
		public int CmpAuthor
		{
			set{ _cmpauthor=value;}
			get{return _cmpauthor;}
		}
		/// <summary>
		/// 被评论的照片
		/// </summary>
		public int CmpPhoto
		{
			set{ _cmpphoto=value;}
			get{return _cmpphoto;}
		}
		/// <summary>
		/// 评论标题
		/// </summary>
		public string CmpTitle
		{
			set{ _cmptitle=value;}
			get{return _cmptitle;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string CmpContent
		{
			set{ _cmpcontent=value;}
			get{return _cmpcontent;}
		}
		/// <summary>
		/// 发表时间
		/// </summary>
		public DateTime CmpAddTime
		{
			set{ _cmpaddtime=value;}
			get{return _cmpaddtime;}
		}
		/// <summary>
		/// 删除标志
		/// </summary>
		public bool CmpIsDel
		{
			set{ _cmpisdel=value;}
			get{return _cmpisdel;}
		}
		#endregion Model

	}
}

