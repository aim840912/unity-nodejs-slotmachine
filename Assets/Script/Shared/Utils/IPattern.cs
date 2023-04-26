public interface IGameMode
{
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; }
    public int PlayerMoney { get; set; }
    public System.Collections.IEnumerator GetServerData();
}
