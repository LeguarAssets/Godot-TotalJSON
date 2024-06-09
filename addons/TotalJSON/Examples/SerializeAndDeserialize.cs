//    Example - Serialize and Deserialize


using Godot;
using Leguar.TotalJSON;

namespace Leguar.TotalJSON.Examples {

	public partial class SerializeAndDeserialize : Node {

		public override void _Ready() {

			Log("---> Running SerializePlayerObjectToString()");
			string jsonString = SerializePlayerObjectToString();

			Log("---> Running DeserializeStringToPlayerObject()");
			DeserializeStringToPlayerObject(jsonString);

			Log("---> Running SerializeAndDeserializeGodotStructs()");
			SerializeAndDeserializeGodotStructs();
	
		}

		private string SerializePlayerObjectToString() {

			// Create example player (c# object)
			ExamplePlayerObject examplePlayer = new ExamplePlayerObject();
			examplePlayer.SetTestValues();

			// Print out current player data
			Log("Original player: " + examplePlayer);

			// Serialize ExamplePlayerObject to JSON object
			JSON json = JSON.Serialize(examplePlayer);

			// Output JSON
			string jsonString = json.CreateString();
			Log("Player as JSON for storing or transferring: " + jsonString);

			// Content of 'jsonString' will be:
			// {"name":"Test player","position":{"X":1.0,"Y":2.0,"Z":3.0},
			// "playerColor":{"R":0.0,"G":1.0,"B":0.1,"A":0.9},"score":42000,
			// "levelTimes":[31.41,42.0,12.3],"playerBackPack":[{"name":"axe","uses":99},{"name":"coin","uses":1}],
			// "charClass":{"value__":1},"mapStates":{"cave":78,"lake":42},"alignment":null}
			return jsonString;
	
		}

		private void DeserializeStringToPlayerObject(string jsonString) {

			// Create JSON object from string
			JSON json = JSON.ParseString(jsonString);

			// Re-create ExamplePlayerObject from JSON
			ExamplePlayerObject restoredPlayer = json.Deserialize<ExamplePlayerObject>();

			// Print out
			Log("Restored player: " + restoredPlayer);

		}

		private void SerializeAndDeserializeGodotStructs() {
			
			// Create some basic Godot structs
			Vector3 v3 = new Vector3(3f, 14f, 15f);
			Quaternion q = new Quaternion(3f, 3f, 3f, 4f);
			Color c = new Color(0.5f, 1f, 0f, 0.75f);
			
			// Serialize them to JSON and store under one JSON object
			JSON jsonObject = new JSON();
			jsonObject.Add("v3", JSON.Serialize(v3));
			jsonObject.Add("q", JSON.Serialize(q));
			jsonObject.Add("c", JSON.Serialize(c));

			// Print out
			Log("Structs stored to JSON: " + jsonObject.CreateString());

			// Recreate (deserialize) structs from JSON
			Vector3 vector3recreated = jsonObject.GetJSON("v3").Deserialize<Vector3>();
			Quaternion quaternionRecreated = jsonObject.GetJSON("q").Deserialize<Quaternion>();
			Color colorRecreated = jsonObject.GetJSON("c").Deserialize<Color>();

			// Print out
			Log("Vector3 recreated: " + vector3recreated);
			Log("Quaternion recreated: " + quaternionRecreated);
			Log("Color recreated: " + colorRecreated);

		}

		private static void Log(object str) {
			GD.Print("[SerializeAndDeserialize] " + str);
		}
		
	}
	
}
