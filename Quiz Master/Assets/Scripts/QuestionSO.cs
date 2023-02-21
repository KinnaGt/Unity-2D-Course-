using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question",fileName = "New Question" )]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)] 
    [SerializeField] string question = "Enter New Question";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctIndex;
    public string GetQuestion(){
        return question;
    }

    public int GetCorrectAnswerIndex(){
        return correctIndex;
    }
    public string GetAnswer(int index){
        return answers[index];
    }
}
