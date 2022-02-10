
using UnityEngine;
using UnityEditor;

public class QuestGenerator : EditorWindow
{
    int toolbarIndex = 0;

    [MenuItem("Window/QuestGenerator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(QuestGenerator));
    }

    private void OnGUI()
    {
        GameObject gb = Selection.activeGameObject;

        Editor ed = Editor.CreateEditor(gb.GetComponent<QuestGiver>());
        if(ed != null)
            ed.OnInspectorGUI();
    }
}
