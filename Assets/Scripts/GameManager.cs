//A script for providing the logic behind the quiz. Last edited by David Forster 09/05/2016

// Tutorial has been followed from  https://www.youtube.com/watch?v=5CW1yGsVg4k for loading 
// random questions and displaying questions.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Question[] questions; // declares the array of questions
    private static List<Question> unansweredQuestions;   // list allows you to remove from it

    private Question currentQuestion; // variable for current question

    [SerializeField] // serializing fields allows the inspector in unity to access the variable whilst it's still private
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f; // sets time between question to 1 second

    [SerializeField]
    private Text trueAnswerText; // variable for correct answer

    [SerializeField]
    private Text falseAnswerText; // variable for incorrect answer

    [SerializeField]
    private Animator animator; // variable for animation

    [SerializeField]
    private AudioSource asource; // provides a source for question audio

    [SerializeField]
    private AudioSource Correct1; // links correct sound to this code

    [SerializeField]
    private AudioSource Wrong1; // links wrong sound to this code

    [SerializeField]
    private Text scoreText; // text on screen for the score

    [SerializeField]
    private static int userScore; // variable that stores the score 

    [SerializeField]
    private static int noOfQuestionsAnswered = -1; // variable that stores the score 

    void Start() // when the program starts
    {
        if(unansweredQuestions == null || unansweredQuestions.Count == 0) // if no questions are left
        {
            unansweredQuestions = questions.ToList<Question>(); 
        }
        SetCurrentQuestion(); // calls random question function
        scoreText.text = "Correct Answers: " +  userScore.ToString() + "/" + noOfQuestionsAnswered;
    }

    void SetCurrentQuestion() // retrieves a random question to display
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count); // decides a random number question
        currentQuestion = unansweredQuestions[randomQuestionIndex]; // question becomes a random unanswered question

        factText.text = currentQuestion.fact;

        asource.clip = currentQuestion.QuestionAudio; // assigns audio clip to current question
        asource.Play(); // plays the current question audio

        if (currentQuestion.isTrue) // If the answer is true
        {
            trueAnswerText.text = "Correct";
            falseAnswerText.text = "Wrong";
            noOfQuestionsAnswered = noOfQuestionsAnswered + 1; // increments to next question
        }
        else // if the answer is false
        {
            trueAnswerText.text = "Wrong";
            falseAnswerText.text = "Correct";
            noOfQuestionsAnswered = noOfQuestionsAnswered + 1; // increments to next question
        }

    }

    IEnumerator TransitionToNextQuestion () // waits time until next question
    {
        unansweredQuestions.Remove(currentQuestion); // removes the question that was just shown

        yield return new WaitForSeconds(timeBetweenQuestions); // waits 1 second before next question 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // loads current scene to refresh page
    }

    public void UserSelectrue () // defines if the user is right or wrong from true click
    {
        animator.SetTrigger("True");

       if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!");
            userScore = userScore + 1; // score +1 
            Correct1.Play(); // plays correct sound
        }
        else
        {
            Debug.Log("WRONG!");
            Wrong1.Play(); // plays wrong sound
        }

        StartCoroutine(TransitionToNextQuestion()); // loads next question
    }

    public void UserSelectfalse() // defines if the user is right or wrong from false click
    {
        animator.SetTrigger("False");

        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!");
            userScore = userScore + 1; // score +1 
            Correct1.Play(); // plays correct sound
        }
        else
        {
            Debug.Log("WRONG!");
            Wrong1.Play(); // plays wrong sound
        }

        StartCoroutine(TransitionToNextQuestion()); // loads next question 
    }

    public void UserSelectMainmenu() // takes user back to the main menu
    {
       SceneManager.LoadScene("MainMenu");        
    }


    public void Resetscore() // resets the score and questions answered variables when the user clicks play quiz
    {
        userScore = 0;
        noOfQuestionsAnswered = -1;
    }
}
