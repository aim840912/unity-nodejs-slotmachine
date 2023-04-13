using System;

public class Board
{
    private int[] slotNumber = new int[9];
    private int _minNumber;
    private int _maxNumber;

    public Board(int minNumber, int maxNumber)
    {
        this._minNumber = minNumber;
        this._maxNumber = maxNumber;
    }


    public int[] GenerateNumber()
    {
        Random randomNumber = new Random();

        for (var i = 0; i < slotNumber.Length; i++)
        {
            slotNumber[i] = randomNumber.Next(_minNumber, _maxNumber);
        }

        return slotNumber;
    }
}
