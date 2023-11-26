using UnityEngine;
using UnityEditor;


public class HerosEditorWindows : EditorWindow
{

    protected SerializedObject serializedObject;
    protected SerializedProperty serializedProperty;

    protected ScriptableObj[] heros;
    protected string selectedPropertyPach;
    protected string selectedProperty;
    protected string selectedHeroDetail;

    [MenuItem("Window/GameData/Heros")]
    protected static void ShowWindow()
    {
        GetWindow<HerosEditorWindows>("Heros");
    }

    private void OnGUI()
    {
        heros = GetAllInstances<ScriptableObj>();
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

        DrawSliderBar(heros);

        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));

        if (selectedProperty!=null)
        { 
            for (int i = 0; i < heros.Length; i++)
            {
                if (heros[i].HerosName == selectedProperty)
                {
                    serializedObject = new SerializedObject(heros[i]);
                    serializedProperty = serializedObject.GetIterator();
                    serializedProperty.NextVisible(true);
                    DrawProperties(serializedProperty);
                }
            }
        }
        else
        {
            EditorGUILayout.LabelField("select an item from the lsit");
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();


        Apply();
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





    protected void DrawProperties(SerializedProperty p)
    {

        while (p.NextVisible(false))
        {
            EditorGUILayout.PropertyField(p, true);
        }

        
    }



    protected void DrawSliderBar(ScriptableObj[] prop)
    {
        foreach (ScriptableObj p in prop)
        {
            if (GUILayout.Button(p.HerosName))
            {
                selectedProperty = p.HerosName;
            }
        }


        if (GUILayout.Button("new hero"))
        {
            ScriptableObj newHero = ScriptableObject.CreateInstance<ScriptableObj>();
            CreateHeroWindow newHeroWindow = GetWindow<CreateHeroWindow>("New Hero");
            newHeroWindow.newHero = newHero;

        }
    }


    protected void Apply()
    {
        if (serializedObject != null)
        {
            serializedObject.ApplyModifiedProperties();
            selectedProperty = serializedObject.FindProperty("herosName").stringValue;
        }

    }

}
