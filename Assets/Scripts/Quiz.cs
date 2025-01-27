using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Add this for TextMeshPro support

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;       // Question text
        public string[] answerChoices;    // Array of possible answer choices
        public int correctAnswerIndex;    // Index of the correct answer (0-based)
    }

    public TextMeshProUGUI questionText;    // UI TextMeshProUGUI element for displaying the question
    public Button[] answerButtons;          // UI Buttons for answer choices
    public TextMeshProUGUI scoreText;       // UI TextMeshProUGUI element to display the score

    public Question[] questions;            // Array of questions

    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        // Show the first question
        ShowQuestion(currentQuestionIndex);

        // Assign button listeners
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;  // Capture the index for use in the lambda
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    // Display question and answer choices
    void ShowQuestion(int index)
    {
        // Ensure we're within the bounds of the questions array
        if (index >= questions.Length) return;

        questionText.text = questions[index].questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < questions[index].answerChoices.Length)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[index].answerChoices[i];
            }
        }
    }

    // Check if the selected answer is correct
    void CheckAnswer(int selectedAnswer)
    {
        if (selectedAnswer == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score++;
        }

        // Move to the next question
        currentQuestionIndex++;

        // If there are more questions, show the next question
        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            // Show final score when all questions are answered
            scoreText.text = "Your score: " + score + "/" + questions.Length;
        }
    }
}