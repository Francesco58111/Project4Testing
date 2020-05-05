using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(OneBehaviour))]
public class AnotherTool : Editor
{

    SerializedProperty lifeProperty;
    SerializedProperty arrayProperty;
    SerializedProperty structSerialized;
    SerializedProperty iteratorProperty;

    private void OnEnable()
    {
        lifeProperty = serializedObject.FindProperty("life");
        arrayProperty = serializedObject.FindProperty("arrayColor");
        structSerialized = serializedObject.FindProperty("myStats");

        iteratorProperty = serializedObject.GetIterator();
    }

    private void OnDisable()
    {

    }


    bool foldOut = false;



    public override void OnInspectorGUI()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        serializedObject.Update();

        #region HEY
        //lifeProperty.floatValue = EditorGUILayout.FloatField("Life", lifeProperty.floatValue);

        EditorGUILayout.PropertyField(lifeProperty);
        //EditorGUILayout.PropertyField(arrayProperty);


        //EditorGUILayout.PropertyField(structSerialized.FindPropertyRelative("something"));




        //EditorGUILayout.BeginVertical();

        arrayProperty.arraySize = EditorGUILayout.IntField("Size", arrayProperty.arraySize);

        if (arrayProperty.arraySize > 0)
        {
            foldOut = EditorGUILayout.Foldout(foldOut, "Fold", true);

            if (foldOut)
            {
                EditorGUI.indentLevel += 2;

                for (int i = 0; i < arrayProperty.arraySize; i++)
                {
                    SerializedProperty currentElement = arrayProperty.GetArrayElementAtIndex(i);
                    EditorGUILayout.PropertyField(currentElement);
                }

                EditorGUI.indentLevel -= 2;
            }

        }

        //EditorGUILayout.EndVertical();

        #endregion

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        #region ITERATOR
        /*
        iteratorProperty = serializedObject.GetIterator();

        iteratorProperty.Next(true);
        iteratorProperty.NextVisible(false);

        EditorGUILayout.PropertyField(iteratorProperty);
        iteratorProperty.NextVisible(false);

        SerializedProperty secondProperty = iteratorProperty.Copy();

        EditorGUILayout.PropertyField(iteratorProperty);
        iteratorProperty.NextVisible(true);

        EditorGUILayout.PropertyField(iteratorProperty);
        iteratorProperty.NextVisible(true);

        EditorGUILayout.PropertyField(iteratorProperty);
        iteratorProperty.NextVisible(true);

        EditorGUILayout.PropertyField(iteratorProperty);
        iteratorProperty.NextVisible(true);
        */
        #endregion

        EditorGUILayout.PropertyField(structSerialized);

        serializedObject.ApplyModifiedProperties();

        sw.Stop();
        EditorGUILayout.LabelField(sw.ElapsedTicks.ToString());

        //base.OnInspectorGUI();

    }
}
