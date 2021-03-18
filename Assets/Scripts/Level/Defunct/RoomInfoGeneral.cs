using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The only reason I'm not using this to keep track of the room stuff is because I can't figure out how in the hell to access a script that
 * inherits from a class. In hindsight it sorta makes sense that I can't but it would be convinient. This *would* work if it were an interface
 * but then there'd be no way to have a general methods but at that point what is the point? I'd rather just put the stuff in by hand and have the
 * level logic sort it out every new level. BUT! I will keep this here just in case I want to come back to it.
 **/


public class RoomInfoGeneral : MonoBehaviour
{
    //Imagine this is an interface but it's not because it has variables
    //Just some notes about this class since this doesn't *really* have a purpose other than abstraction
    //roomEnemyPool will be full of every single enemy in the game on load
    //spawnlocation and door will have the prefabs for their corresponding names
    //roomSpawnLocations, exit, and entrance are all variables to pass to the Level Logic just to make things easier, they're set by the actual
    public List<GameObject> roomEnemyPool, roomSpawnLocations;
    public GameObject spawnlocation, door, exit, entrance;

    public void Start()
    {
        CreateSpawnLocations();
        CullEnemyPool();

    }

    public virtual void CreateSpawnLocations()
    {
        //Literally just call the MakeSpawnLocation method for every SpawnLocation you want
        //Hypothetically I can make this better but I am lazy and low on time ¯\_(ツ)_/¯
    }

    public void MakeSpawnLocation(float x, float y, float width, float height)
    {
        GameObject temp;
        temp = Instantiate(spawnlocation, new Vector2(x, y), Quaternion.identity);
        temp.transform.localScale = new Vector3(width, height, 1);
        roomSpawnLocations.Add(temp);
    }

    public virtual void CullEnemyPool()
    {
        //The enemy pool list should be full of every single enemy on load so this is more to get rid of 
        //any that we don't want in a specific room
    }

    public virtual void SetEntraceAndExit()
    {
        //Uhhhhhh
    }
}
