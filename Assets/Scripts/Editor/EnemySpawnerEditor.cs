using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EnemySpawner script = (EnemySpawner)target;

        script.movementType = (MovementEnum)EditorGUILayout.EnumPopup("Movement Type", script.movementType);
        if (script.movementType == MovementEnum.Circle)
        {
            script.rotationCenter = EditorGUILayout.ObjectField("Rotation Center", script.rotationCenter, typeof(Transform), true) as Transform;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Rotation Radius");
            script.rotationRadius = EditorGUILayout.FloatField(script.rotationRadius);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Angular Speed");
            script.angularSpeed = EditorGUILayout.FloatField(script.angularSpeed);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("xDivider");
            script.xDivider = EditorGUILayout.FloatField(script.xDivider);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("yDivider");
            script.yDivider = EditorGUILayout.FloatField(script.yDivider);
            EditorGUILayout.EndHorizontal();
        }
    }
}
