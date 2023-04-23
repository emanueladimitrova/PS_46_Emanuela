using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public static class RightsGranted
    {
        public static IDictionary<UserRoles, RoleRights[]> userRoleRights
        {
            get{
                IDictionary<UserRoles, RoleRights[]> _userRoleRights = new Dictionary<UserRoles, RoleRights[]>();
                _userRoleRights.Add(UserRoles.ADMIN, new RoleRights[] {RoleRights.EDIT_USERS, RoleRights.READ_LOGS, RoleRights.READ_USERS});
                _userRoleRights.Add(UserRoles.ANONYMOUS, new RoleRights[] { RoleRights.READ_LOGS});
                _userRoleRights.Add(UserRoles.INSPECTOR, new RoleRights[] { RoleRights.READ_LOGS, RoleRights.READ_USERS });
                _userRoleRights.Add(UserRoles.PROFESSOR, new RoleRights[] { RoleRights.EDIT_USERS, RoleRights.READ_USERS});
                _userRoleRights.Add(UserRoles.STUDENT, new RoleRights[] { RoleRights.READ_LOGS });

                return _userRoleRights;

            }
            set {}
        }
    }
}
