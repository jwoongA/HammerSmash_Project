using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ItemSound : MonoBehaviour
{
    public static ItemSound Instance;

    public AudioClip magnetClip;
    public AudioClip smallHealClip;
    public AudioClip largeHealClip;
    public AudioClip fastRunClip;
    public AudioClip hammerTimeClip;
    public AudioClip coinClip;

    private void Awake()
    {
        // ÀÌ¹Ì Á¸ÀçÇÏ¸é ÆÄ±«
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // ½Ì±ÛÅæ ¼³Á¤
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySound(Item.ItemType itemType)
    {
        AudioClip clip = GetClip(itemType);
        if (clip != null)
        {
            GameObject soundObj = new GameObject("ItemSound");
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = clip;
            source.Play();
            source.volume = 0.4f;
            Destroy(soundObj, clip.length);
        }
    }

    private AudioClip GetClip(Item.ItemType itemType)
    {
        return itemType switch
        {
            Item.ItemType.Magnet => magnetClip,
            Item.ItemType.SmallHeal => smallHealClip,
            Item.ItemType.LargeHeal => largeHealClip,
            Item.ItemType.FastRun => fastRunClip,
            Item.ItemType.HammerTime => hammerTimeClip,
            Item.ItemType.Coin => coinClip,
            _ => null
        };
    }
}
