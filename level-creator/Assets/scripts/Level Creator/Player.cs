using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private List<Guid> levels = new List<Guid>();
    private PermissionAttachment attachment;

    public Player()
    {
        // Load data
    }

    public PermissionAttachment GetAttachment()
    {
        return attachment;
    }
}
