using UnityEngine;

public class AudioManageer : MonoBehaviour
{

    [SerializeField] AudioSource BGMusic;

    public AudioClip background;

    public static AudioManageer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
     
    }
}