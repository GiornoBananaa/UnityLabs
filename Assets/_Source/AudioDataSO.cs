using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/new Audio Data", fileName = "AudioDataSO")]
public class AudioDataSO : ScriptableObject
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;
}


[CustomEditor(typeof(AudioDataSO))]
[CanEditMultipleObjects]
public class AudioDataCustomEditor : Editor
{
    private SerializedProperty AudioClip;
    private SerializedProperty Volume;

    private void OnEnable()
    {
        AudioClip = serializedObject.FindProperty("audioClip");
        Volume = serializedObject.FindProperty("volume");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(AudioClip);
        EditorGUILayout.Slider(Volume, 0, 10);

        serializedObject.ApplyModifiedProperties();
    }
}
