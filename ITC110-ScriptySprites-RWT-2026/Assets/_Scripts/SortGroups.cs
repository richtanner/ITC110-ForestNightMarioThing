using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortGroups : MonoBehaviour
{
    [SerializeField] string[] groupNames;

    

    //private void FillArray()
    //{
    //    // fill with some data
    //    for (int i = 0; i < groupNames.Length; i++)
    //    {
    //        groupNames[i] = "Item " + i.ToString();
    //    }
    //    System.Array.Sort(groupNames, RandomSort);
    //}

    //// this function just returns a number in the range -1 to +1
    //// and is used by Array.Sort to 'shuffle' the array
    //int RandomSort(string a, string b)
    //{
    //    return UnityEngine.Random.Range(-1, 2);
    //}



   
    
    public void SortThemGroups()
    {
        // Say we have listOfGroups filled with things.
        var listOfGroups = new List<string>()
        {
            "[TEAM NAME]",
            "2G1B",
            "404 Not Found",
            "adm",
            "bit by bit",
            "Mordue",
            "Silly Squad",
            "Team Underdog",
            "TeamName4",
            "The Dawgs"
        };
        // Randomly Order it by Guid..
        listOfGroups = listOfGroups.OrderBy(i => Guid.NewGuid()).ToList();
        // It's now shuffled.

        for (int group = 0; group < listOfGroups.Count; group++)
        {
            // every other group gets 315/314
            if (group % 2 == 0) // Is even, because something divided by two without remainder is even, i.e 4/2 = 2, remainder 0
            {
                Debug.Log("Group " + listOfGroups[group].ToString() + " is in MBB-314");
            }
            else
            {
                Debug.Log("Group " + listOfGroups[group].ToString() + " is in MBB-315");
            }
        }
    }
}
