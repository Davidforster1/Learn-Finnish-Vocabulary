// A script which plays the video in the tutorial section. Last edited by David Forster 09/05/2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie2; // declares variables for videos
    private AudioSource movie2audio;

    void Start () {
        GetComponent<RawImage>().texture = movie2 as MovieTexture; // sets the video files to the raw image on start
        movie2audio = GetComponent<AudioSource>();
        movie2audio.clip = movie2.audioClip;
        movie2.Play();
        movie2audio.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && movie2.isPlaying) // pauses
        {
            movie2.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !movie2.isPlaying) // resumes
        {
            movie2.Play();
        }

        if(Input.GetKeyDown(KeyCode.Return) && movie2.isPlaying) // allows the user to restart the video
        {
            movie2.Stop();
            int scene = SceneManager.GetActiveScene().buildIndex; // reloads scene
            SceneManager.LoadScene(scene, LoadSceneMode.Single); 
        }

    }

}