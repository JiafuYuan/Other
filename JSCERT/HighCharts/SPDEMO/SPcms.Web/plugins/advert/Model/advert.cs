using System;
namespace SPcms.Web.Plugin.Advert.Model
{
    /// <summary>
    /// ���λ:ʵ����
    /// </summary>
    [Serializable]
    public partial class advert
    {
        public advert()
        { }
        #region Model
        private int _id;
        private string _title;
        private int _type;
        private decimal _price = 0M;
        private string _remark;
        private int _view_num = 0;
        private int _view_width = 0;
        private int _view_height = 0;
        private string _target;
        private DateTime _add_time = DateTime.Now;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ���λ����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ���λ����
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// ���λ�۸�
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// ��ע˵��
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// ��ʾ�����
        /// </summary>
        public int view_num
        {
            set { _view_num = value; }
            get { return _view_num; }
        }
        /// <summary>
        /// ���λ���
        /// </summary>
        public int view_width
        {
            set { _view_width = value; }
            get { return _view_width; }
        }
        /// <summary>
        /// ���λ�߶�
        /// </summary>
        public int view_height
        {
            set { _view_height = value; }
            get { return _view_height; }
        }
        /// <summary>
        /// ����Ŀ�� �´���,ԭ����
        /// </summary>
        public string target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}