using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "Level Creator/Level Manager", order = 2)]
public class LevelManager : ScriptableObject
{
    public List<Level> levels;

    public Level GetLevel(string id)
    {
        return levels.Find(level => level.Id == id);
    }

    public List<Level> GetLevels()
    {
        return levels;
    }
}
