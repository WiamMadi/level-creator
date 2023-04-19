using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Level", menuName = "Level Creator/Level", order = 1)]
public class Level : ScriptableObject
{
    public object id;

    public string name;

    public List<Requirement> requirements;

    public List<Checkpoint> checkpoints;


}