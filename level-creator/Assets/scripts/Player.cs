using UnityEngine;

public class Player : PermissionAttachment
{
    private void Awake()
    {
        AddPermissions();

        Debug.Log(GetPermissions());
    }

    public void AddPermissions()
    {
        AddPermission(Permission.PERMISSION_ONE, Permission.PERMISSION_TWO, Permission.PERMISSION_THREE);
    }
}
