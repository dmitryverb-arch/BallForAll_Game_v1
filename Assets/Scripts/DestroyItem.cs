using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    public static DestroyItem Instance;

    public ItemViewModel ViewModel = new ItemViewModel();

    private void Awake()
    {
        if (Instance != null && Instance != this)
    {
        Debug.LogWarning("Duplicate DestroyItem found! Destroying this instance.");
        Destroy(gameObject);
        return;
    }

    Instance = this;
        
    }   
    public void SetTotal(int total)
    {
        ViewModel.TotalItems.Value = total;
        ViewModel.CollectedItems.Value = 0;
    }

    public void ItemCollected()
    {
        ViewModel.CollectedItems.Value++;
        Debug.Log($"collected value {ViewModel.CollectedItems.Value}");

        
    }
}
