using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Chocolate.Business.Helpers
{
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-5.0#session-state
    public static class SessionHelper
    {
        //Adds an item to the Session
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //Get an Item from the session
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        //Gets all items from the session
        public static IEnumerable<T> GetItems<T>(this ISession session)
        {
            if (session != null)
            {
                foreach (var key in session.Keys)
                {
                    yield return JsonConvert.DeserializeObject<T>(session.GetString(key));
                }
            }
        }
    }
}