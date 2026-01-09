using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private int _coinCount;
    public TMP_Text counterText;
    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void CoinCountUp()
    {
        _audioSource.pitch = Random.Range(1, 1.5f);
        _audioSource.Play();
        _coinCount++;
        counterText.text = "Coins: " + _coinCount;
    }
}
