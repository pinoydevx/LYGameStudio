using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
 
namespace LYStudio.Models
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
    }
}