using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddCollider : MonoBehaviour
{
    public List<GameObject> models;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var i in models)
        {
            int counts = i.transform.childCount;
            for (int j = 0; j < counts; j++)
            {
                GameObject a = i.transform.GetChild(j).gameObject;
                a.AddComponent<MeshCollider>();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
