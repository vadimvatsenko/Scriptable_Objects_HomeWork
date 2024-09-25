using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WoodFabric : WoodAbstractFubric
{
    private Dictionary<string, List<GameObject>> _prefabsDictionary = new Dictionary<string, List<GameObject>>();
    private GameObject _planeObj;

    private PlaneCoords _planeCoords;

    public WoodFabric(Dictionary<string, List<GameObject>> prefabsDictionary)
    {
        _prefabsDictionary = prefabsDictionary;
    }
    public override GameObject CreatePlane(GameObject parent, int count)
    {
        List<GameObject> prefabs = _prefabsDictionary["planes"];

        _planeObj = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        _planeObj.AddComponent<Plane>();
        _planeObj.transform.position = Vector3.zero;
        _planeCoords = _planeObj.GetComponent<Plane>()._planeCoords;
        _planeObj.transform.SetParent(parent.transform);

        return _planeObj;
    }

    public override List<GameObject> CreateGrass(GameObject parent, int count)
    {
        List<GameObject> objects =
            CreateObjects(_prefabsDictionary["listGrassAndFlowers"], Vector3.one, count, parent);

        return objects;
        
    }

    public override List<GameObject> CreateTrees(GameObject parent, int count)
    {
        List<GameObject> objects =
            CreateObjects(_prefabsDictionary["listTrees"], Vector3.one, count, parent);

        return objects;
    }

    public override List<GameObject> CreateRocks(GameObject parent, int count)
    {
        List<GameObject> objects =
            CreateObjects(_prefabsDictionary["listRocks"], Vector3.one, count, parent);

        return objects;
    }

    public override List<GameObject> CreateBuffs(GameObject parent, int count)
    {
        List<GameObject> objects =
            CreateObjects(_prefabsDictionary["listBuffs"], Vector3.one / 3, count, parent);

     
        foreach (var obj in objects)
        {
            obj.AddComponent<BoxCollider>().isTrigger = true;
            obj.transform.position = 
                new Vector3(obj.transform.position.x, obj.transform.position.y + obj.GetComponent<BoxCollider>().size.y / 4, obj.transform.position.z);
           
        }

        return objects;
    }

    private List<GameObject> CreateObjects(List<GameObject> prefabs, Vector3 scale, int count, GameObject parent)
    {
        List<GameObject> prefabsList = prefabs;
        List<GameObject> objects = new List<GameObject>();

        for (int i = 0; i <= count; i++)
        {
            float randomX = Random.Range(_planeCoords.minX, _planeCoords.maxX);
            float randomZ = Random.Range(_planeCoords.minZ, _planeCoords.maxZ);

            Ray ray = new Ray(new Vector3(randomX, _planeCoords.maxY + 10.0f, randomZ), Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                int randomIndex = Random.Range(0, prefabsList.Count);

                GameObject obj = GameObject.Instantiate(prefabsList[randomIndex], hit.point, Quaternion.identity, parent.transform);
                obj.transform.localScale = scale;
                objects.Add(obj);
            }
        }
        return objects;
    }

    









    /*public override List<GameObject> CreateRocks()
    {
        List<GameObject> rocksList = new List<GameObject>();

        List<GameObject> listPrefabs = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Rock_Boulder_A1_01"),
            Resources.Load<GameObject>("Prefabs/Wood/LPW_Rock_Wall_A1_01"),
            
        };

        for (int i = 0; i < 50; i++)
        {
            float randomX = Random.Range(_planeCoords.minX, _planeCoords.maxX);
            float randomZ = Random.Range(_planeCoords.minZ, _planeCoords.maxZ);

            Ray ray = new Ray(new Vector3(randomX, _planeCoords.maxY + 10.0f, randomZ), Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Если нашли поверхность, создаем траву на этой точке
                GameObject rockObj = GameObject.Instantiate(listPrefabs[Random.Range(0, listPrefabs.Count)]);
                rockObj.transform.position = hit.point;
                rocksList.Add(rockObj);
            }
        }

        return rocksList;
    }

    public override List<GameObject> CreateBuffs()
    {
        List<GameObject> buffsList = new List<GameObject>();

        List<GameObject> listPrefabs = new List<GameObject>()
        {
            Resources.Load<GameObject>("Prefabs/Buffs/Coin_Up"),
            Resources.Load<GameObject>("Prefabs/Buffs/Heal_Up"),
            Resources.Load<GameObject>("Prefabs/Buffs/Power_Up"),
            Resources.Load<GameObject>("Prefabs/Buffs/Star_Up"),
        };

        for (int i = 0; i < 20; i++)
        {
            float randomX = Random.Range(_planeCoords.minX, _planeCoords.maxX);
            float randomZ = Random.Range(_planeCoords.minZ, _planeCoords.maxZ);

            Ray ray = new Ray(new Vector3(randomX, _planeCoords.maxY + 10.0f, randomZ), Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Если нашли поверхность, создаем траву на этой точке
                GameObject buffsObj = GameObject.Instantiate(listPrefabs[Random.Range(0, listPrefabs.Count)]);
                buffsObj.transform.position = new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z);
                buffsObj.transform.localScale = Vector3.one * 0.3f;
                BoxCollider buffsCollider = buffsObj.AddComponent<BoxCollider>();
                buffsCollider.isTrigger = true;

                listPrefabs.Add(buffsObj);
            }
        }

        return buffsList;
    }*/
}
