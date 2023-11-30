using UserManagement.Core.Entities.PlaceHolderModels;

namespace UserManagement.Core.Interfaces.Service;

public interface IHttpClientService
{
    Task<List<Post>> GetPosts();
    //Task<dynamic> GetComments();
    //Task<dynamic> GetAlbums();
    //Task<dynamic> GetPhotos();
    //Task<dynamic> GetTodos();
    //Task<dynamic> GetUsers();
}
