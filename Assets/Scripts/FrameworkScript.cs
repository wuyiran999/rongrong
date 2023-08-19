using UnityEngine;
using UnityEngine.UI;

public class FrameworkScript : MonoBehaviour
{
    public Text questionText;
    public Image[] answerImages;
    public Image correctImage;
    public Button nextButton;

    private int currentQuestionIndex = 0;

    private Question[] questions;

    private void Start()
    {
        // 初始化问题数组
        InitializeQuestions();

        // 在开始时设置初始问题和答案
        SetQuestionAndAnswers(currentQuestionIndex);
    }

    private void InitializeQuestions()
    {
        // 初始化问题数组，每个问题都包含问题文本、答案图片数组和正确答案索引
        questions = new Question[]
        {
            new Question("这是问题1吗？", new Sprite[] { /* 设置答案图片 */ }, 0),
            new Question("这是问题2吗？", new Sprite[] { /* 设置答案图片 */ }, 1),
            // ...
        };
    }

    private void SetQuestionAndAnswers(int questionIndex)
    {
        // 设置问题文本
        questionText.text = questions[questionIndex].Text;

        // 加载答案图片
        for (int i = 0; i < answerImages.Length; i++)
        {
            answerImages[i].sprite = questions[questionIndex].AnswerSprites[i];
        }

        // 隐藏正确图片和下一页按钮
        correctImage.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    public void CheckAnswer(int selectedAnswerIndex)
    {
        bool isCorrect = CheckIfAnswerIsCorrect(selectedAnswerIndex);

        if (isCorrect)
        {
            // 显示正确的图片和下一页按钮
            correctImage.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            // 设置下一道问题
            SetQuestionAndAnswers(currentQuestionIndex);
        }
    }

    private bool CheckIfAnswerIsCorrect(int selectedAnswerIndex)
    {
        // 检查所选答案是否正确
        return selectedAnswerIndex == questions[currentQuestionIndex].CorrectAnswerIndex;
    }
}

[System.Serializable]
public class Question
{
    public string Text;
    public Sprite[] AnswerSprites;
    public int CorrectAnswerIndex;

    public Question(string text, Sprite[] answerSprites, int correctAnswerIndex)
    {
        Text = text;
        AnswerSprites = answerSprites;
        CorrectAnswerIndex = correctAnswerIndex;
    }
}
