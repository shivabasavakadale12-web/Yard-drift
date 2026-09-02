using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{

    public int levelNumber;

    public float timeLimit;

    public int targetTriangles;

    public int maxHits;

    public float triangleSpawnChance;

    public float obstacleSpawnChance;

    public float spawnInterval;

    public float spawnRadius;
}
