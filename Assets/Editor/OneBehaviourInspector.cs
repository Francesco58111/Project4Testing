using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;

[CanEditMultipleObjects]
//[CustomEditor(typeof(OneBehaviour))]
public class OneBehaviourInspector : Editor
{

    OneBehaviour targetedBehaviour;
    OneBehaviour[] targetBehaviours;

    void OnEnable()
    {
        targetedBehaviour = target as OneBehaviour;
        targetBehaviours = new OneBehaviour[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            targetBehaviours[i] = targets[i] as OneBehaviour;
        }

        Undo.undoRedoPerformed += MyUndoCallback;
    }


    void OnDisable()
    {
        Undo.undoRedoPerformed -= MyUndoCallback;
    }

    private void MyUndoCallback()
    {
        Debug.Log("Something");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        
        Undo.RecordObjects(targetBehaviours, "Edited Something");

        EditorGUI.BeginChangeCheck();

        //On dessine/design notre inspector
        GUILayout.Space(5);

        EditorGUILayout.LabelField("One Behaviour parameters", EditorStyles.boldLabel);
        float newLife = EditorGUILayout.FloatField("Life", targetedBehaviour.life);
        

        GUILayout.Space(EditorGUIUtility.singleLineHeight*2);

        EditorGUILayout.LabelField("One Behaviour parameters", EditorStyles.boldLabel);
        targetedBehaviour.life = EditorGUILayout.FloatField("Life", targetedBehaviour.life);


        Color defaultColor = GUI.color;
        GUI.color = Color.green;

        EditorGUILayout.BeginHorizontal("box");
        
        GUI.color = Color.red;

        EditorGUILayout.BeginVertical("box");
        GUI.color = defaultColor;


        if (GUILayout.Button("Click here"))
        {
            Undo.DestroyObjectImmediate(targetedBehaviour.gameObject);
        }

        //Désactive un groupe en fonction d'une condition
        EditorGUI.BeginDisabledGroup(targetedBehaviour.transform.position.x < 0);


        if (GUILayout.Button("Click here"))
        {
            //Détruit un objet en Editor et enregistre la modification en UNDO
            Undo.DestroyObjectImmediate(targetedBehaviour.gameObject);
        }

        if(targetedBehaviour is object)
        {
            GUILayout.Label(("It works"));
        }

        if (GUILayout.Button("Click here"))
        {
            Undo.DestroyObjectImmediate(targetedBehaviour.gameObject);
        }

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.EndVertical();


        if (GUILayout.Button("Click here", GUILayout.MinHeight(EditorGUIUtility.singleLineHeight * 3)))
        {
            Undo.DestroyObjectImmediate(targetedBehaviour.gameObject);
        }

        EditorGUILayout.EndHorizontal();



        if (EditorGUI.EndChangeCheck())
        {
            for (int i = 0; i < targetBehaviours.Length; i++)
            {
                targetBehaviours[i].life = newLife;
            }

            //On sauvegarde
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

    }
}
