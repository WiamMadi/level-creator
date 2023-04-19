using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Requirement", menuName = "Level Creator/Requirement", order = 3)]
public class Requirement : ScriptableObject
{
    public RequirementType type;

    private void Awake()
    {
    }
}
