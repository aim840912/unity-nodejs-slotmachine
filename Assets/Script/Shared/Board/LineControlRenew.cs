using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Image LineImage;
    public int[] LineIndex;
}
public class LineControlRenew : MonoBehaviour
{
    [SerializeField] private Line[] _lineObjs;

    public void LineEnabled(int[] boardNum)
    {
        Odds[] newLineIndex;
        for (int i = 0; i < _lineObjs.Length; i++)
        {
            newLineIndex = new Odds[_lineObjs[i].LineIndex.Length];

            for (var j = 0; j < newLineIndex.Length; j++)
            {
                newLineIndex[j] = (Odds)boardNum[_lineObjs[i].LineIndex[j]];
            }

            _lineObjs[i].LineImage.enabled = IsLineEnabled(newLineIndex);
        }
    }

    public void LineDisabled()
    {
        for (int i = 0; i < _lineObjs.Length; i++)
        {
            _lineObjs[i].LineImage.enabled = false;

        }
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