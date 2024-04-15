using UnityEngine;
using UnityEngine.UI;
// This is needed due to a conflict in the namespace.
using Image = UnityEngine.UI.Image;

public class Cat : MonoBehaviour
{
    // Arrays with cat images and cat meows
    public Sprite[] imagesSource = new Sprite[3];
    public AudioClip[] audiosSource = new AudioClip[3];
    Image catImage;
    AudioSource catAudio;
    private int randomCat;

    void Start() {
        // Getting references to the Image and AudioSource
        catImage = GetComponent<Image>();
        catAudio = GetComponent<AudioSource>();
        // Drawing a cat
        randomCat = Random.Range(0,3);
        // Change sprite image and audio (random number between 0 and 2)
        catImage.sprite = imagesSource[randomCat];
        catAudio.clip = audiosSource[randomCat];
        catAudio.Play();
    }
}
