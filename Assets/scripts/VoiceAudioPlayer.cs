using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.Video;

public class VoiceAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClip;
    private AudioSource audioSource;
    private Recorder recorder;
    public VideoPlayer videoPlayer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        recorder = GetComponent<Recorder>();

        if (audioClip != null)
        {
            audioSource.clip = audioClip[0];
            audioSource.loop = false;

            // 確保 Recorder 傳輸音頻
            recorder.TransmitEnabled = true;

            // 開始播放音頻
            audioSource.Play();
            Invoke("StopLoop", 20f);
        }
    }
    void StopLoop()
    {
        videoPlayer.isLooping = false;
    }
    
    public void AudioPlay(int index)
    {
        audioSource.clip = audioClip[index];//1答對 2答錯
        audioSource.loop = false;

        // 確保 Recorder 傳輸音頻
        recorder.TransmitEnabled = true;

        // 開始播放音頻
        audioSource.Play();
    }
}
