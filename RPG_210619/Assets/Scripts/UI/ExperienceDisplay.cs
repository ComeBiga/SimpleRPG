
using UnityEngine;
using UnityEngine.UI;

public class ExperienceDisplay : MonoBehaviour
{
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
         PlayerManager.instance.player.GetComponent<BaseStats>().exp.OnChangedExprience += OnChangedExperience;
    }

    void OnChangedExperience(int currentXP, int requireXP)
    {
        fill.fillAmount = (float)currentXP / requireXP;
    }
}
