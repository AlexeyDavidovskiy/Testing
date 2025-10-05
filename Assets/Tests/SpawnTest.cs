using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnTest
{
    [UnityTest]
    public IEnumerator PlayerSpawnTest()
    {
        GameObject prefab = new GameObject("Player");
        prefab.AddComponent<CharacterController>();
        SpawnController spawner = new GameObject("Spawner").AddComponent<SpawnController>();
        spawner.GetType().GetField("prefab", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(spawner, prefab);

        spawner.Invoke("Start", 0f);

        yield return new WaitForSeconds(5);

        GameObject spawnedPlayer = GameObject.Find("Player(Clone)");
        UnityEngine.Assertions.Assert.IsNotNull(spawnedPlayer, "Character is not appear at the scene");

    }
}
