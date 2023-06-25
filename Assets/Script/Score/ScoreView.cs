using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    [Header("scoreを表示するテキスト")]
    private Text _text;

    [SerializeField]
    [Header("スコア画面のテキスト")]
    private Text _scoreText;

    public void TextUpdate(int Score)
    {
        _text.text = "Score" + Score;
        _scoreText.text = "Score" + Score;
    }
}
