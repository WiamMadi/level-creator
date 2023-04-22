using System.Collections.Generic;
using System;

using UnityEngine;

public abstract class PermissionAttachment : MonoBehaviour
{
    private List<Permission> permissionList = new List<Permission>();

    public PermissionAttachment()
    {
        //Load permissions
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
