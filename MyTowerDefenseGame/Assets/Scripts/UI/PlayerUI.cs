using UnityEngine;
using UnityEngine.UI;

public class PlayerUI: MonoBehaviour
{
    [SerializeField] private Text livesText;
    [SerializeField] private Text coinsText;


    public void Update()
    {
        livesText.text = PlayerStats.Main.Lives.ToString();
        coinsText.text = PlayerStats.Main.Money.ToString();

    }
}
