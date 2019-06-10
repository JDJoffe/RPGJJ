﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonsScript : MonoBehaviour
{

    #region Sounds
    public AudioClip button;
    public AudioSource buttonSource;

    public void PlaySound()
    {
        buttonSource.clip = button;
        buttonSource.Play();
    }
    #endregion

    #region Variables



    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();

    [Header("Num")]

    public int skinIndex, hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;

    [Header("Renderer")]
    public Renderer character;

    [Header("Max Num")]

    public int skinMax, hairMax, mouthMax, eyesMax, armourMax, clothesMax;
    [Header("Character Name")]
    public Text charName;
    public string charName2 = "";
    [Header("Stats")]
    //class enum
    public CharacterClasss characterClass;
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] statsTemp = new int[6];
    public int points = 10;
    public string[] selectedClass = new string[12];
    public int selectedIndex = 0;

    #endregion
    private void Awake()
    {
        charName = GameObject.Find("EnteredName").GetComponent<Text>();
        charName2 = charName.text;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Borborigan", "Bord", "Cloric", "Drooid", "Foightah", "Moonk", "Poloodoin", "Ronger", "Roogeg", "Soresore_ah", "woolak", "Bizard", };

        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for armour_#
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the armour List
            armour.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for clothes_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the clothes List
            clothes.Add(temp);
        }
    }
   
    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        #region Switch Material
        switch (type)
        {
            //case skin
            case "skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number is 1
                matIndex = 1;
                break;

            case "eyes":

                index = eyesIndex;

                max = eyesMax;


                textures = eyes.ToArray();

                matIndex = 2;
                break;

            case "mouth":

                index = mouthIndex;

                max = mouthMax;


                textures = mouth.ToArray();

                matIndex = 3;
                break;

            case "hair":

                index = hairIndex;

                max = hairMax;


                textures = hair.ToArray();

                matIndex = 4;
                break;

            case "armour":

                index = armourIndex;

                max = armourMax;


                textures = armour.ToArray();

                matIndex = 5;
                break;

            case "clothes":

                index = clothesIndex;

                max = clothesMax;


                textures = clothes.ToArray();

                matIndex = 6;
                break;

        }

        #endregion
        #region OutSide Switch
        //index plus equals our direction
        //cap our index to loop back around if is is below 0 or above max take one
        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array
        //create another switch that is goverened by the same string name of our material
        index += dir;


        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;

        #endregion
        #region Set Material Switch
        //case skin
        switch (type)
        {
            case "skin":
                skinIndex = index;
                break;
            case "eyes":
                eyesIndex = index;
                break;
            case "mouth":
                mouthIndex = index;
                break;
            case "hair":
                hairIndex = index;
                break;
            case "clothes":
                clothesIndex = index;
                break;
            case "armour":
                armourIndex = index;
                break;

        }

        #endregion
    }
    public void Save()
    {

    }
    public void Play()
    {
        Save();
        SceneManager.LoadScene(1);
    }
    public void StatAssign()
    {

    }

    void ChooseClass(int className)
    {
        switch (className)
        {
            /// <summary>
            /// remember to change stats of each class 
            /// </summary>
            case 0:
                stats[0] = 15; //strength
                stats[1] = 10; //ew dex
                stats[2] = 10; // constitution
                stats[3] = 10; // wisdom
                stats[4] = 10; //intelligence
                stats[5] = 5; //charisma
                characterClass = CharacterClasss.Borborigan;
                break;
            case 1:
                stats[0] = 5;
                stats[1] = 10;
                stats[2] = 5;
                stats[3] = 10;
                stats[4] = 15;
                stats[5] = 15;
                characterClass = CharacterClasss.Bord;
                break;
            case 2:
                stats[0] = 5;
                stats[1] = 5;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 15;
                stats[5] = 10;
                characterClass = CharacterClasss.Cloric;
                break;
            case 3:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Drooid;
                break;
            case 4:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Foightah;
                break;
            case 5:
                stats[0] = 10;
                stats[1] = 15;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 5;
                stats[5] = 5;
                characterClass = CharacterClasss.Moonk;
                break;
            case 6:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Poloodoin;
                break;
            case 7:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Ronger;
                break;
            case 8:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Roogeg;
                break;
            case 9:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Soresore_ah;
                break;
            case 10:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.woolak;
                break;
            case 11:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Bizard;
                break;

        }
    }
}
public enum CharacterClasss
{
    Borborigan,
    Bord,
    Cloric,
    Drooid,
    Foightah,
    Moonk,
    Poloodoin,
    Ronger,
    Roogeg,
    Soresore_ah,
    woolak,
    Bizard,

}