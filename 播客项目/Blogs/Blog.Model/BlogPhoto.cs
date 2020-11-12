using System;
namespace Blog.Model
{
	/// <summary>
	/// BlogPhoto:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogPhoto
	{
		public BlogPhoto()
		{}
		#region Model
		private int _pid;
		private int _pauthor;
		private int _palbum;
		private string _ptitle;
		private string _premark;
		private string _psrc;
		private int _pstatu=4;
		private DateTime _paddtime= DateTime.Now;
		private bool _pisdel= false;
		/// <summary>
		/// 相册表id
		/// </summary>
		public int PId
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 图片上传者
		/// </summary>
		public int PAuthor
		{
			set{ _pauthor=value;}
			get{return _pauthor;}
		}
		/// <summary>
		/// 所属相册
		/// </summary>
		public int PAlbum
		{
			set{ _palbum=value;}
			get{return _palbum;}
		}
		/// <summary>
		/// 图片名
		/// </summary>
		public string PTitle
		{
			set{ _ptitle=value;}
			get{return _ptitle;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string PRemark
		{
			set{ _premark=value;}
			get{return _premark;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string PSrc
		{
			set{ _psrc=value;}
			get{return _psrc;}
		}
		/// <summary>
		/// 状态 1-公开2-隐藏3-好友公开
		/// </summary>
		public int PStatu
		{
			set{ _pstatu=value;}
			get{return _pstatu;}
		}
		/// <summary>
		/// 新增时间
		/// </summary>
		public DateTime PAddTime
		{
			set{ _paddtime=value;}
			get{return _paddtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool PIsdel
		{
			set{ _pisdel=value;}
			get{return _pisdel;}
		}
		#endregion Model

	}
}

