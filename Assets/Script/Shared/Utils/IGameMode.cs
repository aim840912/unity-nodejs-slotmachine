public interface IGameMode
{
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; }
    public bool GetData { get; set; }
    public System.Collections.IEnumerator GetServerData(int betInputValue);
    public ServerReturnData ServerReturnData { get; set; }

}
