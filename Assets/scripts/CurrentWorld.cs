using System;
using System.Collections.Generic;
using UnityEngine;

public enum World
{
    SPACE_MOUNTAINS,
    SPACE_EMPTY,
    CLOUDS,
    WATER,

}

public static class CurrentWorld
{
    public static World world;

    public static void SetWorld(World world)
    {
        CurrentWorld.world = world;
    }
}
