using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !gameObject.activeSelf) return;
        GameController.Instance.CoinCountUp();
        gameObject.SetActive(false);
    }
}
