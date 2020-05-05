using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


public class FirstTool
{
    [MenuItem("Component/My First Tool %w", false, 10)]

    public static void MyFirstMessage()
    {
        GameObject[] all = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];

        foreach(GameObject go in all)
        {

        }

        //EditorSceneManager.MarkAllScenesDirty();
        //EditorSceneManager.MarkSceneDirty(all[0].scene);
    }

    [MenuItem("Assets/Create/custom Material", false, 5)]

    public static void MyAssetTool()
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.SetColor("_Color", Color.red);

        string path = "Assets/Materials";

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets", "Materials");
        }

        AssetDatabase.CreateAsset(mat, path + "/My new Material.mat");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Selection.activeObject = mat;


        EditorGUIUtility.PingObject(mat);
    }
}
