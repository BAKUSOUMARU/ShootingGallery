using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    [Header("scoreを表示するテキスト")]
    private Text _text;

    public void TextUpdate(int Score)
    {
        _text.text = "Score" + Score;
    }
}
