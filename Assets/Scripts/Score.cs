using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class Score : MonoBehaviour
{
    private PlayerMovement player;
    public string level;

    public Text crystals;
    public Text goldCoins;
    public Text keys;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        crystals.text = "Crystals: " + player.crystals;
        goldCoins.text = "Gold Coins: " + player.goldCoins;
        keys.text = "Keys: " + player.keys;
        PlayerPrefs.SetInt(level, Math.Max(player.crystals, PlayerPrefs.GetInt(level, 0))); // take the higher score
    }
}