using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
        }
    }

    public void PlayBGM(AudioClip bgmClip)
    {
        if (bgmAudioSource == null || bgmClip == null) return;

        // �̹� ���� Ŭ���� ��� ���̸� �ƹ� �͵� ���� ����
        if (bgmAudioSource.isPlaying && bgmAudioSource.clip == bgmClip)
        {
            return;
        }

        bgmAudioSource.Stop(); // �ٸ� ���̸� ���� ��� ����
        bgmAudioSource.clip = bgmClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxAudioSource.PlayOneShot(clip);
    }

}