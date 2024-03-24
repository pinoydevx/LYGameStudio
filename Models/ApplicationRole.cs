using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
 
namespace LYStudio.Models
{
    [CollectionName("Roles")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {

    }
}