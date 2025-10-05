using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class JumpTest
{
    private GameObject player;
    private PlayerMovement playerMovement;

    [UnityTest]
    public IEnumerator CannotDoubleJump()
    {
        yield return SceneManager.LoadSceneAsync(0);
        yield return null;

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player);
        playerMovement = player.GetComponent<PlayerMovement>();
        Assert.IsNotNull(playerMovement);

        playerMovement.isGrounded = true;
        playerMovement.Jump();
        yield return null;

        playerMovement.isGrounded = false;
        playerMovement.Jump();
        yield return null;

        float velocityY = playerMovement.velocity.y;
        Assert.LessOrEqual(velocityY, 0.1f, "Character can make double jump");
    }

    [UnityTest]
    public IEnumerator CanMoveWhileJumping()
    {
        yield return SceneManager.LoadSceneAsync(0);
        yield return null;

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player);
        playerMovement = player.GetComponent<PlayerMovement>();
        Assert.IsNotNull(playerMovement);

        playerMovement.isGrounded = true;
        playerMovement.Jump();
        yield return null;

        Vector3 startPos = player.transform.position;
        playerMovement.Move(1, 1);
        yield return null;

        Assert.AreNotEqual(startPos.x, player.transform.position.x, "Character cant move by X axis till jumping");
        Assert.AreNotEqual(startPos.z, player.transform.position.z, "Character cant move by Z axis till jumping");
    }
}
