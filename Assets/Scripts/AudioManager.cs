using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource _backgroundMusicAudioSource, _soundEffectsAudioSource;
    [SerializeField] private AudioClipLibrarySO _backgroundMusicLibrary, _soundEffectsLibrary;

    public enum AudioSourceType
    {
        BGM,
        SFX
    };
    #endregion

    #region Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    #region Background Music Control Functions
    public void SetBackgroundMusicVolume(float volume)
    {
        _backgroundMusicAudioSource.volume = volume;
    }

    public void PlayBackgroundMusic(string audioClipName)
    {
        _backgroundMusicAudioSource.clip = _backgroundMusicLibrary.GetAudioClip(audioClipName);

        if (_backgroundMusicAudioSource.clip)
        {
            _backgroundMusicAudioSource.Play();
        }
    }

    public void PauseBackgroundMusic()
    {
        if (_backgroundMusicAudioSource.isPlaying)
        {
            _backgroundMusicAudioSource.Pause();
        }
    }

    public void UnpauseBackgroundMusic()
    {
        if (!_backgroundMusicAudioSource.isPlaying)
        {
            _backgroundMusicAudioSource.UnPause();
        }
    }

    public void StopBackgroundMusic()
    {
        if (_backgroundMusicAudioSource.clip)
        {
            _backgroundMusicAudioSource.Stop();
        }
    }

    public void ToggleBackgroundMusicMute()
    {
        _backgroundMusicAudioSource.mute = !_backgroundMusicAudioSource.mute;
    }
    #endregion

    #region Sound Effects Control Functions
    public void SetSoundEffectsVolume(float volume)
    {
        _soundEffectsAudioSource.volume = volume;
    }

    public void PlaySoundEffect(string audioClipName)
    {
        AudioClip clip = _soundEffectsLibrary.GetAudioClip(audioClipName);

        if (clip)
        {
            _soundEffectsAudioSource.PlayOneShot(clip);
        }
    }

    public void PauseSoundEffects()
    {
        if (_soundEffectsAudioSource.isPlaying)
        {
            _soundEffectsAudioSource.Pause();
        }
    }

    public void UnpauseSoundEffects()
    {
        if (!_soundEffectsAudioSource.isPlaying)
        {
            _soundEffectsAudioSource.UnPause();
        }
    }

    public void StopSoundEffects()
    {
        _soundEffectsAudioSource.Stop();
    }

    public void ToggleSoundEffectsMute()
    {
        _soundEffectsAudioSource.mute = !_soundEffectsAudioSource.mute;
    }
    #endregion

    #region Custom Effects
    #region Fade In
    /// <summary>
    /// This function fades in audio
    /// </summary>
    /// <param name="audioSourceType">The type of audio source (background music or sound effects).</param>
    /// <param name="speed">The speed at which the audio should fade in.</param>
    /// <param name="maxVolume">The target maximum volume.</param>
    public void FadeInAudio(AudioSourceType audioSourceType, float speed = 0.05f, float maxVolume = 1f)
    {
        AudioSource audioSource = (audioSourceType == AudioSourceType.BGM) ? _backgroundMusicAudioSource : _soundEffectsAudioSource;

        if (_soundEffectsAudioSource)
        {
            StartCoroutine(FadeIn(audioSource, speed, maxVolume));
        }
        else if (audioSource.clip != null)
        {
            StartCoroutine(FadeIn(audioSource, speed, maxVolume, true));
        }
        else
        {
            Debug.LogWarning("Audio Source does not have a clip assigned, so FadeIn doesn't work");
        }
    }

   /// <summary>
   /// Fades in Audio from zero volume
   /// </summary>
   /// <param name="audioSource"></param>
   /// <param name="speed"></param>
   /// <param name="maxVolume"></param>
   /// <param name="isBGMAudioSource"></param>
   /// <returns></returns>
    private IEnumerator FadeIn(AudioSource audioSource, float speed, float maxVolume, bool isBGMAudioSource = false)
    {
        float volume = 0;
        float delayTime = 0.1f;

        audioSource.volume = volume;

        if (isBGMAudioSource)
        {
            UnpauseBackgroundMusic();
        }

        while (audioSource.volume < maxVolume)
        {
            volume += speed;
            audioSource.volume = volume;
            yield return new WaitForSeconds(delayTime);
        }
    }
    #endregion

    #region Fade Out
    /// <summary>
    /// This function fades out audio
    /// </summary>
    /// <param name="audioSourceType"> The type of audio source (background music or sound effects).</param>
    /// <param name="speed">  The speed at which the audio should fade out. </param>
    public void FadeOutAudio(AudioSourceType audioSourceType, float speed = 0.05f)
    {
        AudioSource audioSource = (audioSourceType == AudioSourceType.BGM) ? _backgroundMusicAudioSource : _soundEffectsAudioSource;

        if (_soundEffectsAudioSource)
        {
            StartCoroutine(FadeOut(audioSource, speed));
        }
        else if (audioSource.clip != null)
        {
            StartCoroutine(FadeOut(audioSource, speed, true));
        }
        else
        {
            Debug.LogWarning("Audio Source does not have a clip assigned, so fadeOut doesn't work");
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float speed, bool isBGMAudioSource = false)
    {
        float volume = audioSource.volume;
        float muteVolume = 0.0f;
        float delayTime = 0.1f;

        while (audioSource.volume > muteVolume)
        {
            volume -= speed;
            audioSource.volume = volume;
            yield return new WaitForSeconds(delayTime);
        }

        if (isBGMAudioSource)
        {
            PauseBackgroundMusic();

        }
        else
        {
            // SFX being too short, so insted of pausing we're stopping it
            StopSoundEffects();

            float fullVolume = 1.0f;
            SetSoundEffectsVolume(fullVolume);
        }
    }
    #endregion
    #endregion
    #endregion
    #region Epic Typo
    //private AudioSource GetAduioSoruce(AudioSourceType audioSourceType)
    //{
    //    if (audioSourceType == AudioSourceType.BGM)
    //        return _backgroundMusicAudioSource;
    //    else
    //        return _soundEffectsAudioSource;
    //}
    #endregion
} // class