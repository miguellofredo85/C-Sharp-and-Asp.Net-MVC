using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IRepoProjetos
    {
        List<Project> GetProjects();
    }
    public class RepoProjetos: IRepoProjetos
    {
        public List<Project> GetProjects()
        {
            return new List<Project>()
            {
                new Project
                {
                    Title="Amazon",
                    Description="Buy anything",
                    ImageURL= "/images/NicePng_messi-png_273780.png",
                    Link= "https://www.amazon.com"
                },
                new Project
                {
                     Title="Mercadolivre",
                    Description="Buy a lot of diferents stuffs",
                    ImageURL= "/images/NicePng_messi-png_273780.png",
                    Link= "https://www.mercadolivre.com.br"
                },
                new Project
                {
                     Title="Google",
                    Description="Internet Seach Engine",
                    ImageURL= "/images/NicePng_messi-png_273780.png",
                    Link= "https://www.google.com"
                },
                new Project
                {
                     Title="PAgina12",
                    Description="Argentine Newspaper",
                    ImageURL= "/images/NicePng_messi-png_273780.png",
                    Link= "https://www.pagina12.com"
                },
                new Project
                {
                     Title="Steam",
                    Description="Videogames Store",
                    ImageURL= "/images/NicePng_messi-png_273780.png",
                    Link= "https://www.steam.com"
                }
            };
        }
    }
}
