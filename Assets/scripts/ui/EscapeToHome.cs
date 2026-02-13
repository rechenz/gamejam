using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToHome : MonoBehaviour
{
    [SerializeField] private string homeSceneName = "Home";
    
    void Update()
    {
        // 检测是否按下 ESC 键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC 按下，返回主界面");
            SceneManager.LoadScene(homeSceneName);
        }
    }
}