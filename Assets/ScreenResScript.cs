using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResScript : MonoBehaviour
{
    public Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(GetAllResolutionsDropdown());
        DisplayCurrentResolutionDropdown();
    }

    public List<string> GetAllResolutionsDropdown()
    {
        //In the options for selecting your resolution, it is only allowed to add strings.
        //this method converts the list of resolutions to a formatted string for display
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        return options;
    }

    public void DisplayCurrentResolutionDropdown()
    {
        int currentResIndex = 0;
        //goes trough every available resolution and check if the width and height matches the current.
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionindex)
    {
        Resolution res = resolutions[resolutionindex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}