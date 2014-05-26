using Soho.Utility;
using Soho.Utility.Encryption;

using SohoWeb.Entity;
using SohoWeb.Entity.ControlPanel;
using SohoWeb.DataAccess.ControlPanel;

namespace SohoWeb.Service.ControlPanel
{
    public class RolesMgtService : BaseService<RolesMgtService>
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="entity">角色信息</param>
        /// <returns></returns>
        public int InsertRoles(Roles entity)
        {
            var existsList = RolesMgtDA.GetValidRolesByRoleName(entity.RoleName);
            if (existsList != null && existsList.Count > 0)
            {
                throw new BusinessException("该角色名已存在！");
            }
            return RolesMgtDA.InsertRoles(entity);
        }

        /// <summary>
        /// 根据角色编号更新角色信息
        /// </summary>
        /// <param name="entity">角色信息</param>
        public void UpdateRolesBySysNo(Roles entity)
        {
            var existsList = RolesMgtDA.GetValidRolesByRoleName(entity.RoleName);
            if (existsList != null && existsList.Count > 0 && existsList[0].SysNo != entity.SysNo)
            {
                throw new BusinessException("该角色名已存在！");
            }
            RolesMgtDA.UpdateRolesBySysNo(entity);
        }

        /// <summary>
        /// 更新角色状态
        /// </summary>
        /// <param name="entity">角色信息</param>
        public void UpdateRolesStatusBySysNo(Roles entity)
        {
            RolesMgtDA.UpdateRolesStatusBySysNo(entity);
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<Roles> QueryRoles(RolesQueryFilter filter)
        {
            return RolesMgtDA.QueryRoles(filter);
        }

        /// <summary>
        /// 根据角色编号获取有效角色
        /// </summary>
        /// <param name="functionKey">角色编号</param>
        /// <returns></returns>
        public Roles GetValidRolesBySysNo(int sysNo)
        {
            return RolesMgtDA.GetValidRolesBySysNo(sysNo);
        }
    }
}
