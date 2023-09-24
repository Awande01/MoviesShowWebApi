using BL.DTO;
using BL.Interface;
using DAL.Data;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShowService: IShowService
    {
        private readonly IShowRepository _showRepository;
        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }
        public async Task<ShowDTO> GetShowByImdbId(string imdbId)
        {
            var show = await _showRepository.GetShowByImdbId(imdbId);

            if (show == null) return null;

            return new ShowDTO
            {
                ShowId = show.ShowId,
                Genre = show.Genre,
                Title = show.Title,
                ReleaseYear = show.ReleaseYear,
                ImdbId = show.ImdbId,
                Poster = show.Poster,
                IsWatched = show.IsWatched,
                Type = show.Type,
            };
        }
        public async Task<IEnumerable<ShowDTO>> GetShowByProfileId(int ProfileId)
        {
            var shows = await _showRepository.GetShowByProfileId(ProfileId);
            return shows.Select(x => new ShowDTO
            {
                ShowId = x.ShowId,
                Genre = x.Genre,
                Title = x.Title,
                ReleaseYear = x.ReleaseYear,
                ImdbId = x.ImdbId,
                Poster = x.Poster,
                IsWatched = x.IsWatched,
                Type = x.Type,
            });
        }
        public async Task SaveShow(ShowInformationDTO showInformationDTO)
        {
            await _showRepository.SaveShow(new Show
            {
                ProfileId = showInformationDTO.ProfileId,
                Genre = showInformationDTO.Genre,
                Title = showInformationDTO.Title,
                ReleaseYear = showInformationDTO.ReleaseYear,
                ImdbId = showInformationDTO.ImdbId,
                Poster = showInformationDTO.Poster,
                IsWatched = showInformationDTO.IsWatched,
                Type = showInformationDTO.Type,
            });
        }
        public async Task<bool> DeleteShow(int showId)
        {
            return await _showRepository.DeleteShow(showId);
        }
        public async Task<bool> UpdateShow(int showId, bool isWatched)
        {
            return await _showRepository.UpdateShow(showId, isWatched);
        }
    }
}
