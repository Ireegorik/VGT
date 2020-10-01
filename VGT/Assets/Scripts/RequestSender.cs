using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using VGTDataStore.Core;
using UnityEngine.Networking;

public class RequestSender : MonoBehaviour
{
    public static dynamic GetAuth(string login,string password)
    {
        dynamic massage = new { userId = "", result = "test" };
        WebRequest request = WebRequest.Create($"https://localhost:44398/api/users/auth/Login={login}&Password={password}");
        request.Credentials = CredentialCache.DefaultCredentials;
        WebResponse response = request.GetResponse();
        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string Json = "";
                while ((Json = reader.ReadLine()) != null)
                {
                    massage = JsonConvert.DeserializeObject(Json);
                }
            }
        }
        return (massage);
    }
    public static void joinLobby(string SessionId,string player)
    {
        WebRequest request = WebRequest.Create($"https://localhost:44398/api/sessions/{SessionId}");
        request.Method = "PATCH";
        request.ContentType = "text/json";
        string Json = JsonConvert.SerializeObject(new  {  PlayerId = player, SeatPlace = 3, PokerPlayerStatus = "WaitingForGame", UserRole = "Player",ChipsForGame = 1000 });
        byte[] byteArray = Encoding.UTF8.GetBytes(Json);
        Stream dataStream = request.GetRequestStream();
        // Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length);
        // Close the Stream object.
        dataStream.Close();
        print(Json);
        WebResponse response = request.GetResponse();
    }
    public static string GetSessionPoker()
    {
        WebRequest request = WebRequest.Create("https://localhost:44398/api/sessions/");
        WebResponse response = request.GetResponse();
        using (Stream dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            return reader.ReadToEnd();
        }
    }
    public static string PostRegister(string login, string password, string passwordRep, string Email)
    {
        if (password == passwordRep)
        {

            WebRequest request = WebRequest.Create("https://localhost:44398/api/users/register/");
            dynamic registerRequest = new  { Login = login, Password = password, Email = Email };
            request.Method = "POST";
            request.ContentType = "text/json";
            string Json = JsonConvert.SerializeObject(registerRequest);
            byte[] byteArray = Encoding.UTF8.GetBytes(Json);
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            WebResponse response = request.GetResponse();
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                return reader.ReadToEnd();
            }
        }
        return "Пароль и подтверждение пароля не совпадают!";
    }
    public static string PostRegisterSession(int Count,string PlayerId, int SeatPlace,string PokerPlayerStatus,string UserRole,int ChipsForGame)
    {

        WebRequest request = WebRequest.Create($"https://localhost:44398/api/sessions/register/{Count}");
        dynamic registerRequest = new { PlayerId = PlayerId, SeatPlace = SeatPlace, PokerPlayerStatus = PokerPlayerStatus, UserRole = UserRole, ChipsForGame = ChipsForGame };
        request.Method = "POST";
        request.ContentType = "text/json";
        string Json = JsonConvert.SerializeObject(registerRequest);
        byte[] byteArray = Encoding.UTF8.GetBytes(Json);
        Stream dataStream = request.GetRequestStream();
        // Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length);
        // Close the Stream object.
        dataStream.Close();
        WebResponse response = request.GetResponse();
        using (dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            return reader.ReadToEnd();
        }
    }
    public static List<PlayerInfo> GetUserSession(string SessionId)
    {
        WebRequest request = WebRequest.Create($"https://localhost:44398/api/sessions/get/{SessionId}");
        WebResponse response = request.GetResponse();
        using (Stream dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            return JsonConvert.DeserializeObject<List<PlayerInfo>>(reader.ReadToEnd());
        }
    }
    //public static void ChangeUsersStatus(Guid SessionId, Guid userId, int status)
    //{
    //    WebRequest request = WebRequest.Create($"https://localhost:44398/api/sessions/SessionId={SessionId.ToString().ToUpper()}&UserId={userId.ToString().ToUpper()}&StatusCode={status}");
    //    request.Method = "PATCH";
    //    //request.Timeout = 100;
    //    request.GetResponse();
    //}
    public static IEnumerator ChangeUsersStatus(Guid SessionId, Guid userId, int status)
    {
        UnityWebRequest uwr = UnityWebRequest.Get($"https://localhost:44398/api/sessions/SessionId={SessionId.ToString().ToUpper()}&UserId={userId.ToString().ToUpper()}&StatusCode={status}");
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
    public class Kek
    {
       public List<string> UsersId { get; set; }
    }
    public static Dictionary<Guid, List<PlayingCards>> GetStart(string SessionId, Kek Users)
    {
        string Json = JsonConvert.SerializeObject(Users);
        WebRequest request = WebRequest.Create($"https://localhost:44398/api/sessions/start/{SessionId}");
        request.Method = "POST";
        request.ContentType = "text/json";
        byte[] byteArray = Encoding.UTF8.GetBytes(Json);
        Stream dataStream = request.GetRequestStream();
        // Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length);
        // Close the Stream object.
        dataStream.Close();
        WebResponse response = request.GetResponse();
        using (dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            return JsonConvert.DeserializeObject<Dictionary<Guid, List<PlayingCards>>>(reader.ReadToEnd());
        }
    }
    public static Dictionary<Guid, List<PlayingCards>> GetCards(string SessionId)
    {
        WebRequest request = WebRequest.Create($"https://localhost:44398/api/sessions/card/{SessionId}");
        
        WebResponse response = request.GetResponse();
        using (Stream dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            return JsonConvert.DeserializeObject<Dictionary<Guid, List<PlayingCards>>>(reader.ReadToEnd());
        }
    }
    public class PlayerInfo
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public int PlayerStatusId { get; set; }
        public int SeatPlace { get; set; }
        public int UserRoleId { get; set; }
        public int StartingChips { get; set; }
        public int NowChips { get; set; }
        public int CardForce { get; set; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
