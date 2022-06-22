
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TMP_Text TXTScore;
    void Start()
    {
        TXTScore.text = "Score: " + score;
    }


    public void MoreScore()
    {
        score++;
        TXTScore.text = "Score: " + score;
    }
}
