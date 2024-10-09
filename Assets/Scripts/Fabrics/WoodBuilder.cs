using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class WoodBuilder : MonoBehaviour
{
    private MapPresets _preset;
    private WoodFabric _woodFabric;
    private List<GameObject> _parentsList = new List<GameObject>();
    private Dictionary<string, List<GameObject>> _prefabsList = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        _preset = Resources.Load<MapPresets>("ScriptableObjects/MapPresets/MapPreset");

        LoadPrefabs();
        _parentsList = CreateFolderHierarchy();
        _woodFabric = new WoodFabric(_prefabsList);

        _woodFabric.CreatePlane(_parentsList[0], 1);
        _woodFabric.CreateGrass(_parentsList[2], _preset._grass);
        _woodFabric.CreateTrees(_parentsList[4], _preset._trees);
        _woodFabric.CreateRocks(_parentsList[1], _preset._rocks);
        _woodFabric.CreateBuffs(_parentsList[3], 20);
    }

    private void LoadPrefabs()
    {
        List<GameObject> planes = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Ground_A1_100x100_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Ground_A1_100x100_02")
        };
        List<GameObject> listGrassAndFlowers = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Grass_A1_40cm_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Grass_A1_50cm_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Flower_A1_H70cm_01"),
        };

        List<GameObject> listTrees = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Tree_A1_6.5m_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Tree_B1_9m_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Tree_B1_9m_02"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Tree_C1_9m_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Tree_C1_11m_01"),
        };

        List<GameObject> listRocks = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Rock_Boulder_A1_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Rock_Wall_A1_01"),
        };

        List<GameObject> listBuffs = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Buffs/Coin_Up"),
            Resources.Load<GameObject>("Prefabs/Buffs/Heal_Up"),
            Resources.Load<GameObject>("Prefabs/Buffs/Power_Up"),
            Resources.Load<GameObject>("Prefabs/Buffs/Star_Up"),
        };

        _prefabsList.Add("planes", planes);
        _prefabsList.Add("listGrassAndFlowers", listGrassAndFlowers);
        _prefabsList.Add("listTrees", listTrees);
        _prefabsList.Add("listRocks", listRocks);
        _prefabsList.Add("listBuffs", listBuffs);
    }

    private List<GameObject> CreateFolderHierarchy()
    {
        GameObject woodParent = new GameObject("WoodHolder");
        GameObject rockParent = new GameObject("Rocks");
        GameObject grassParent = new GameObject("Grass");
        GameObject buffsParent = new GameObject("Buffs");
        GameObject treesParent = new GameObject("Trees");

        rockParent.transform.parent = woodParent.transform;
        grassParent.transform.parent = woodParent.transform;
        buffsParent.transform.parent = woodParent.transform;
        treesParent.transform.parent = woodParent.transform;

        List<GameObject> hierarchyGameObjetsList = new List<GameObject>()
        {
            woodParent, rockParent, grassParent, buffsParent, treesParent
        };

        return hierarchyGameObjetsList;
    }
}
