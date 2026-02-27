using System.IO;
using UnityEngine;

public class ASCII : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;
    public GameObject goal;

    public string fileLocation;

    string fullPath;

    private int currentLevel = 0;

    private GameObject loadedLevel;

    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
        }
        get
        {
            return currentLevel;
        }
    }

    public int XOffset = 0;
    public int YOffset = 0;
    
    public static ASCII instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        fullPath = Application.dataPath + "/" + fileLocation;
        
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        Destroy(loadedLevel);
        loadedLevel = new GameObject("Level" + currentLevel);

        string fullPath = this.fullPath.Replace("<num>", currentLevel + "");
        
        string[] lines = File.ReadAllLines(fullPath);

        foreach (string line in lines)
        {
            Debug.Log(line);

            int lengthOfLine = line.Length / 2;

            if (lengthOfLine > XOffset)
            {
                XOffset = lengthOfLine;
            }
        }

        YOffset = lines.Length / 2;

        for (int i = 0; i < lines.Length; i++)
        {
            string currentLineFromFile = lines[i];

            for (int x = 0; x < currentLineFromFile.Length; x++)
            {
                char Character = currentLineFromFile[x];
                
                GameObject newObject = null;

                switch (Character)
                {
                    case 'W':
                        newObject = Instantiate(wall);
                        break;
                    case 'P':
                        newObject = Instantiate(player);
                        break;
                    case 'G':
                        newObject = Instantiate(goal);
                        break;
                    default:
                        break;
                }
                
                if (newObject != null)
                {
                    newObject.transform.position = new Vector2(-XOffset+x, YOffset-i);
                    newObject.transform.SetParent(loadedLevel.transform);
                }
            }

            

            
        }
    }
}
