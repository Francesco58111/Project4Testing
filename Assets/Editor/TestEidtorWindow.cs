using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestEidtorWindow : EditorWindow
{

    public Vector2 windowPosition;
    TextAssetReader currentAsset;
    Editor currentAssetInspector;

    Vector2 scrollPosition;


    [MenuItem("Window/Custom/Thing")]
    public static void OpenThisWindow()
    {
        TestEidtorWindow myWindow = EditorWindow.GetWindow(typeof(TestEidtorWindow)) as TestEidtorWindow;

        myWindow.Init(null);
    }

    public Vector2 virtualPosition;
    

    public void Init(TextAssetReader newAsset)
    {
        //Initialize parameters
        minSize = new Vector2(300, 300);
        virtualPosition = Vector2.zero;

        currentAsset = newAsset;

        Show();
    }

    private void OnGUI()
    {
        

        EditorGUILayout.LabelField("X : ", virtualPosition.x.ToString());
        EditorGUILayout.LabelField("Y : ", virtualPosition.y.ToString());

        Rect rect = EditorGUILayout.GetControlRect(false, 32);
        EditorGUI.DrawRect(rect, Color.green);


        KeyboardControls();

        scrollPosition = GUILayout.BeginScrollView(
            scrollPosition, GUILayout.Width(300), GUILayout.Height(minSize.y));

        if (currentAsset != null)
        {
            if(currentAssetInspector == null)
            {
                Editor.CreateCachedEditor(currentAsset, typeof(TextAssetReaderInspector), ref currentAssetInspector);
            }

            currentAssetInspector.OnInspectorGUI();
        }

        GUILayout.EndScrollView();





        if(GUILayout.Button("Right Click"))
        {
            if(Event.current.button == 1)
            {
                GenerateMenu();
            }
        }

    }


    void GenerateMenu()
    {
        Debug.Log("YES");


        GenericMenu myMenu = new GenericMenu();

        myMenu.AddItem(new GUIContent("Ennemies/BasicOne"), false, SelectPreciseOption, 1);
        myMenu.AddItem(new GUIContent("Ennemies/MediumOne"), false, SelectPreciseOption, 20);
        myMenu.AddItem(new GUIContent("Ennemies/HardOne"), false, SelectPreciseOption, "Well");
        myMenu.AddItem(new GUIContent("Ennemies/Boss"), false, SelectAnOption);


        myMenu.ShowAsContext();
    }


    void SelectAnOption()
    {
        Debug.Log("OKAY");
    }

    void SelectPreciseOption(object choice)
    {
        Debug.Log("You've selected this  " + choice);
    }

    void KeyboardControls()
    {
        if (Event.current.type != EventType.KeyDown)
        {
            return;
        }

        bool wrongKey = false;

        if (Event.current.keyCode == KeyCode.S) virtualPosition.y--;
        if (Event.current.keyCode == KeyCode.Z) virtualPosition.y++;
        if (Event.current.keyCode == KeyCode.Q) virtualPosition.x--;
        if (Event.current.keyCode == KeyCode.D) virtualPosition.x++;

        if(!wrongKey) Repaint();
    }
}
