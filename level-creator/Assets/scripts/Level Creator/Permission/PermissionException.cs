using System;

public class PermissionException : Exception
{
    public PermissionAction PermissionAction { get; }

    public PermissionException() { }

    public PermissionException(string message)
        : base(message) { }

    public PermissionException(string message, Exception inner)
        : base(message, inner) { }

    public PermissionException(string message, PermissionAction permissionAction)
        : this(message)
    {
        PermissionAction = permissionAction;
    }
}

public enum PermissionAction
{
    ADD,
    REMOVE,
    GET
}