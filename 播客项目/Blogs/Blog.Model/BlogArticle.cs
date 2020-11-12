using System;
namespace Blog.Model
{
	/// <summary>
	/// BlogArticle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogArticle
	{
		public BlogArticle()
		{}
		#region Model
		private int _aid;
		private int _acate;
		private int _aauthor;
		private string _atitle;
		private string _acontent;
		private string _aimgsrc;
		private int _aplnum=0;
		private bool _aallowpl= true;
		private bool _aistop= false;
		private string _atag;
		private int _acick=0;
		private int _astatu=2;
		private DateTime _aaddtime= DateTime.Now;
		private DateTime _aupdatetime= DateTime.Now;
		private bool _aisdel= false;
		private string _ahtmlsrc;
		/// <summary>
		/// 文章表ID
		/// </summary>
		public int AId
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 所属类别
		/// </summary>
		public int ACate
		{
			set{ _acate=value;}
			get{return _acate;}
		}
		/// <summary>
		/// 作者
		/// </summary>
		public int AAuthor
		{
			set{ _aauthor=value;}
			get{return _aauthor;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string ATitle
		{
			set{ _atitle=value;}
			get{return _atitle;}
		}
		/// <summary>
		/// 文章内容
		/// </summary>
		public string AContent
		{
			set{ _acontent=value;}
			get{return _acontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AImgsrc
		{
			set{ _aimgsrc=value;}
			get{return _aimgsrc;}
		}
		/// <summary>
		/// 评论数
		/// </summary>
		public int APlnum
		{
			set{ _aplnum=value;}
			get{return _aplnum;}
		}
		/// <summary>
		/// 是否允许评论
		/// </summary>
		public bool AAllowPL
		{
			set{ _aallowpl=value;}
			get{return _aallowpl;}
		}
		/// <summary>
		/// 是否置顶
		/// </summary>
		public bool AIsTop
		{
			set{ _aistop=value;}
			get{return _aistop;}
		}
		/// <summary>
		/// 文章标签
		/// </summary>
		public string ATag
		{
			set{ _atag=value;}
			get{return _atag;}
		}
		/// <summary>
		/// 点击次数
		/// </summary>
		public int ACick
		{
			set{ _acick=value;}
			get{return _acick;}
		}
		/// <summary>
		/// 状态 1-公开2-隐藏3-好友公开
		/// </summary>
		public int AStatu
		{
			set{ _astatu=value;}
			get{return _astatu;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime AAddtime
		{
			set{ _aaddtime=value;}
			get{return _aaddtime;}
		}
		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime AUpdatetime
		{
			set{ _aupdatetime=value;}
			get{return _aupdatetime;}
		}
		/// <summary>
		/// 删除标志
		/// </summary>
		public bool AIsDel
		{
			set{ _aisdel=value;}
			get{return _aisdel;}
		}
		/// <summary>
		/// 用来保存这篇文章的静态页面地址
		/// </summary>
		public string AHtmlSrc
		{
			set{ _ahtmlsrc=value;}
			get{return _ahtmlsrc;}
		}
		#endregion Model

	}
}

