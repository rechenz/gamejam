using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("目标场景")]
    [SerializeField] private string targetSceneName = "AboutUs";
    
    [Header("可选：点击音效")]
    [SerializeField] private AudioClip clickSound;
    
    void Start()
    {
        // 自动获取按钮并绑定点击事件
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(SwitchScene);
        }
        else
        {
            Debug.LogWarning("没有找到 Button 组件，请手动添加！");
        }
    }
    
    public void SwitchScene()
    {
        // 播放音效
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        
        Debug.Log("正在切换到场景: " + targetSceneName);
        
        // 加载场景
        SceneManager.LoadScene(targetSceneName);
    }
    
    void OnDestroy()
    {
        // 清理事件监听
        Button btn = GetComponent<Button>();
        if (btn != null)
            btn.onClick.RemoveListener(SwitchScene);
    }
}