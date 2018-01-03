using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableLocator : MonoBehaviour {

    public static FurnitureTable furnitureTable { get; private set; }
    public static BuffTable buffTable { get; private set; }
    public static UserDataTable userDataTable { get; private set; }
    public static CarTable carTable { get; private set; }
    public static ProbsTable probsTable { get; private set; }

    public static MapDataTable mapDataTable { get; private set; }
    public static AnimalDataTable animalDataTable { get; private set; }
 

    static TableLocator()
    {
        furnitureTable = new FurnitureTable("Table/Furniture");
        buffTable = new BuffTable("Table/Buff");
        userDataTable = new UserDataTable("Table/UserData");
        carTable = new CarTable("Table/CarData");
        probsTable = new ProbsTable("Table/Probs");
        mapDataTable = new MapDataTable("Table/MapList");
        animalDataTable = new AnimalDataTable("Table/AnimalData");
    }
}
