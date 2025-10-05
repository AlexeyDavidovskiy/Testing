using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class RunTest
{
    private GameObject player;
    private PlayerMovement playerMovement;

    [UnityTest]
    public IEnumerator CanMoveAlongZ()
    {
        yield return SceneManager.LoadSceneAsync(0);
        yield return new WaitForFixedUpdate();

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player);
        playerMovement = player.GetComponent<PlayerMovement>();
        Assert.IsNotNull(playerMovement);

        Vector3 startPos = player.transform.position;
        playerMovement.Move(0, 1);
        yield return new WaitForFixedUpdate(); 
        Assert.AreNotEqual(startPos.z, player.transform.position.z, "Character cant move by Z axis");
    }

    [UnityTest]
    public IEnumerator CanMoveAlongX()
    {
        yield return SceneManager.LoadSceneAsync(0);
        yield return new WaitForFixedUpdate();

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player);
        playerMovement = player.GetComponent<PlayerMovement>();
        Assert.IsNotNull(playerMovement);

        Vector3 startPos = player.transform.position;
        playerMovement.Move(1, 0);
        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(startPos.x, player.transform.position.x, "Character cant move by X axis");
    }
}
