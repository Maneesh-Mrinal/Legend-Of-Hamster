using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D _rg;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpSpeed = 2f;
    public Animator _anim;
    public Animator _animZoom;
    CapsuleCollider2D capcol;
    public GameObject gun;
    public GameObject ramboPicture;
    public int playerHealth = 100;
    public int collectedSeedCount = 0;
    public Slider HealthBar;
    public TMP_Text NumberOfSeeds;
    public bool isGunEnabled = false;
    public bool isGunCollected = false;
    public int spiderDamage = 10;
    public AudioSource contraAudio;
    public AudioSource hitAudio;

    void Start()
    {
        contraAudio = GetComponent<AudioSource>();
        hitAudio = GetComponent<AudioSource>();
        _rg = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        capcol = GetComponent<CapsuleCollider2D>();
        if (SceneManager.GetActiveScene().name == "Level Attic" && SceneManager.GetActiveScene().name == "Level Kitchen")
        {
            LoadPlayer();
        }

    }

    void Update()
    {
        Run();
        FlipSprite();
        HealthBar.value = playerHealth;
        checkHealth();
        UpdateSeedCount();
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        collectedSeedCount = data.seedCount;
        playerHealth = data.playHealth;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (!capcol.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            _rg.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    /*void ClimbLadder(InputValue value)
    {
        if (!capcol.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            Vector2 playerVelocity = new Vector2(_rg.velocity.x, moveInput.y * moveSpeed);
        }
    }*/

    public void checkHealth()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadSceneAsync("Game Over");
        }
    }
    public void UpdateSeedCount()
    {
        NumberOfSeeds.text = collectedSeedCount.ToString();
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, _rg.velocity.y);
        _rg.velocity = playerVelocity;
        bool PlayerHasHorizontalSpeed = Mathf.Abs(_rg.velocity.x) > Mathf.Epsilon;
        _anim.SetBool("isWalking", PlayerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool PlayerHasHorizontalSpeed = Mathf.Abs(_rg.velocity.x) > Mathf.Epsilon;
        if (PlayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rg.velocity.x) * 0.5f, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RamboPower") == true)
        {
            Destroy(other.gameObject);
            ramboPicture.SetActive(true);
            gun.SetActive(true);
            isGunCollected = true;
            isGunEnabled = true;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            //audioSource.Play();
=======
            _anim.SetBool("isRambo", true);
>>>>>>> Stashed changes
=======
            contraAudio.Play();
>>>>>>> Stashed changes
            StartCoroutine(WaitForTwoSeconds());
            ramboPicture.SetActive(false);
        }
        if (other.CompareTag("Damage Objects"))
        {
            playerHealth -= other.gameObject.GetComponent<MoveProjectile>().damageDealt;
            hitAudio.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Seed"))
        {
            Destroy(other.gameObject);
            collectedSeedCount++;
        }
        if (other.CompareTag("Spider"))
        {
            playerHealth -= spiderDamage;
        }
    }
    IEnumerator WaitForTwoSeconds()
    {
        yield return new WaitForSeconds(2f);
    }
}
