using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleTransportClient.Tools
{

    /// <summary>命令结果类</summary>
    public class CommandResult
    {
        public class OperateArgs
        {
            public bool IsResponse { get; set; }

            public bool IsSuccess { get; set; }
        }

        private Dictionary<int, OperateArgs> _dicCmdList = new Dictionary<int, OperateArgs>();

        /// <summary>
        /// 执行命令前加
        /// </summary>
        /// <param name="hashCode"></param>
        public void AddCommand(int hashCode)
        {
            if (_dicCmdList.ContainsKey(hashCode) == false)
            {
                _dicCmdList.Add(hashCode, new OperateArgs() { IsResponse = false, IsSuccess = false });
            }
        }

        /// <summary>
        /// 收到返回里使用
        /// </summary>
        /// <param name="hashCode"></param>
        /// <param name="execResult"></param>
        public void DoCommandResult(int hashCode, bool execResult)
        {
            if (_dicCmdList.ContainsKey(hashCode) == true)
            {
                _dicCmdList[hashCode] = new OperateArgs()
                {
                    IsResponse = true,
                    IsSuccess = execResult
                };
            }
        }

        /// <summary>
        /// 取响应结果
        /// </summary>
        /// <param name="hashCode"></param>
        /// <returns></returns>
        public bool GetResponseResult(int hashCode)
        {
            return _dicCmdList[hashCode].IsResponse;
        }

        /// <summary>
        /// 取执行结果
        /// </summary>
        /// <param name="hashCode"></param>
        /// <returns></returns>
        public bool GetExecResult(int hashCode)
        {
            bool b = _dicCmdList[hashCode].IsSuccess;
            _dicCmdList.Remove(hashCode);
            return b;
        }

    }
}
