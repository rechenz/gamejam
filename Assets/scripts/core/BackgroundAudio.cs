using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalBackgroundMusic : MonoBehaviour
{
    [Header("音乐设置")]
    public AudioClip backgroundMusic;      // 背景音乐文件
    [Range(0f, 1f)]
    public float volume = 0.5f;           // 音量
    public bool playOnAwake = true;       // 启动时播放
    public bool loop = true;             // 是否循环

    private AudioSource audioSource;
    private static GlobalBackgroundMusic instance;

    void Awake()
    {
        // 单例模式，确保全局只有一个背景音乐
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ✅ 全局保留，不销毁

            // 初始化音频源
            SetupAudioSource();
        }
        else
        {
            Destroy(gameObject);  // 销毁重复的音乐播放器
            return;
        }
    }

    void SetupAudioSource()
    {
        // 获取或添加AudioSource组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 配置AudioSource
        audioSource.clip = backgroundMusic;
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.playOnAwake = playOnAwake;
        audioSource.spatialBlend = 0f;  // 2D声音，全局播放

        // 自动播放
        if (playOnAwake && backgroundMusic != null)
        {
            audioSource.Play();
        }
    }

    // ========== 公共控制方法 ==========

    public void PlayMusic()
    {
        if (audioSource != null && backgroundMusic != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void ChangeMusic(AudioClip newMusic)
    {
        backgroundMusic = newMusic;
        if (audioSource != null)
        {
            audioSource.clip = newMusic;
            if (audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    // 淡入淡出效果（可选）
    public void FadeIn(float fadeTime)
    {
        StartCoroutine(FadeInCoroutine(fadeTime));
    }

    public void FadeOut(float fadeTime)
    {
        StartCoroutine(FadeOutCoroutine(fadeTime));
    }

    private System.Collections.IEnumerator FadeInCoroutine(float fadeTime)
    {
        float startVolume = 0f;
        audioSource.volume = 0f;
        audioSource.Play();

        while (audioSource.volume < volume)
        {
            audioSource.volume += startVolume + Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.volume = volume;
    }

    private System.Collections.IEnumerator FadeOutCoroutine(float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}