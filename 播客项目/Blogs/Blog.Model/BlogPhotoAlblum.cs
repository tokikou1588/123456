using System;
namespace Blog.Model
{
	/// <summary>
	/// BlogPhotoAlblum:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogPhotoAlblum
	{
		public BlogPhotoAlblum()
		{}
		#region Model
		private int _paid;
		private int _paauthor;
		private string _patitle;
		private string _paremark;
		private string _pacoversrc="no.jpg";
		private int _paphotonum=0;
		private int _paplnum=0;
		private int _pastatu=1;
		private DateTime _paaddtime= DateTime.Now;
		private bool _paisdel= false;
		/// <summary>
		/// 相册表id
		/// </summary>
		public int PaId
		{
			set{ _paid=value;}
			get{return _paid;}
		}
		/// <summary>
		/// 上传者
		/// </summary>
		public int PaAuthor
		{
			set{ _paauthor=value;}
			get{return _paauthor;}
		}
		/// <summary>
		/// 相册名
		/// </summary>
		public string PaTitle
		{
			set{ _patitle=value;}
			get{return _patitle;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string PaRemark
		{
			set{ _paremark=value;}
			get{return _paremark;}
		}
		/// <summary>
		/// 封面图片名
		/// </summary>
		public string PaCoverSrc
		{
			set{ _pacoversrc=value;}
			get{return _pacoversrc;}
		}
		/// <summary>
		/// 相片总数
		/// </summary>
		public int PaPhotoNum
		{
			set{ _paphotonum=value;}
			get{return _paphotonum;}
		}
		/// <summary>
		/// 相册总评论数
		/// </summary>
		public int PaPLNum
		{
			set{ _paplnum=value;}
			get{return _paplnum;}
		}
		/// <summary>
		/// 状态 1-公开2-隐藏3-好友公开
		/// </summary>
		public int PaStatu
		{
			set{ _pastatu=value;}
			get{return _pastatu;}
		}
		/// <summary>
		/// 新增时间
		/// </summary>
		public DateTime PaAddtime
		{
			set{ _paaddtime=value;}
			get{return _paaddtime;}
		}
		/// <summary>
		/// 删除标志
		/// </summary>
		public bool PaIsDel
		{
			set{ _paisdel=value;}
			get{return _paisdel;}
		}
		#endregion Model

	}
}

