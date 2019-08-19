using UnityEngine;
using UnityEngine.SceneManagement;
public class AmountMenu : MonoBehaviour
{
    public void Single()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void Multy()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
