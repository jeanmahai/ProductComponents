using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Soho.EmailAndSMS.Service.Entity
{
    /// <summary>
    /// 查询结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [DataContract]
    public class QueryResult<T> where T : class
    {
        /// <summary>
        /// 当前显示第几页数据
        /// </summary>
        [DataMember]
        public long PageIndex { get; set; }
        /// <summary>
        /// 每页显示几条数据
        /// </summary>
        [DataMember]
        public long PageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public long TotalCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public long PageCount
        {
            get
            {
                return TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;
            }
        }
        /// <summary>
        /// 当前页数据列表
        /// </summary>
        [DataMember]
        public List<T> ResultList { get; set; }
    }
}
