using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class SqlFunctions : MonoBehaviour
{
    public string ReadData(string tableName, int i, int j)
    {
        string connection = "URI=file:" + Application.dataPath + "/DB/dataBase.db";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        string strCommand = "SELECT * FROM " + tableName; 
        dbcmd.CommandText = strCommand;
        IDataReader reader = dbcmd.ExecuteReader();
        for (int ii = 0; ii < i; ii++) reader.Read();
        string output = reader[j].ToString();
        dbcon.Close();
        return output;
    }

    public bool AddData(string tableName, int j, string newData)
    {
        string connection = "URI=file:" + Application.dataPath + "/DB/dataBase.db";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        string strCommand = "SELECT * FROM " + tableName;
        dbcmd.CommandText = strCommand;
        IDataReader reader = dbcmd.ExecuteReader();
        string columnName = reader.GetName(j-1);
        reader.Close();
        strCommand = "INSERT INTO " +  tableName + " ("+ columnName +") VALUES ('" + newData+ "')";
        dbcmd.CommandText = strCommand;
        dbcmd.ExecuteNonQuery();
        dbcon.Close();
        return true;
    }

    public bool UpdateData(string tableName, int i, int j, string newData)
    {
        string connection = "URI=file:" + Application.dataPath + "/DB/dataBase.db";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        string strCommand = "SELECT * FROM " + tableName;
        dbcmd.CommandText = strCommand;
        IDataReader reader = dbcmd.ExecuteReader();
        string columnName = reader.GetName(j-1);
        reader.Close();
        strCommand = "UPDATE " + tableName + " SET " + columnName + "= '"+ newData +"' WHERE id= '" + i.ToString() +"'";
        dbcmd.CommandText = strCommand;
        dbcmd.ExecuteNonQuery();
        dbcon.Close();
        return true;
    }

    public bool DeleteData(string tableName, int i, int j) 
    {
        string connection = "URI=file:" + Application.dataPath + "/DB/dataBase.db";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        string strCommand = "SELECT * FROM " + tableName;
        dbcmd.CommandText = strCommand;
        IDataReader reader = dbcmd.ExecuteReader();
        string columnName = reader.GetName(j - 1);
        reader.Close();
        strCommand = "UPDATE " + tableName + " SET " + columnName + "= NULL WHERE id= '" + i.ToString() + "'";
        dbcmd.CommandText = strCommand;
        dbcmd.ExecuteNonQuery();
        dbcon.Close();
        return true;
    }

    public bool RemoveRow(string tableName, int i)
    {
        string connection = "URI=file:" + Application.dataPath + "/DB/dataBase.db";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        string strCommand = "DELETE FROM " + tableName + " WHERE id= '" + i.ToString() + "'";
        dbcmd.CommandText = strCommand;
        dbcmd.ExecuteNonQuery();
        dbcon.Close();
        return true;
    }
}
