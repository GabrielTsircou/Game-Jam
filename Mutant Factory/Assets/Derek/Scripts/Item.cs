using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual void OnPickup(GameObject player)
    {
        Debug.Log($"{name} was picked up by ${player}.");
        transform.SetParent(player.transform);
    }

    public virtual void OnDrop(GameObject player)
    {
        Debug.Log($"{name} was dropped by ${player}.");
        transform.SetParent(null);
    }

    public virtual void OnEquip(GameObject player)
    {
        gameObject.SetActive(true);
    }

    public virtual void OnUnequip(GameObject player)
    {
        gameObject.SetActive(false);
    }

    public virtual void OnUse(GameObject player)
    {

    }
}
