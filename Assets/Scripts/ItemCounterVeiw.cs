using TMPro;
using UniRx;
using UnityEngine;

public class ItemCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text countText;
    [SerializeField] private TMP_Text winText;

    private void Start()
    {
        winText.gameObject.SetActive(false);

        var vm = DestroyItem.Instance.ViewModel;

        
        Observable.CombineLatest(
            vm.CollectedItems.StartWith(vm.CollectedItems.Value),
            vm.TotalItems.StartWith(vm.TotalItems.Value),
            (collected, total) => new { collected, total }
            )
    .Subscribe(x =>
    {
        Debug.Log($"UI Update: {x.collected}/{x.total}");
        countText.text = $"{x.collected}/{x.total}";

        if (x.total > 0 && x.collected >= x.total)
            winText.gameObject.SetActive(true);
        })
    .AddTo(this);
    }
}
