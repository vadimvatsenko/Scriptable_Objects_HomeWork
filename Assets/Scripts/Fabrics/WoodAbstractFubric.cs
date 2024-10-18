using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WoodAbstractFubric
{
    public abstract GameObject CreatePlane(GameObject parent, int count);
    public abstract List<GameObject> CreateGrass(GameObject parent, int count);
    public abstract List<GameObject> CreateTrees(GameObject parent, int count);
    public abstract List<GameObject> CreateRocks(GameObject parent, int count);
    public abstract List<GameObject> CreateBuffs(GameObject parent, int count);
}
