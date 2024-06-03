using UnityEngine;
using ProjectTools;

[CreateAssetMenu(fileName = "Audio Clip Library", menuName = "Audio / Audio Clip Library Asset")]
public class AudioClipLibrarySO : ScriptableObject
{
    [SerializeField] private SerializableDictionary<string, AudioClip> _audioClipDictionary;

    /// <summary>
    /// Retrieves an audio clip from the dictionary based on the provided name.
    /// </summary>
    /// <param name="audioClipName">The name of the audio clip to retrieve.</param>
    /// <returns>The audio clip if found; otherwise, null.</returns>
    public AudioClip GetAudioClip(string audioClipName)
    {
        if (_audioClipDictionary.TryGetValue(audioClipName, out AudioClip clip))
        {
            return clip;
        }
        else
        {
            Debug.LogWarning($"Unable to find an audio clip with the name: {audioClipName}");
            return null;
        }
    }
} // class