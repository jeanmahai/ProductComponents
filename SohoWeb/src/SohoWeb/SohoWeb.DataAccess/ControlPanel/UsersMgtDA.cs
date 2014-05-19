using System;
using System.Data;
using System.Collections.Generic;

using SohoWeb.Entity;
using SohoWeb.Entity.ControlPanel;
using Soho.Utility.DataAccess;

namespace SohoWeb.DataAccess.ControlPanel
{
    public class UsersMgtDA
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户信息</param>
        /// <returns></returns>
        public static int InsertUser(Users entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("InsertUser");
            cmd.SetParameterValue<Users>(entity);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.GetParameterValue("@SysNo"));
        }

        /// <summary>
        /// 根据用户编号更新用户信息
        /// </summary>
        /// <param name="entity">用户信息</param>
        public static void UpdateUserBySysNo(Users entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateUserBySysNo");
            cmd.SetParameterValue<Users>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="entity">用户信息</param>
        public static void UpdateUserStatusBySysNo(Users entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateUserStatusBySysNo");
            cmd.SetParameterValue<Users>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="entity">用户信息</param>
        public static void UpdateUserPasswordByUserID(Users entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateUserPasswordByUserID");
            cmd.SetParameterValue<Users>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<Users> QueryUsers(UsersQueryFilter filter)
        {
            QueryResult<Users> result = new QueryResult<Users>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = new PagingInfoEntity();
            page.MaximumRows = filter.PageSize;
            page.StartRowIndex = filter.ServicePageIndex * filter.PageSize;
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryUsers");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                if (filter.SysNo.HasValue)
                {
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "SysNo", DbType.Int32,
                        "@SysNo", QueryConditionOperatorType.Equal, filter.SysNo.Value);
                }
                if (!string.IsNullOrWhiteSpace(filter.UserID))
                {
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "UserID", DbType.String,
                        "@UserID", QueryConditionOperatorType.Like, filter.UserID);
                }
                if (!string.IsNullOrWhiteSpace(filter.UserName))
                {
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "UserName", DbType.String,
                        "@UserName", QueryConditionOperatorType.Like, filter.UserName);
                }
                if (filter.Status.HasValue)
                {
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32,
                        "@Status", QueryConditionOperatorType.Equal, filter.Status.Value);
                }

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.ResultList = cmd.ExecuteEntityList<Users>();
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 根据用户ID获取有效用户
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static Users GetValidUserByUserID(string userID)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetValidUserByUserID");
            cmd.SetParameterValue("@UserID", userID);
            return cmd.ExecuteEntity<Users>();
        }
        public static List<Users> GetValidUserListByUserID(string userID)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetValidUserByUserID");
            cmd.SetParameterValue("@UserID", userID);
            return cmd.ExecuteEntityList<Users>();
        }

        /// <summary>
        /// 根据用户编号获取有效用户
        /// </summary>
        /// <param name="userSysNo">用户编号</param>
        /// <returns></returns>
        public static Users GetValidUserByUserSysNo(int userSysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetValidUserByUserSysNo");
            cmd.SetParameterValue("@SysNo", userSysNo);
            return cmd.ExecuteEntity<Users>();
        }
    }
}
