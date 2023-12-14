using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerWalk,
        PlayerDash,
        LaserRifle_Shot,
        LaserRifle_Reload,
        EnemyExplosion1,
        EnemyChaserAttack,
        EnemyLaserHit,
        EnemyCoins
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerWalk] = 0f;
    }
    public static void PlayOneShotSound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGO = new GameObject("Sound");
            AudioSource audioSource = soundGO.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
        
    }

    public static AudioSource PlaySound(Sound sound)
    {
        GameObject soundGO = new GameObject("Sound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
        return audioSource;
    }

    private static bool CanPlaySound (Sound sound)
    {
        switch (sound)
        {
            case Sound.PlayerWalk:
                if (soundTimerDictionary.ContainsKey(sound)){
                    float lasTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = 0.5f;
                    if (lasTimePlayed +  playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    } else { return false;}
                } else { return true; }
                //break;            
            default: return true;
        }
    }

    public static void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.ins.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound) 
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.Log(GameAssets.ins.soundAudioClipArray);
        Debug.LogError("Sound " + sound + " not found!!");
        return null;
    }
}
