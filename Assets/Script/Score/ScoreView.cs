using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    [Header("scoreを表示するテキスト")]
    private Text _text;

    [SerializeField]
    [Header("scoreを表示するテキスト")]
    private Text _text2;
    
    public void TextUpdate(int Score)
    {
        _text.text = "Score" + Score;
        _text2.text = "Score" + Score;
    }
}
