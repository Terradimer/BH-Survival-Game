using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompendiumContainer : MonoBehaviour{

    [SerializeField] private GameObject[] prefabsRaw;
    [SerializeField] private Sprite[] spritesRaw;

    private static Dictionary<string,GameObject>prefabs = new Dictionary<string,GameObject>();
    private static Dictionary<string,Sprite>sprites = new Dictionary<string,Sprite>();
    void Start(){
        for(int i = 0; i < prefabsRaw.Length; i++){
            prefabs.Add(prefabsRaw[i].name, (prefabsRaw[i]));
        }
        for(int i = 0; i < spritesRaw.Length; i++){
            sprites.Add(spritesRaw[i].name, (spritesRaw[i]));
        }
    }

    public GameObject GetPrefab(string name){
        if(prefabs.ContainsKey(name)) return prefabs[name];
        UnityEngine.Debug.Log("Big bad at CContainar(PreFab)");
        return null;
    }
    public Sprite GetSprite(string name){
        if(sprites.ContainsKey(name)) return sprites[name];
        UnityEngine.Debug.Log("Big bad at CContainar(Sprite)");
        return null;
    }
}

