using UnityEngine;
using System;

public class LoadTextFiles{
    public static string[] Load(string pathToAsset, char ch){
        string langFolder;
        if (LocalizationManager.localizationIndex == 0)langFolder = "RU/";
        else langFolder = "EN/";
        //langFolder = "RU/";
        char[] sep = new char[] {ch};
        string newPath = string.Concat(langFolder,pathToAsset);
        TextAsset asset = Resources.Load(newPath) as TextAsset;
        string[] parts = asset.text.Split(sep);
        for (int i = 0; i < parts.Length; i++){
            parts[i] = parts[i].Trim();
        }
        return parts;
    }
}

