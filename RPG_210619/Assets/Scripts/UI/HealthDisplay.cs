using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BaseStats))]
public class HealthDisplay : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    GameObject uiGameObject;
    Transform ui;
    Image healthSlider;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;

        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                uiGameObject = Instantiate(uiPrefab, c.transform);
                ui = uiGameObject.transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                break;
            }
        }

        GetComponent<BaseStats>().onHealthChangedCallback += OnHealthChanged;
    }

    void OnHealthChanged(int currentHealth, int maxHealth)
    {
        if (ui != null)
        {
            healthSlider.fillAmount = (float)currentHealth / maxHealth;

            if(healthSlider.fillAmount <= 0)
            {
                DestroyHealthUI();
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ui != null)
        {
            ui.position = target.position;
            ui.forward = -cam.forward;
        }
    }

    void DestroyHealthUI()
    {
        Destroy(uiGameObject);
    }
}
