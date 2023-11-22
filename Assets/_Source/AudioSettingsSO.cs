using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/new Audio Settings",fileName = "AudioSettings")]
public class AudioSettingsSO : ScriptableObject
{
    [Space(10)]
    [SerializeField] private List<AudioDataSO> audioDataDangerous;
    [Space(10)]
    [SerializeField] private List<AudioDataSO> audioDataFriendly;
    [Space(10)]
    [SerializeField] private List<AudioDataSO> audioDataNeutral;

    [field:SerializeField, TextArea] private string message;
    [SerializeField] private string id;
}

[CustomEditor(typeof(AudioSettingsSO))]
[CanEditMultipleObjects]
public class AudioSettingsCustomEditor: Editor
{
    [SerializeField] private AudioContentType contentType;
    private SerializedProperty audioDataDangerous;
    private SerializedProperty audioDataFriendly;
    private SerializedProperty audioDataNeutral;
    private SerializedProperty id;
    private SerializedProperty message;
    private bool _showList;
    private bool _showMessageField;

    private void OnEnable()
    {
        _showList = false;
        _showMessageField = false;
        audioDataDangerous = serializedObject.FindProperty("audioDataDangerous");
        audioDataFriendly = serializedObject.FindProperty("audioDataFriendly");
        audioDataNeutral = serializedObject.FindProperty("audioDataNeutral");
        id = serializedObject.FindProperty("id");
        message = serializedObject.FindProperty("message");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(id);

        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("Get list"))
        {
            _showList = true;
        }
        if (GUILayout.Button("Get message"))
        {
            _showMessageField = true;
        }
        if (GUILayout.Button("Clear"))
        {
            _showMessageField = false;
            _showList = false;
        }
        EditorGUILayout.EndHorizontal();

        if (_showList)
        {
            contentType = (AudioContentType)EditorGUILayout.EnumPopup("Audio content type", contentType);
            switch (contentType)
            {
                case AudioContentType.Dangerous:
                    EditorGUILayout.PropertyField(audioDataDangerous);
                    break;
                case AudioContentType.Friendly:
                    EditorGUILayout.PropertyField(audioDataFriendly);
                    break;
                case AudioContentType.Neutral:
                    EditorGUILayout.PropertyField(audioDataNeutral);
                    break;
            }
        }
        if (_showMessageField)
        {
            EditorGUILayout.PropertyField(message);
        }

        serializedObject.ApplyModifiedProperties();
    }

    enum AudioContentType
    {
        Dangerous,
        Friendly,
        Neutral,
    }
}
