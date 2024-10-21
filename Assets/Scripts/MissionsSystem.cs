using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsSystem : MonoBehaviour
{

    public List<Mission> missions = new List<Mission>();

    // Start is called before the first frame update
    void Start()
    {
        missions.Add(new PressSpaceMission());

        foreach (var mission in missions)
        {
            mission.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var mission in missions)
        {
            mission.Update();
        }
    }
}
