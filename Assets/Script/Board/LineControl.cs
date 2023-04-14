using UnityEngine;
using UnityEngine.UI;

public class LineControl : MonoBehaviour
{
    [SerializeField] private int[] _lineIndex;
    [SerializeField] private Image _lineImage;

    private void Start()
    {
        _lineImage = GetComponent<Image>();
    }

    private Odds[] IntTurnToOdds(int[] boardNum)
    {
        Odds[] newOddsArray = new Odds[_lineIndex.Length];

        for (int i = 0; i < _lineIndex.Length; i++)
        {
            newOddsArray[i] = (Odds)boardNum[_lineIndex[i]];
        }

        return newOddsArray;
    }


    public void LineEnabled(int[] boardNum)
    {
        _lineImage.enabled = IsLineEnabled(IntTurnToOdds(boardNum));
    }

    public void LineDisabled()
    {
        _lineImage.enabled = false;
    }

    private bool IsLineEnabled(params Odds[] lineIndex)
    {
        int sevenQuantity = 0;
        int barQuantity = 0;

        for (int i = 0; i < lineIndex.Length; i++)
        {
            EachQuantity(lineIndex[i], ref sevenQuantity, ref barQuantity);
        }

        if (lineIndex[0] == Odds.hololive)
        {
            return true;
        }
        else if (lineIndex[0] == lineIndex[1] && lineIndex[0] == lineIndex[2])
        {
            return true;
        }
        else if (barQuantity == 3 || sevenQuantity == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void EachQuantity(Odds a, ref int sevenQuantity, ref int barQuantity)
    {
        switch (a)
        {
            case Odds.gura:
            case Odds.ame:
                sevenQuantity++;
                break;
            case Odds.ina:
            case Odds.kronii:
            case Odds.mumei:
                barQuantity++;
                break;
        }
    }
}