using UniRx;

public class ScoreModel : SingletonMonoBehaviour<ScoreModel>
{
    public ReactiveProperty<int> Score => _score;

    private readonly IntReactiveProperty _score = new(0);

    public void AddScore(int addScore)
    {
        _score.Value += addScore;
    }
}
