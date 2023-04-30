public interface IGameMode
{

    public System.Collections.IEnumerator GetServerData(int betInputValue);
    public BackendData BackendData { get; set; }

}
