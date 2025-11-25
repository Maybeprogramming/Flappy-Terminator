using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIBar))]
public class BarScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UIBar script = (UIBar)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Отнять"))
            script.Reduce();

        if (GUILayout.Button("Прибавить"))
            script.Increase();


        GUILayout.EndHorizontal();
    }
}