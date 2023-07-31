public interface IGameMode
{
    public System.Collections.IEnumerator GetBackendData(int betInputValue);
    public BackendData BackendData { get; set; }
}
