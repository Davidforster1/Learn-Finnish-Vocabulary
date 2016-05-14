//A script for providing the question object for the quiz. Last edited by David Forster 09/05/2016
// Tutorial has been followed from  https://www.youtube.com/watch?v=5CW1yGsVg4k for adding the fact and boolean value to the object.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable] // Notifies Unity that this class can save/store information
public class Question {

    public string fact; 
    public bool isTrue;
    public AudioClip QuestionAudio;  
}
