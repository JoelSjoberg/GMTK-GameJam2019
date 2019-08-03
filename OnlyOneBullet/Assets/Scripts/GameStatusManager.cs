using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatusManager
{
    public static int points = 0;

    // Spawn a new Enemy every 3 second from every spawnpoint, with some random occúrence of course. should decrease as point increase
    public static float spawnRate = 3f;

}
