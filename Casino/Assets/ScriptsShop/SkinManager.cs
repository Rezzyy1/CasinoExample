using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer playerRenderer; // ������ ������, ������� ����� ����������
    public Sprite defaultSkin; // ������ ������������ �����
    public Sprite[] skins; // ������ ��������� ������

    void Start()
    {
        // �������� ���������� �����
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", -1); // �� ��������� - ����������� ����
        ApplySkin(selectedSkinIndex);
    }

    private void ApplySkin(int skinIndex)
    {
        if (skinIndex == -1)
        {
            playerRenderer.sprite = defaultSkin; // ��������� ����������� ����
        }
        else
        {
            playerRenderer.sprite = skins[skinIndex]; // ��������� ��������� ����
        }
    }
}



