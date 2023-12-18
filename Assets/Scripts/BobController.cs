
using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobController : MonoBehaviour, IPlayer       
{
    public event Action OnKilled;
    public event Action OnLevelCompleted;
    

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _spriteBob;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _dampingSpeed;

    public PlayerData playerData = new PlayerData(); // ссылка на обьект
    
    public void MakeDamage() 
    {
        Debug.Log("Dead");
        _rb.AddForce(Vector2.up * _jumpForce);
        GetComponent<Collider2D>().isTrigger = true;
        OnKilled?.Invoke();
        enabled = false;
            
    }
        
    void Update()
    {
        CharacterMovement();

        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadData();
        }
    }
    private void OnEnable() 
    {
        LoadData();
    }
    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x, _camera.transform.position.y, -10), transform.position, Time.deltaTime * _dampingSpeed);
    }

    private void CharacterMovement()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _spriteBob.flipX = inputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(_jumpButton))
        {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    } 

   
    public void SaveData()
    {
        playerData = new PlayerData(SceneManager.GetActiveScene().buildIndex, transform.position, gameObject.name); // что сохраняем

        string json = JsonUtility.ToJson(playerData);

        PlayerPrefs.SetString("JSON", json);

        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json"); // путь куда хотим сохранить данные Application.persistentDataPath (сохраняет в папке игры на компе, streamingAssetsPath - сохраняет в игре), и название файла с расширением "GAMEDATA.json". Path.Combine - обьединяет пути

        Debug.Log(path);


        File.WriteAllText(path, json);

        Debug.Log("New position saved");
    }

    public void LoadData()
    {        
        
        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json");
        if (File.Exists(path)) 
        {
            playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));

            transform.position = playerData.Position;

            Debug.Log("Old position loaded name of: " + playerData.Name);
        }
              
    }
}

[Serializable]
public class PlayerData
{
    public int sceneID;
    public Vector3 Position;
    public string Name;
    internal int SceneID;

    public PlayerData()
    {
    }

    public PlayerData(int sceneID, Vector3 position, string name)
    {
        this.sceneID = sceneID;
        Position = position;
        Name = name;
    }
}
    

  
