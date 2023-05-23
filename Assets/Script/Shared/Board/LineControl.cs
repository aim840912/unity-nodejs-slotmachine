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

    private Odds[] TurnToOddsArray(int[] boardNum)
    {
        Odds[] oddsArray = new Odds[_lineIndex.Length];

        for (int i = 0; i < _lineIndex.Length; i++)
        {
            oddsArray[i] = (Odds)boardNum[_lineIndex[i]];
        }

        return oddsArray;
    }


    public void LineEnabled(int[] boardNum)
    {
        _lineImage.enabled = IsLineEnabled(TurnToOddsArray(boardNum));
    }

    public void LineDisabled()
    {
        _lineImage.enabled = false;
    }

    private bool IsLineEnabled(params Odds[] lineIndex)
    {
        if (lineIndex[0] == Odds.hololive)
        {
            return true;
        }
        else if (lineIndex[0] == lineIndex[1] && lineIndex[0] == lineIndex[2])
        {
            return true;
        }
        else if (IsAnyOddsEqualsQuantity(lineIndex))
        {
            return true;
        }

        return false;
    }

    private bool IsAnyOddsEqualsQuantity(Odds[] odds)
    {
        int anySevenQuantity = 0;
        int anyBarQuantity = 0;

        for (int i = 0; i < odds.Length; i++)
        {
            if (odds[i] == Odds.gura || odds[i] == Odds.ame)
            {
                anySevenQuantity++;
            }
            else if (odds[i] == Odds.ina || odds[i] == Odds.kronii || odds[i] == Odds.mumei)
            {
                anyBarQuantity++;
            }
        }

        if (anySevenQuantity == 3 || anyBarQuantity == 3)
            return true;

        return false;
    }
}