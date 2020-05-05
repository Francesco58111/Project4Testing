using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(BehaviourStats))]
public class BehaviourDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        float numberOfLines = 2;

        return lineHeight * numberOfLines;
    }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float lineHeight = EditorGUIUtility.singleLineHeight +EditorGUIUtility.standardVerticalSpacing;

        float spaceBetween = 10f;
        float rectWidth = (position.width - spaceBetween) * 0.5f;

        Rect somethingRect = new Rect(position.x, position.y, rectWidth, lineHeight);
        Rect otherRect = new Rect(position.x + spaceBetween + somethingRect.width, position.y, rectWidth, lineHeight);
        Rect moreRect = new Rect(position.x, position.y + somethingRect.height + EditorGUIUtility.standardVerticalSpacing, position.width, lineHeight);


        float oldWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth *= 0.5f;


        SerializedProperty somethingProperty = property.FindPropertyRelative("something");
        EditorGUI.PropertyField(somethingRect, somethingProperty, new GUIContent("something", "our behaviour struc something"));

        SerializedProperty otherProperty = property.FindPropertyRelative("otherThing");
        EditorGUI.PropertyField(otherRect, otherProperty, new GUIContent("otherThing", "our behaviour struc otherThing"));

        SerializedProperty moreProperty = property.FindPropertyRelative("animCurve");
        EditorGUI.PropertyField(moreRect, moreProperty, new GUIContent("animCurve", "our behaviour struc more"));


        //EditorGUI.FloatField(somethingRect, "a", somethingProperty.floatValue);
    }
}
