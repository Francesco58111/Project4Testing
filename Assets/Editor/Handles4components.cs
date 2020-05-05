using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(WithHandles))]
public class Handles4components : Editor
{

    WithHandles handles;

    private void OnEnable()
    {
        handles = target as WithHandles;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }


    private void OnSceneGUI()
    {
        #region old
        /*
        Handles.color = Color.red;
        Handles.DrawLine(handles.transform.position, Vector3.zero);

        Handles.color = Color.green;
        Handles.DrawWireDisc(handles.transform.position, Vector3.up, handles.range);


        float size = HandleUtility.GetHandleSize(handles.transform.position) * 1.2f;
        Vector3 snap = Vector3.one * 0.5f;

        handles.position = Handles.FreeMoveHandle(handles.position, Quaternion.identity, size, Vector3.zero, Handles.SphereHandleCap);

        handles.range = Handles.ScaleValueHandle(handles.range, handles.transform.position, handles.transform.rotation, size, Handles.ConeHandleCap, 0f);
        */
        #endregion


        Handles.color = Color.yellow;
        if(handles.path != null)
        {
            if(handles.path.Length > 0)
            {
                for (int i = 0; i < handles.path.Length; i++)
                {
                    handles.path[i] = Handles.FreeMoveHandle(handles.path[i], 
                        Quaternion.identity, 
                        HandleUtility.GetHandleSize(handles.position) * 0.2f,
                        Vector3.one * 0.1f, Handles.CubeHandleCap);
                }

                Handles.DrawPolyLine(handles.path);
            }
        }


        Handles.BeginGUI();

        if(GUILayout.Button("Reset Position", GUILayout.MaxWidth(100)))
        {
            handles.transform.position = Vector3.zero;
        }


        Handles.EndGUI();


        float hitBoxSize = HandleUtility.GetHandleSize(handles.transform.position);

        if (Handles.Button(handles.transform.position + Vector3.up * 2f, Quaternion.identity, hitBoxSize, hitBoxSize, Handles.SphereHandleCap))
        {
            Debug.Log("Hello");
        }
    }


}
