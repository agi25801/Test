using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;

public class InsertItem : MonoBehaviour {

	public Text Show;
	public InputField nameInput;
	public InputField passwordInput;
	public InputField ageInput;

	// Use this for initialization
	void Start () {

	}

	public void Insert(){
		string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(connectionString);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "Insert into Account (UserName,Password,Age) Values ('" + nameInput.text +"','" + passwordInput.text +"','" + ageInput.text + "');";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();


		reader.Close();reader = null;
		dbcmd.Dispose();dbcmd = null;
		dbconn.Close();dbconn = null;
		Select ();
	}

	public void Select(){
		string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(connectionString);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT * " + "FROM Account";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		Show.text = "";
		while(reader.Read()) {
			string UserName = reader.GetString(1);
			string Password = reader.GetString(2);
			int Age = reader.GetInt32(3);
			Show.text += "" + UserName + " - " + Password + " - " + Age + "\n";
		}
		reader.Close();reader = null;
		dbcmd.Dispose();dbcmd = null;
		dbconn.Close();dbconn = null;
	}
	// Update is called once per frame
	void Update () {

	}
}
