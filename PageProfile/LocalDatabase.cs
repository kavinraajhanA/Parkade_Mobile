using PageProfile.BO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageProfile
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }

    public class LocalDatabase
    {
        string databasepath;
        SQLiteConnection database;
        public bool Status = false;
        UserProfileBO userProfileBO;
        LLProfileBO lLProfileBO;

        public LocalDatabase()
        {
            databasepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SQLiteCRUD.db3";
            database = new SQLiteConnection(databasepath);
        }

        public bool TableExists<T>(SQLiteConnection DatabasePath)
        {
            try
            {
                TableMapping map = new TableMapping(typeof(T));
                object[] ps = new object[0];

                Int32 tableCount = DatabasePath.Query(map, "SELECT * FROM sqlite_master WHERE type = 'table' AND name = '" + map.TableName + "'", ps).Count;
                if (tableCount == 0)
                {
                    return false;
                }
                else if (tableCount == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("More than one table by the name of " + map.TableName + " exists in the database.", null);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveUserProfile(UserProfileBO userProfileBO)
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<UserProfileBO>(database))
                    {
                        database.Execute("DROP TABLE IF EXISTS " + "UserProfileBO");
                    }
                    database.CreateTable<UserProfileBO>();
                    Status = database.Insert(userProfileBO) == 1;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "SaveUserProfile() : No Input Parameters");
            }
            return Status;
        }

        public UserProfileBO GetUserProfile()
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<UserProfileBO>(database))
                        return database.Table<UserProfileBO>().FirstOrDefault();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "GetUserProfile() : No Input Parameters");
            }
            return userProfileBO;
        }

        public bool UpdateStudentProfile(UserProfileBO userProfileBO)
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<UserProfileBO>(database))
                    {
                        Status = database.Update(userProfileBO) == 1;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "SaveUserAddress() : No Input Parameters");
            }
            return Status;
        }

        public bool DeleteStudentDetails()
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<UserProfileBO>(database))
                    {
                        Status = database.Delete(userProfileBO) == 1;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "SaveUserAddress() : No Input Parameters");
            }
            return Status;
        }

        public bool LLSaveUserProfile(LLProfileBO lLProfileBO)
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<LLProfileBO>(database))
                    {
                        database.Execute("DROP TABLE IF EXISTS " + "UserProfileBO");
                    }
                    database.CreateTable<LLProfileBO>();
                    Status = database.Insert(lLProfileBO) == 1;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "SaveUserProfile() : No Input Parameters");
            }
            return Status;
        }

        public LLProfileBO LLGetUserProfile()
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<LLProfileBO>(database))
                        return database.Table<LLProfileBO>().FirstOrDefault();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "GetUserProfile() : No Input Parameters");
            }
            return lLProfileBO;
        }

        public bool LLUpdateStudentProfile(LLProfileBO lLProfileBO)
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<LLProfileBO>(database))
                    {
                        Status = database.Update(lLProfileBO) == 1;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "SaveUserAddress() : No Input Parameters");
            }
            return Status;
        }

        public bool LLDeleteStudentDetails()
        {
            try
            {
                using (database = new SQLiteConnection(databasepath))
                {
                    if (TableExists<LLProfileBO>(database))
                    {
                        Status = database.Delete(lLProfileBO) == 1;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex.ToString(), "SaveUserAddress() : No Input Parameters");
            }
            return Status;
        }
    }
}
