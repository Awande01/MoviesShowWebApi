using BL.DTO;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IShowService
    {
        Task<ShowDTO> GetShowByImdbId(string imdbId);
        Task<IEnumerable<ShowDTO>> GetShowByProfileId(int ProfileId);
        Task<ShowDTO> GetShowById(int id);
        Task<string> SaveShow(ShowInformationDTO showInformationDTO);
        Task<bool> DeleteShow(int showId);
        Task<bool> UpdateShow(int showId, bool isWatched);
    }
}
