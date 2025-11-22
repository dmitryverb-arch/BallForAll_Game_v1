using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private ParticleSystem pickupEffect;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {

        if (collected) return;

        if (other.CompareTag("Player"))
        {
            
            collected = true;

            
            DestroyItem.Instance.ItemCollected();

            if (pickupEffect != null)
            {
                pickupEffect.transform.parent = null;
                pickupEffect.Play();
                Destroy(pickupEffect.gameObject, 2f);
            }

            Destroy(gameObject);
        }
    }
}
