using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Image LineImage;
    public int[] LineIndex;
}
public class LineControl : MonoBehaviour
{
    [SerializeField] private Line[] _lineObjs;

    public void Spin()
    {
        LineDisabled();
    }

    public void Stop(int[] boardNum)
    {
        LineEnabled(boardNum);
    }

    private void LineEnabled(int[] boardNum)
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


    private void LineDisabled()
    {
        for (int i = 0; i < _lineObjs.Length; i++)
        {
            _lineObjs[i].LineImage.enabled = false;
        }
    }

    private bool IsLineEnabled(Odds[] lineIndex)
    {
        if (lineIndex[0] == Odds.hololive)
        {
            return true;
        }
        else if (lineIndex[0] == lineIndex[1] && lineIndex[0] == lineIndex[2])
        {
            return true;
        }
        else if (CheckHaveAnyOddsType(lineIndex))
        {
            return true;
        }

        return false;
    }

    private bool CheckHaveAnyOddsType(Odds[] odds)
    {
        int anySevenQuantity = 0;
        int anyBarQuantity = 0;
        int anyTypeAmount = odds.Length;

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

        if (anySevenQuantity == anyTypeAmount || anyBarQuantity == anyTypeAmount)
            return true;

        return false;
    }
}