
public interface IObservable
{
    bool RegisterObserver(IObserver observer);
    bool RemoveObserver(IObserver observer);
    void Notify();
}
