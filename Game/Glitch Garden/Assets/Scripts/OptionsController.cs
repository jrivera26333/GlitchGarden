using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = .8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultdifficulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume(); //Grabs master volume pref float
        difficultySlider.value = PlayerPrefsController.GetDifficulty(); //Grabs difficulty pref float value
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>(); //Accessing our MusicPlayer to set the slider to match the volume of the game

        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value); //The value at which the current slider is set
        }
        else Debug.LogWarning("No music player found did you start from splash screen?");
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value); //Set our prefs to our value
        PlayerPrefsController.SetDifficulty(difficultySlider.value); //Set our prefs to our value
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume; //Since we are always updating the volume all we have to do is change the volumeSlider.value to our default value
        difficultySlider.value = defaultdifficulty; //Since we are always updating the volume all we have to do is change the volumeSlider.value to our default value
    }
}
