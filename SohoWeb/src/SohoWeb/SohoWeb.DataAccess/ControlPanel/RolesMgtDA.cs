using System;
using System.Data;
using System.Collections.Generic;

using SohoWeb.Entity;
using SohoWeb.Entity.ControlPanel;
using Soho.Utility.DataAccess;

namespace SohoWeb.DataAccess.ControlPanel
{
    public class RolesMgtDA
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="entity">角色信息</param>
        /// <returns></returns>
        public static int InsertRoles(Roles entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("InsertRoles");
            cmd.SetParameterValue<Roles>(entity);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.GetParameterValue("@SysNo"));
        }

        /// <summary>
        /// 根据角色编号更新角色信息
        /// </summary>
        /// <param name="entity">角色信息</param>
        public static void UpdateRolesBySysNo(Roles entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateRolesBySysNo");
            cmd.SetParameterValue<Roles>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 更新角色状态
        /// </summary>
        /// <param name="entity">角色信息</param>
        public static void UpdateRolesStatusBySysNo(Roles entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateRolesStatusBySysNo");
            cmd.SetParameterValue<Roles>(entity);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static QueryResult<Roles> QueryRoles(RolesQueryFilter filter)
        {
            QueryResult<Roles> result = new QueryResult<Roles>();
            result.ServicePageIndex = filter.ServicePageIndex;
            result.PageSize = filter.PageSize;

            PagingInfoEntity page = DataAccessUtil.ToPagingInfo(filter);
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("QueryRoles");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "SysNo", DbType.Int32,
                    "@SysNo", QueryConditionOperatorType.Equal, filter.SysNo);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "RoleName", DbType.String,
                    "@RoleName", QueryConditionOperatorType.Like, filter.RoleName);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32,
                    "@Status", QueryConditionOperatorType.Equal, filter.Status);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.ResultList = cmd.ExecuteEntityList<Roles>();
                result.TotalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));

                return result;
            }
        }

        /// <summary>
        /// 根据角色编号获取有效角色
        /// </summary>
        /// <param name="functionKey">角色编号</param>
        /// <returns></returns>
        public static Roles GetValidRolesBySysNo(int sysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetValidRolesBySysNo");
            cmd.SetParameterValue("@SysNo", sysNo);
            return cmd.ExecuteEntity<Roles>();
        }

        /// <summary>
        /// 根据角色名称获取有效角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        public static List<Roles> GetValidRolesByRoleName(string roleName)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetValidRolesByRoleName");
            cmd.SetParameterValue("@RoleName", roleName);
            return cmd.ExecuteEntityList<Roles>();
        }
    }
}
