
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(QuestGiver))]
public class QuestGiverEditor : Editor
{
    SerializedProperty quest;

    ReorderableList goalList;
    ReorderableList askDialogue;
    ReorderableList questSolvingDialogue;
    ReorderableList completeDialogue;
    ReorderableList afterCompleteDialogue;

    private void OnEnable()
    {
        quest = serializedObject.FindProperty("quest");

        SerializedProperty goals = quest.FindPropertyRelative("goals");
        goalList = new ReorderableList(serializedObject, goals, true, true, true, true);
        goalList.drawHeaderCallback += (Rect rect) => {
            GUI.Label(rect, "Goal List");
        };
        goalList.drawElementCallback += (Rect rect, int index, bool selected, bool focused) =>
        {
            SerializedProperty goal = goals.GetArrayElementAtIndex(index);

            EditorGUI.PropertyField(rect, goal);
        };

        askDialogue = new ReorderableList(serializedObject, serializedObject.FindProperty("askDialogue"), true, true, true, true);
        askDialogue.drawHeaderCallback += (Rect rect) =>
        {
            GUI.Label(rect, "Ask");
        };
        askDialogue.drawElementCallback += (Rect rect, int index, bool selected, bool focused) =>
        {
            SerializedProperty d = serializedObject.FindProperty("askDialogue").GetArrayElementAtIndex(index);

            EditorGUI.PropertyField(rect, d);
        };

        questSolvingDialogue = new ReorderableList(serializedObject, serializedObject.FindProperty("questSolvingDialogue"), true, true, true, true);
        questSolvingDialogue.drawHeaderCallback += (Rect rect) =>
        {
            GUI.Label(rect, "Solving");
        };
        questSolvingDialogue.drawElementCallback += (Rect rect, int index, bool selected, bool focused) =>
        {
            SerializedProperty d = serializedObject.FindProperty("questSolvingDialogue").GetArrayElementAtIndex(index);

            EditorGUI.PropertyField(rect, d);
        };

        completeDialogue = new ReorderableList(serializedObject, serializedObject.FindProperty("completeDialogue"), true, true, true, true);
        completeDialogue.drawHeaderCallback += (Rect rect) =>
        {
            GUI.Label(rect, "Complete");
        };
        completeDialogue.drawElementCallback += (Rect rect, int index, bool selected, bool focused) =>
        {
            SerializedProperty d = serializedObject.FindProperty("completeDialogue").GetArrayElementAtIndex(index);

            EditorGUI.PropertyField(rect, d);
        };

        afterCompleteDialogue = new ReorderableList(serializedObject, serializedObject.FindProperty("afterCompleteDialogue"), true, true, true, true);
        afterCompleteDialogue.drawHeaderCallback += (Rect rect) =>
        {
            GUI.Label(rect, "After Complete");
        };
        afterCompleteDialogue.drawElementCallback += (Rect rect, int index, bool selected, bool focused) =>
        {
            SerializedProperty d = serializedObject.FindProperty("afterCompleteDialogue").GetArrayElementAtIndex(index);

            EditorGUI.PropertyField(rect, d);
        };
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();

        GUILayout.Label("Quest", new GUIStyle("IN TitleText"));

        GUIStyle boxStyle = new GUIStyle("HelpBox") { padding = new RectOffset(10, 10, 10, 10) };
        EditorGUILayout.BeginVertical(boxStyle);
        EditorGUILayout.Space();

        goalList.DoLayoutList();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(quest.FindPropertyRelative("rewardItem"));
        EditorGUILayout.PropertyField(quest.FindPropertyRelative("rewardXP"));

        EditorGUILayout.Space();

        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        GUILayout.Label("Dialogues", new GUIStyle("IN TitleText"));
        EditorGUILayout.BeginVertical(boxStyle);

        askDialogue.DoLayoutList();
        EditorGUILayout.Space();

        questSolvingDialogue.DoLayoutList();
        EditorGUILayout.Space();

        completeDialogue.DoLayoutList();
        EditorGUILayout.Space();

        afterCompleteDialogue.DoLayoutList();

        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
