﻿using System;
using System.Collections.Generic;
using FriendEditor.Models;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace FriendEditor.Services
{
    public class SqliteDataProvider : IDataProvider
    {

        #region Constants

        public const string FileName = "Friends.sb";

        #endregion Constants



        #region Constructors

        public SqliteDataProvider()
        {
            DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = DataPath;
            ConnectionString = builder.ToString();

            if (!File.Exists(DataPath))
            {
                SQLiteConnection.CreateFile(DataPath);

                string sqlCreateTable = @"CREATE TABLE Friend(
                                            Id varchar(40) Primary Key,
                                            Name varchar(20) Not Null,
                                            Email varchar(20),
                                            IsDeveloper bool,
                                            BirthDate date)";

                ExeNonQueryCommand(sqlCreateTable);
            }
        }

        #endregion Constructors




        #region Properties

        /// <summary>
        /// The full data path of the sqlite database file
        /// </summary>
        public string DataPath { get; private set; }

        /// <summary>
        /// The connection string
        /// </summary>
        protected string ConnectionString { get; set; }

        #endregion Properties




        #region Methods

        public bool Delete(IFriend friend)
        {
            throw new NotImplementedException();
        }

        public List<IFriend> GetAllFriends()
        {
            throw new NotImplementedException();
        }

        public IFriend GetFriendById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(IFriend friend)
        {
            throw new NotImplementedException();
        }

        public bool Update(IFriend friend)
        {
            throw new NotImplementedException();
        }

        private bool ExeNonQueryCommand(string sqlCommandText)
        {
            bool isSuccess = false;

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(sqlCommandText, conn))
                {
                    isSuccess = cmd.ExecuteNonQuery() > 0 ? true : false;
                }

            }

            return isSuccess;
        }

        #endregion Methods
    }
}
