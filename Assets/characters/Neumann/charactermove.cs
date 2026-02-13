using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    public float xspeed = 5f;
    public float yspeed = 5f;
    public bool isspace = false;
    Animator animator;
    Transform Tr;
    public List<string> HollyScene = new List<string>();
    string currentSceneName;

    [Header("走路音效")]
    public AudioSource audioSource;          // 音频播放器
    public AudioClip walkSound;             // 走路音效
    public float walkSoundInterval = 0.3f;  // 脚步间隔
    private float walkTimer = 0f;           // 脚步计时器
    private bool isWalking = false;         // 是否正在走路

    void Start()
    {
        Tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        currentSceneName = SceneManager.GetActiveScene().name;
        if (HollyScene.Contains(currentSceneName))
        {
            isspace = true;
            animator.SetBool("isInSpace", true);
        }

        // 如果没有指定AudioSource，自动添加
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        // 设置AudioSource属性
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void moveleft()
    {
        Tr.Translate(-xspeed * Time.deltaTime, 0, 0);
    }

    void moveright()
    {
        Tr.Translate(xspeed * Time.deltaTime, 0, 0);
    }

    void moveup()
    {
        Tr.Translate(0, yspeed * Time.deltaTime, 0);
    }

    void movedown()
    {
        Tr.Translate(0, -yspeed * Time.deltaTime, 0);
    }

    void clear()
    {
        animator.SetBool("isstay", false);
        animator.SetBool("moveleft", false);
        animator.SetBool("moveright", false);
    }

    // 播放脚步音效
    void PlayFootstep()
    {
        // 只在非太空场景播放
        if (!isspace && walkSound != null && audioSource != null)
        {
            audioSource.clip = walkSound;
            audioSource.pitch = Random.Range(0.9f, 1.1f); // 随机音调，避免重复感
            audioSource.volume = 0.5f; // 音量
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        clear();

        // 检查是否在移动
        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);
        bool isMoving = isMovingLeft || isMovingRight;

        // 太空中的上下移动也算移动
        if (isspace)
        {
            isMoving = isMoving || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
        }

        // 处理移动和动画
        if (isMovingLeft)
        {
            animator.SetBool("moveleft", true);
            moveleft();
        }
        else if (isMovingRight)
        {
            animator.SetBool("moveright", true);
            moveright();
        }
        else
        {
            animator.SetBool("isstay", true);
        }

        if (isspace)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveup();
            }
            if (Input.GetKey(KeyCode.S))
            {
                movedown();
            }
        }

        // ========== 走路音效逻辑 ==========
        // 只在非太空场景且正在移动时播放脚步
        if (!isspace && isMoving)
        {
            walkTimer += Time.deltaTime;

            // 每隔walkSoundInterval秒播放一次脚步
            if (walkTimer >= walkSoundInterval)
            {
                PlayFootstep();
                walkTimer = 0f;
            }

            isWalking = true;
        }
        else
        {
            // 停止移动时重置计时器
            walkTimer = 0f;
            isWalking = false;
        }
    }
}