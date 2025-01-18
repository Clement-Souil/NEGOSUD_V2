using NegosudLibrary.DTO;
using NegosudLibrary.DAO;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;

namespace NEGOSUDClient.Services;
public class HttpClientService
{
    private const string baseAddress = "https://localhost:7247/";
    private static HttpClient? client;
    private static CookieContainer cookieContainer = new();

    private static HttpClient Client
    {
        get
        {
            if (client == null)
            {
                var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
                client = new(handler) { BaseAddress = new Uri(baseAddress) };
            }
            return client;
        }
    }

    public static async Task<bool> Login(string username, string password)
    {
        string route = "login?useCookies=true&useSessionCookies=true";
        var jsonString = "{ \"email\": \"" + username + "\", \"password\": \"" + password + "\" }";

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(route, httpContent);

        var cookies = cookieContainer.GetCookies(new Uri(baseAddress));
        Debug.WriteLine(cookies);

        return response.IsSuccessStatusCode ? true :
            throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<FournisseurDTO>> GetFournisseurAll()
    {
        string route = $"api/Fournisseurs/";
        var response = await Client.GetAsync(route);
        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FournisseurDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        return new List<FournisseurDTO>();
    }

    //public static async Task<List<VolDto>> GetVolLights(DateTime dateJour)
    //{
    //    string route = $"api/vols/search/{dateJour.ToString("yyyy-MM-dd")}";
    //    var response = await Client.GetAsync(route);

    public static async Task<IEnumerable<ArticleDTO>> GetArticles()
    {
        string route = $"api/Articles";
        var response = await Client.GetAsync(route);


        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ArticleDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> DeleteArticle(int id)
    {
        string route = $"api/Articles/{id}";
        var response = await Client.DeleteAsync(route);

        return response.IsSuccessStatusCode;
    }

    public static async Task<IEnumerable<FournisseurDTO>> GetFournisseurs()
    {
        string route = $"api/Fournisseurs";
        var response = await Client.GetAsync(route);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<FournisseurDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<IEnumerable<FamilleArticle>> GetFamilles()
    {
        string route = $"api/FamilleArticles";
        var response = await Client.GetAsync(route);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<FamilleArticle>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<Article> GetArticlebyId(int id)
    {
        string route = $"api/Articles/{id}";
        var response = await Client.GetAsync(route);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Article>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> ModifyArticle(Article articleDAO, int id)
    {
        var articleJson = JsonConvert.SerializeObject(articleDAO);
        string route = $"api/Articles/{id}";

        var content = new StringContent(articleJson, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(route, content);

        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> CreateNewArticle(Article articleDAO)
    {
        var articleJson = JsonConvert.SerializeObject(articleDAO);
        string route = $"api/Articles/";

        var content = new StringContent(articleJson, Encoding.UTF8, "application/json");

        var response = await Client.PostAsync(route, content);

        return response.IsSuccessStatusCode;
    }
}