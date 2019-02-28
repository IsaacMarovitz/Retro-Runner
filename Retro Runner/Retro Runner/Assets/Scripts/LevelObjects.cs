using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/List", order = 1)]
public class LevelObjects : ScriptableObject {
    public string levelName;
    public Texture2D map;
}
