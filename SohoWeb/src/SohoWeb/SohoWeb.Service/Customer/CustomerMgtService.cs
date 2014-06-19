using System.Collections.Generic;

using SohoWeb.DataAccess.Customer;
using SohoWeb.Entity.Customer;

namespace SohoWeb.Service.Customer
{
    public class CustomerMgtService : BaseService<CustomerMgtService>
    {
        /// <summary>
        /// 添加用户基础信息
        /// </summary>
        /// <param name="entity">用户信息</param>
        /// <returns></returns>
        public int InsertCustomerBase(CustomerInfo entity)
        {
            int customerSysNo = CustomerMgtDA.InsertCustomerBase(entity);

            return customerSysNo;
        }

        /// <summary>
        /// 根据用户编号更新用户基础信息
        /// </summary>
        /// <param name="entity">用户信息</param>
        public void UpdateCustomerBaseBySysNo(CustomerInfo entity)
        {
            CustomerMgtDA.UpdateCustomerBaseBySysNo(entity);
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="entity">用户信息</param>
        public void UpdateCustomerStatusBySysNo(CustomerInfo entity)
        {
            CustomerMgtDA.UpdateCustomerStatusBySysNo(entity);
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="entity">用户信息</param>
        public void UpdateCustomerPasswordByUserID(CustomerInfo entity)
        {
            CustomerMgtDA.UpdateCustomerPasswordByUserID(entity);
        }

        /// <summary>
        /// 根据用户ID获取有效用户
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public CustomerInfo GetValidCustomerByCustomerID(string customerID)
        {
            return CustomerMgtDA.GetValidCustomerByCustomerID(customerID);
        }
        public List<CustomerInfo> GetValidCustomerListByCustomerID(string customerID)
        {
            return CustomerMgtDA.GetValidCustomerListByCustomerID(customerID);
        }

        /// <summary>
        /// 根据用户编号获取有效用户
        /// </summary>
        /// <param name="customerSysNo">用户编号</param>
        /// <returns></returns>
        public CustomerInfo GetValidCustomerByCustomerSysNo(int customerSysNo)
        {
            return CustomerMgtDA.GetValidCustomerByCustomerSysNo(customerSysNo);
        }
    }
}
