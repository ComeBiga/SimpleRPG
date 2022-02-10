
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(Goal))]
public class GoalDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        //EditorGUI.PropertyField(position, property);

        var goalTypeRect = new Rect(position.x, position.y, 100, position.height);
        var requireAmountRect = new Rect(position.x + 105, position.y, 50, position.height);
        var requirementIDRect = new Rect(position.x + 160, position.y, 50, position.height);

        EditorGUI.PropertyField(goalTypeRect, property.FindPropertyRelative("goalType"), GUIContent.none);
        EditorGUI.PropertyField(requireAmountRect, property.FindPropertyRelative("requirementAmount"), GUIContent.none);
        EditorGUI.PropertyField(requirementIDRect, property.FindPropertyRelative("requirementID"), GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
