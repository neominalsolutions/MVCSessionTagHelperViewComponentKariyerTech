using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.SessionExtension
{
    public static class SessionExtension
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            string jsonString = session.GetString(key);

            if(string.IsNullOrEmpty(jsonString))
            {
                throw new Exception("Session Bulunamadı");
            }

            var result = JsonSerializer.Deserialize<T>(jsonString);

            return result;
        }

        public static void SetObject<T>(this ISession session,string key, T value)
        {
            string jsonString = JsonSerializer.Serialize<T>(value);

            session.SetString(key, jsonString);
        }
    }
}
