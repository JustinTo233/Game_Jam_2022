using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource GameoverMusic;

    public bool background = true;
    public bool gameover = false;

    public void PlayBackgroundMusic()
    {
        background = true;
        gameover = false;
        BackgroundMusic.Play();
    }

    public void PlayGameoverMusic()
    {
        if(BackgroundMusic.isPlaying)
        {
            background = false;
        }
        BackgroundMusic.Stop();

        if(GameoverMusic.isPlaying && gameover == false)
        {
            GameoverMusic.Play();
            gameover = true;
        }
    }

}
