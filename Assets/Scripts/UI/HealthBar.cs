using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : HealthIndicator
{
    Image barImage;

    protected override void Init()
    {
        base.Init();

        barImage = GetComponent<Image>();
        barImage.type = Image.Type.Filled;
    }

    protected override void UpdateIndicator()
    {
        barImage.fillAmount = health.currentHealth / health.MaxHealth;
    }
}
