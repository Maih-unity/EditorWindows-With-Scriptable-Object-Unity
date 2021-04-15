using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GetAllHeros : MonoBehaviour
{
    private ScriptableObj[] heros;
    // Start is called before the first frame update
    void Start()
    {
        heros = GetAllInstances<ScriptableObj>();
        foreach (ScriptableObj item in heros)
        {
            Debug.Log(item.Dmg);
           
        }
    }


    public static T[] GetAllInstances<T>() where T : ScriptableObj
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
