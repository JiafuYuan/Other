using System;
using System.Collections.Generic;
using System.Text;
using Bestway.Windows.Program.SocketDataModel.MMS;

namespace Bestway.Windows.Program.MMS
{

    /// <summary>数据点类型</summary>
    public enum EnumNodeType
    {
        Unknow      = -1,       //未知
        Total       = 0,         //累计数据
        Realtime    = 1,      //实时数据
        State       = 2          //状态
    }



    /// <summary>数据点</summary>
    class Node : ICloneable
    {
        public Node()
        {
            Type = EnumNodeType.Unknow;
            Value = 0;
            Address = "";
            DataTime = new DateTime(2000, 1, 1);
        }
        /// <summary>节点类型</summary>
        public EnumNodeType Type { get; set; }
        /// <summary>节点值</summary>
        public object Value { get; set; }
        /// <summary>值时间</summary>
        public DateTime DataTime { get; set; }

        /// <summary>节点地址</summary>
        public string Address { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 设备监测节点
    /// </summary>
    class SensorNodes : ICloneable, IEnumerable<Node>
    {
        public SensorNodes()
        {
            //lstNode = new Dictionary<EnumNodeType, Node>();

            //foreach (EnumNodeType nt in Enum.GetValues(typeof(EnumNodeType)))
            //{
            //    lstNode.Add(nt, new Node() { Type = nt });
            //}
            lstNode = new List<Node>();
            foreach (EnumNodeType nt in Enum.GetValues(typeof(EnumNodeType)))
            {
                lstNode.Add(new Node() { Type = nt });
            }

            lockData = new object();
        }

        //private Dictionary<EnumNodeType, Node> lstNode = null;
        private List<Node> lstNode = null;
        private object lockData = null;

        public Node this[EnumNodeType nodetype]
        {
            //get { return lstNode[nodetype]; }
            //set { lock (lockData) { lstNode[nodetype] = value; } }
            get 
            {
                lock (lockData)
                {
                    foreach (Node node in lstNode)
                    {
                        if (node.Type == nodetype) return node;
                    }
                }
                return null;
            }
            set
            {
                lock (lockData)
                {
                    for (int i = 0; i < lstNode.Count;i++ )
                    {
                        if (lstNode[i].Type == nodetype) lstNode[i] = value;
                    }
                }
            }
        }

        private Node this[int index]
        {
            get { return lstNode[index]; }
            set { lstNode[index] = value; }
        }

        public object Clone()
        {
            //SensorNodes sn = (SensorNodes)this.MemberwiseClone();
            SensorNodes sn = new SensorNodes();
            lock (lockData)
            {
                //foreach (EnumNodeType nt in lstNode.Keys)
                //{
                //    sn[nt] = (Node)lstNode[nt].Clone();
                //}
                for (int i = 0; i < lstNode.Count; i++)
                {
                    sn[i] = (Node)lstNode[i].Clone();
                }
            }
            return sn;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return lstNode.GetEnumerator();
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            lock(lockData)
            {
                //foreach (Node n in lstNode.Values)
                //{
                //    yield return n;
                //}
                foreach (Node n in lstNode)
                {
                    yield return n;
                }
            }
        }
    }

    /// <summary>
    /// 传感器基础信息
    /// </summary>
    class SensorModel:ICloneable
    {
        public SensorModel()
        {
            _nodesPrevious = new SensorNodes();
            _nodesRealTime = new SensorNodes();
            _nodesTemp = new SensorNodes();
        }

        

        /// <summary>
        /// 传感器ID
        /// </summary>
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 传感器编号
        /// </summary>
        private string _code = "";
        public string Code
        {
            get { return _code; }
            set { _code = value;}
        }

        private Worker.OPCPowerBaseData opcpowerData;
        public Worker.OPCPowerBaseData OPCPowerData
        {
            get{return opcpowerData ;}
            set{opcpowerData = value;}

        }

        /// <summary>
        /// 所属部门
        /// </summary>
        private int _deptid;
        public int DeptID
        {
            get{return _deptid;}
            set { _deptid = value; }
        }

        /// <summary>
        /// 所属区域
        /// </summary>
        private int _areaid;
        public int AreaID
        {
            get { return _areaid; }
            set { _areaid = value; }
        }

        /// <summary>
        /// 传感器类型
        /// </summary>
        private EnumSensorType _type= EnumSensorType.Unknow;
        public EnumSensorType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        ///<summary>数据节点值[当前]/// </summary>
        private SensorNodes _nodesTemp;
        public SensorNodes NodesTemp
        {
            get { return _nodesTemp; }
            set { _nodesTemp = value; }
        }

        ///<summary>数据节点值[当前]/// </summary>
        private SensorNodes _nodesRealTime;
        public SensorNodes NodesRealTime
        {
            get { return _nodesRealTime; }
            set { _nodesRealTime = value; }
        }

        ///<summary>数据节点值[之前]/// </summary>
        private SensorNodes _nodesPrevious;
        public SensorNodes NodesPrevious
        {
            get { return _nodesPrevious; }
            set { _nodesPrevious = value; }
        }

        ///<summary>判断数据是否已经更新过/// </summary>
        private bool _isupdated = false;
        public bool IsUpdated
        {
            get { return _isupdated; }
            set { _isupdated = value; }
        }

        public object Clone()
        {
            SensorModel sm = (SensorModel)this.MemberwiseClone();
            sm.NodesPrevious = (SensorNodes)this.NodesPrevious.Clone();
            sm.NodesRealTime = (SensorNodes)this.NodesRealTime.Clone();
            sm.NodesTemp = (SensorNodes)this.NodesTemp.Clone();
            return sm;
        }
    }
}
