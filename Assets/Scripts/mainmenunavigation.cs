// A script providing menu navigation for the application Last edited by David Forster 09/05/2016

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class mainmenunavigation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}

    public void UserSelectVocab() // takes user back to the main menu
    {
        SceneManager.LoadScene("VocabMenu");

    }

    public void UserSelectQuiz() // takes user to quiz
    {
        SceneManager.LoadScene("Quiz");
    }

    public void UserSelectTutorial() // takes user to quiz
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void UserSelectQuit() // quits game
    {
        Application.Quit();
    }

}
