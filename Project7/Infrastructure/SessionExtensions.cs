using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project7.Infrastructure
{
    // applies to the class rather than the instance of the class
    public static class SessionExtensions
    {
        public static void SetJson (this ISession session, string key, object value)
        {
            // stores the info in text as string - allows us to store the whole basket
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
