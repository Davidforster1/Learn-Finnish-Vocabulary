// Script provides menu access to other scenes. Last edited by David Forster 09/05/2016

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Vocabmenuscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void UserSelectNumbers() 
    {
        SceneManager.LoadScene("Numbers1"); // loads numbers1 scene
    }

    public void UserSelectNumbersPage2() // loads numbers2 scene
    {
        SceneManager.LoadScene("Numbers2"); 
    }

    public void UserSelectSports() // loads Sports scene
    {
        SceneManager.LoadScene("Sports");
    }

    public void UserSelectCountries() // loads Countries1 scene
    {
        SceneManager.LoadScene("Countries1");
    }

    public void UserSelectCountries2() // loads Countries2 scene
    {
        SceneManager.LoadScene("Countries2");
    }

    public void UserSelectDaysoftheweek() // loads DaysOfWeek scene
    {
        SceneManager.LoadScene("DaysOfWeek");
    }

    public void UserSelectVocabmenu() // loads Vocabmenu scene
    {
        SceneManager.LoadScene("Vocabmenu");
    }

    public void UserSelectMainMenu() // loads MainMenu scene
    {
        SceneManager.LoadScene("MainMenu");
    }


}
