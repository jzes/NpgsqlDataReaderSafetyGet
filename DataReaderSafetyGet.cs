using System;
using Npgsql;

namespace NpgsqlDataReaderSafety
{
    public static class DataReaderSafetyGet
    {
        public static string GetSafetyString(this NpgsqlDataReader data, int indexField){
            if(data.IsDBNull(indexField)){
                return null;
            }
            return data.GetString(indexField);
        }
        public static int GetSafetyInt32(this NpgsqlDataReader data, int indexField){
            if(data.IsDBNull(indexField)){
                return 0;
            }
            return data.GetInt32(indexField);
        }
        public static double GetSafetyDouble(this NpgsqlDataReader data, int indexField){
            if(data.IsDBNull(indexField)){
                return 0.0;
            }
            return data.GetDouble(indexField);
        }
        public static DateTime GetSafetyDateTime(this NpgsqlDataReader data, int indexField){
            if(data.IsDBNull(indexField)){
                return new DateTime();
            }
            return data.GetDateTime(indexField);
        }
        public static string GetSafetyDoubleAsString(this NpgsqlDataReader data, int indexField){
            if(data.IsDBNull(indexField)){
                return @"0.0";
            }
            return data.GetDouble(indexField).ToString();
        }

    }
}