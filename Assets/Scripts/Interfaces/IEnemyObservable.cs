public interface IEnemyObservable
{
    void AddObserver(IEnemyObsever observer);
    void RemoveObserver(IEnemyObsever observer);
    void NotifyObservers();
}
