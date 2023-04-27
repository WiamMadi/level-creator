using System;
using System.Collections.Generic;

public class PermissionAttachment
{
    private List<Permission> permissionList;

    public PermissionAttachment(List<Permission> permissionList)
    {
        this.permissionList = permissionList ?? new List<Permission>();
    }

    public void AddPermission(params Permission[] permissions)
    {
        foreach (Permission permission in permissions)
        {
            if (permissionList.Contains(permission)) return;

            permissionList.Add(permission);
        }
    }

    public void RemovePermission(params Permission[] permissions)
    {
        foreach (Permission permission in permissions)
        {
            if (!permissionList.Contains(permission)) return;

            permissionList.Remove(permission);
        }
    }

    public bool HasPermission(Permission permission)
    {
        return permissionList.Contains(permission);
    }

    public String GetPermissions()
    {
        return string.Join(Environment.NewLine, permissionList);
    }

    public List<Permission> GetPermissionList()
    {
        return permissionList;
    }
}
