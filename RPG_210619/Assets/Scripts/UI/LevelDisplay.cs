
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Lv.1";

        PlayerManager.instance.player.GetComponent<BaseStats>().exp.OnChangedLevel += OnChangedLevel;
    }

    void OnChangedLevel()
    {
        levelText.text = "Lv." + PlayerManager.instance.player.GetComponent<BaseStats>().exp.level.ToString();
    }
}
