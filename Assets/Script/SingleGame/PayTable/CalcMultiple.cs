using System.Linq;

public class CalcMultiple
{
    int[][] _eachLineIndexList = {
         new int[] { 0, 1, 2 },
         new int[] { 3, 4, 5 },
         new int[] { 6, 7, 8 },
         new int[] { 0, 3, 6 },
         new int[] { 1, 4, 7 },
         new int[] { 2, 5, 8 },
         new int[] { 0, 4, 8 },
         new int[] { 6, 4, 2 },
         };

    public int GetMultiples(int[] board)
    {
        Odds[] oddsArr = NumConvertToOdds(board);

        int multiple = 0;

        multiple = CalcAllTheSame(oddsArr);

        if (multiple > 0)
        {
            return multiple;
        }

        foreach (var item in _eachLineIndexList)
        {
            var line = new Odds[item.Length];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = oddsArr[item[i]];
            }
            multiple += CalcWinLine(line);
        }
        multiple += CalcBoardSevenCount(oddsArr);

        return multiple;
    }

    Odds[] NumConvertToOdds(int[] convertThing)
    {
        Odds[] oddsArr = new Odds[convertThing.Length];

        for (int i = 0; i < convertThing.Length; i++)
        {
            oddsArr[i] = (Odds)convertThing[i];
        }
        return oddsArr;
    }

    int CalcAllTheSame(params Odds[] odds)
    {
        int numCount = odds.Count(x => x == odds[0]);

        if (numCount == odds.Length)
        {
            return OddsDict.dictOverall[odds[0]];
        }

        return CalcSimilar(odds);
    }

    int CalcSimilar(params Odds[] odds)
    {
        Odds oddsType = CalcEachCount(odds);

        return oddsType == Odds.none ? 0 : OddsDict.dictOverall[oddsType];
    }

    int CalcBoardSevenCount(params Odds[] odds)
    {
        int countRedSeven = odds.Count(x => x == Odds.gura);
        int countBlueSeven = odds.Count(x => x == Odds.ame);

        if (countRedSeven > 0 && countBlueSeven > 0)
        {
            return OddsDict.dictSpecial[Odds.anySeven][countRedSeven + countBlueSeven];
        }
        else if (countRedSeven == 0 && countBlueSeven > 1)
        {
            return OddsDict.dictSpecial[Odds.ame][countBlueSeven];
        }
        else if (countRedSeven > 1 && countBlueSeven == 0)
        {
            return OddsDict.dictSpecial[Odds.gura][countRedSeven];
        }
        return 0;
    }

    int CalcWinLine(params Odds[] odds)
    {
        Odds oddsType = CalcEachCount(odds);

        if (odds[0] == odds[1] && odds[0] == odds[2])
        {
            return OddsDict.dicNormal[odds[0]];
        }
        else if (oddsType == Odds.anySeven || oddsType == Odds.anyBar)
        {
            return OddsDict.dicNormal[oddsType];
        }
        else if (odds[0] == Odds.hololive)
        {
            return odds[0] == odds[1] ? 5 : 2;
        }
        return 0;
    }

    Odds CalcEachCount(Odds[] odds)
    {
        int countSeven = 0;
        int countBar = 0;
        int countFruit = 0;

        for (int i = 0; i < odds.Length; i++)
        {
            switch (odds[i])
            {
                case Odds.gura:
                case Odds.ame:
                    countSeven++;
                    break;
                case Odds.ina:
                case Odds.kronii:
                case Odds.mumei:
                    countBar++;
                    break;
                case Odds.sana:
                    break;
                default:
                    countFruit++;
                    break;
            }
        }

        if (countSeven == odds.Length)
        {
            return Odds.anySeven;
        }
        else if (countBar == odds.Length)
        {
            return Odds.anyBar;
        }
        else if (countFruit == odds.Length)
        {
            return Odds.anyFruit;
        }
        else
        {
            return Odds.none;
        }
    }
}
