using UnityEngine;

public class AudioFade : MonoBehaviour
{
    public void BGMFadeInButton()
    {
        AudioManager.Instance.FadeInAudio(AudioManager.AudioSourceType.BGM, 0.05f, 1);
    }

    public void BGMFadeOutButton()
    {
        AudioManager.Instance.FadeOutAudio(AudioManager.AudioSourceType.BGM, 0.05f);
    }

    public void SFXFadeOutButton()
    {
        AudioManager.Instance.FadeOutAudio(AudioManager.AudioSourceType.SFX, 0.1f);
    }
}