using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIBar))]
public class BarScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UIBar script = (UIBar)target;

        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        GUILayout.Label("Нажми на кнопки для теста бара");

        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Отнять"))
            script.Reduce();

        if (GUILayout.Button("Прибавить"))
            script.Increase();

        GUILayout.EndHorizontal();
    }
}