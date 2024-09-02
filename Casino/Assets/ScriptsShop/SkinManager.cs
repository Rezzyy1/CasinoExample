using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer playerRenderer; // Спрайт игрока, который будет изменяться
    public Sprite defaultSkin; // Спрайт стандартного скина
    public Sprite[] skins; // Массив доступных скинов

    void Start()
    {
        // Загрузка выбранного скина
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", -1); // По умолчанию - стандартный скин
        ApplySkin(selectedSkinIndex);
    }

    private void ApplySkin(int skinIndex)
    {
        if (skinIndex == -1)
        {
            playerRenderer.sprite = defaultSkin; // Применяем стандартный скин
        }
        else
        {
            playerRenderer.sprite = skins[skinIndex]; // Применяем выбранный скин
        }
    }
}



