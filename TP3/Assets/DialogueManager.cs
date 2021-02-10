using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Image picture;

    [SerializeField] private TextMeshProUGUI[] textContent;

    [SerializeField] private TextMeshProUGUI nameText;

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        picture.sprite = character.profil;
        nameText.text = character.fullName;

    }
    
    public void goNext()
    {
        foreach (TextMeshProUGUI line in textContent)
        {
            line.text = character.content[i];
            i++;
        }
    }
}
