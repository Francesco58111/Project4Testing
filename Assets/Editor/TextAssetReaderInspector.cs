using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TextAssetReader))]
public class TextAssetReaderInspector : Editor
{
    TextAssetReader assetTarget;

    private void OnEnable()
    {
        assetTarget = target as TextAssetReader;
    }

    public override void OnInspectorGUI()
    {
        if (assetTarget.myTextAsset != null)
        {
            if (GUILayout.Button("Analyze CSV File"))
            {
                GenerateQuests();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            TestEidtorWindow myWindow = EditorWindow.GetWindow(typeof(TestEidtorWindow)) as TestEidtorWindow;

            myWindow.Init(assetTarget);
        }

        base.OnInspectorGUI();
    }

    void GenerateQuests()
    {
        //Debug.Log("Analizing");

        Undo.RecordObject(assetTarget, "Testing the button");

        string rawContent = assetTarget.myTextAsset.text;


        string[] lines = rawContent.Split(new string[] { "\n" }, System.StringSplitOptions.None);

        string[] separator = new string[] { ";" };

        string[] rewardTypes = System.Enum.GetNames(typeof(RewardType));


        List<QuestSettings> tempQS = new List<QuestSettings>();

        //Debug.Log(lines.Length);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cells = lines[i].Split(separator, System.StringSplitOptions.None);


            QuestSettings quest = new QuestSettings();


            int questIndex = 0;
            int.TryParse(cells[0], out questIndex);
            quest.index = questIndex;


            quest.title = cells[1];
            quest.description = cells[2];


            string rewardName = cells[3];
            quest.rewardType = (RewardType)System.Enum.Parse(typeof(RewardType), rewardName, true);


            int rewardVal = 0;
            int.TryParse(cells[4], out rewardVal);
            quest.rewardValue = rewardVal;

            tempQS.Add(quest);
        }


        assetTarget.quests = tempQS.ToArray();

    }
}
