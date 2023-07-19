using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompendiumContainer : MonoBehaviour{

    [SerializeField] private TestPrefabHolder[] prefabsRaw;
    private static Dictionary<string,GameObject>prefabs = new Dictionary<string,GameObject>();

    void Start(){
        for(int i = 0; i < prefabsRaw.Length; i++){
            for(int j = 0; j < prefabsRaw[i].preFabs.Length; j++){
                prefabs.Add(prefabsRaw[i].preFabs[j].name, (prefabsRaw[i].preFabs[j]));
            }
        }
    }

    public GameObject GetPrefab(string name){
        if(prefabs.ContainsKey(name)) return prefabs[name];
        UnityEngine.Debug.Log("Big bad at CContainar");
        return null;
    }
}

