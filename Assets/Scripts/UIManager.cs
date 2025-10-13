using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Button startButton;

    private void Awake()
    {
        Instance = this;
    }
}
