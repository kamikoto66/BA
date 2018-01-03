using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine;

public class AnimalDataTable : GenericTable<AnimalDataDescriptor> {

    public AnimalDataTable(string path) : base(path)
    {

    }
	
}
