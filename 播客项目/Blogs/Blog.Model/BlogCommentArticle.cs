using System;
namespace Blog.Model
{
	/// <summary>
	/// BlogCommentArticle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogCommentArticle
	{
		public BlogCommentArticle()
		{}
		#region Model
		private int _cmaid;
		private int _cmaarticle;
		private int _cmaauthor;
		private string _cmatitle;
		private string _cmacontent;
		private DateTime _cmaaddtime= DateTime.Now;
		private bool _cmaisdel= false;
		/// <summary>
		/// 文章评论表id
		/// </summary>
		public int CmaId
		{
			set{ _cmaid=value;}
			get{return _cmaid;}
		}
		/// <summary>
		/// 被评论文章
		/// </summary>
		public int CmaArticle
		{
			set{ _cmaarticle=value;}
			get{return _cmaarticle;}
		}
		/// <summary>
		/// 评论作者
		/// </summary>
		public int CmaAuthor
		{
			set{ _cmaauthor=value;}
			get{return _cmaauthor;}
		}
		/// <summary>
		/// 评论标题
		/// </summary>
		public string CmaTitle
		{
			set{ _cmatitle=value;}
			get{return _cmatitle;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string CmaContent
		{
			set{ _cmacontent=value;}
			get{return _cmacontent;}
		}
		/// <summary>
		/// 评论时间
		/// </summary>
		public DateTime CmaAddTime
		{
			set{ _cmaaddtime=value;}
			get{return _cmaaddtime;}
		}
		/// <summary>
		/// 删除标志
		/// </summary>
		public bool CmaIsDel
		{
			set{ _cmaisdel=value;}
			get{return _cmaisdel;}
		}
		#endregion Model

	}
}

