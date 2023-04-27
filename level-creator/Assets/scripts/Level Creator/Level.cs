using UnityEngine;

using System;
using System.Collections.Generic;

/*
 * This is just a simple setup to get things started.
 * 
 * You can always add more values to levels such as:
 *   - XP Reward
 *   - Money Rewards
 *   - Collection amounts (e.g. stars)
 **/
[CreateAssetMenu(fileName = "Level", menuName = "Level Creator/Level", order = 1)]
public class Level : ScriptableObject
{
    // Uniquie level ID
    private string id = Guid.NewGuid().ToString();

    [Space]
    // Reference scene for the level
    [SerializeField] private Scene scene;

    [Space]
    // List of requirements needed to access this level
    [SerializeField] private List<Permission> requirements;

    public string Id
    {
        get
        {
            return id;
        }
    }

    public Scene Scene
    {
        get
        {
            return scene;
        }
    }

    public List<Permission> Requirements
    {
        get
        {
            return requirements;
        }
    }
}
