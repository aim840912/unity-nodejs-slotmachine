public interface IGameMode
{

    public System.Collections.IEnumerator GetServerData(int betInputValue);
    public ServerReturnData ServerReturnData { get; set; }

}
