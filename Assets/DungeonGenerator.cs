using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    ArrayList previousOverlapTriggers = new ArrayList();


    public static int floorSize = 20;
    public GameObject[] Rooms;
    
    bool touching = false;
    ArrayList optionalDoors = new ArrayList();
    private int childAmount = 0;
    private int randomDoorLocation = 0;
    private int randomRoomNumber = 0;
    private int randomRoomRotation = 0;
    GameObject[] InstantiatedRooms = new GameObject[floorSize];

    void Start()
    {
        
        GameObject previousInstantiatedRoom = null;

        for (int i = 0; i < floorSize; i++)
        {
           
            randomRoomNumber = Random.Range(0, 3);
            randomRoomRotation = Random.Range(0, 4);
            



            if (i == 0)
            {
                InstantiatedRooms[i] = Instantiate(Rooms[randomRoomNumber], new Vector3(0, 0, 10), Quaternion.Euler(0, 0, 90 * randomRoomRotation));
            }
            else
            {
                GameObject newRoom = Rooms[randomRoomNumber];
                newRoom.transform.rotation = Quaternion.Euler(0f, 0f, 90 * randomRoomRotation);
                int newDoorAmount = newRoom.transform.childCount;
                int randomNewDoorNumber = Random.Range(0, newDoorAmount);

                Transform newDoor = newRoom.transform.GetChild(randomNewDoorNumber);

                float newRoomXDistance = newRoom.transform.position.x - newDoor.position.x;
                float newRoomYDistance = newRoom.transform.position.y - newDoor.position.y;





               
                randomDoorLocation = Random.Range(0, optionalDoors.Count);
           
                Transform previousDoor =  (Transform) optionalDoors[randomDoorLocation];

                InstantiatedRooms[i] = Instantiate(Rooms[randomRoomNumber], new Vector3(previousDoor.position.x + newRoomXDistance, previousDoor.position.y + newRoomYDistance, 10f), Quaternion.Euler(0f, 0f, 90 * randomRoomRotation)); //maybe this shouldnt have a random room rotation

                    
            }

            childAmount = InstantiatedRooms[i].transform.childCount;
            

            
            for (int p = 0; p < (childAmount); p++)
            {
               
                optionalDoors.Add(InstantiatedRooms[i].transform.GetChild(p));
            }
            



           
            if (i > 0)
            {
                Collider2D[] rooms = InstantiatedRooms[i].GetComponents<Collider2D>();

                
                Collider2D[] roomsPrevious = previousInstantiatedRoom.GetComponents<Collider2D>();

                for (int v = 0; v < roomsPrevious.Length; v++)
                {
                    previousOverlapTriggers.Add(roomsPrevious[v]);
                }

                for (int j = 0; j < rooms.Length; j++)
                {
                    if (rooms[j].isTrigger)
                    {
                        for (int k = 0; k < (previousOverlapTriggers.Count); k++)
                        {
                            Collider2D overlaps = (Collider2D)previousOverlapTriggers[k];
                            if (rooms[j].bounds.Intersects(overlaps.bounds) && overlaps.isTrigger)
                            {
                                Debug.Log("rooms intersect");
                                touching = true;
                            }
                        }

                    }
                }
                    

                if (touching)
                {
                    int temp1 = previousOverlapTriggers.Count;
                    int temp2 = roomsPrevious.Length;
                    for (int e = 0; e < temp2; e++)
                    {
                        previousOverlapTriggers.RemoveAt(temp1 - 1 - e);
                    }


                    int temp3 = optionalDoors.Count;
                    for (int q = 0; q < childAmount; q++)
                    {
                        
                        optionalDoors.RemoveAt(temp3 - 1 - q);
                    }

                    Destroy(InstantiatedRooms[i]);
                    i--;
                    touching = false;
                    Debug.Log("destroyed a room");
                }

                else
                {
                    previousInstantiatedRoom = InstantiatedRooms[i];
                }
            }


            else
            {
                previousInstantiatedRoom = InstantiatedRooms[i];
            }
        }

        for (int c = 0; c < InstantiatedRooms.Length; c++)
        {
            //InstantiatedRooms[c].gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }
    }

    
    
    
}
