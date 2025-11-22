using UniRx;

public class ItemViewModel
{
    public ReactiveProperty<int> TotalItems = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> CollectedItems = new ReactiveProperty<int>(0);
}

