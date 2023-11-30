using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json;
using UserManagement.Core.Entities;
using UserManagement.Core.Entities.PlaceHolderModels;
using UserManagement.Core.Interfaces.Service;

namespace UserManagement.Core.Services;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly PlaceHolderUrl _options;


    public HttpClientService(IOptions<PlaceHolderUrl> options)
    {
        _httpClient = new HttpClient();
        _options = options.Value;
    }

    //Not Good approach
    public async Task<List<Post>> GetPosts()
    {
        return await GetData(_options.Posts, typeof(Post)) as List<Post>;
    }

    //public Task<dynamic> GetComments()
    //{
      
    //}

    //public Task<dynamic> GetAlbums()
    //{
    //    return GetData(_options.Albums);
    //}

    //public Task<dynamic> GetPhotos()
    //{
    //    return GetData(_options.Photos);
    //}

    //public Task<dynamic> GetTodos()
    //{
    //    return GetData(_options.Todos);
    //}

    //public Task<dynamic> GetUsers()
    //{
    //    return GetData(_options.Users);
    //}

    private async Task<dynamic> GetData(string endPoint,Type classType)
    {
        try
        {
            string apiUrl = $"{_options.BaseUrl}/{endPoint}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var result= await response.Content.ReadAsStringAsync();

                var listType = typeof(List<>).MakeGenericType(classType);

                var content = JsonConvert.DeserializeObject(result,listType);

                return content;
            }

            return string.Empty;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
