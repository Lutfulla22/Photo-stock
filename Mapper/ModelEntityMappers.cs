using Test.Entities;
using Test.Models;

namespace Test.Mapper
{
    public static class ModelEntityMappers
    {
        public static Author ToEntity(this NewAuthor author)
        {
            return new Author(
                firstName: author.FirstName,
                lastName: author.LastName,
                nickName: author.NickName,
                doB: author.Db
            );
        }
        
        public static Photos ToEntity(this NewPhotos photos, IEnumerable<Media> media, IEnumerable<Author> author)
        {
            return new Photos(
                name: photos.Name,
                cost: photos.Cost,
                author: author.ToList(),
                sales: photos.Sales,
                medias: media.ToList(),
                createdAt: DateTime.Today
            );
        }

         private static Media GetImageEntity(IFormFile file)
        {
            using var stream = new MemoryStream();

            file.CopyTo(stream);

            return new Media(
                data: stream.ToArray()
            );
        }
    }
}