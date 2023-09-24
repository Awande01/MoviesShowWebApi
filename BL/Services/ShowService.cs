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
                RunningTimeInMinutes = show.RunningTimeInMinutes,
                Title = show.Title,
                ReleasedYear = show.ReleasedYear,
                ImdbId = show.ImdbId,
                ImageUrl = show.ImageUrl,
                IsWatched = show.IsWatched,
                Type = show.TitleType,
                NextEpisodeId = show.NextEpisodeId,
                NumberOfEpisodes = show.NumberOfEpisodes,
            };
        }
        public async Task<ShowDTO> GetShowById(int id)
        {
            var show = await _showRepository.GetShowById(id);

            if (show == null) return null;

            return new ShowDTO
            {
                ShowId = show.ShowId,
                RunningTimeInMinutes = show.RunningTimeInMinutes,
                Title = show.Title,
                ReleasedYear = show.ReleasedYear,
                ImdbId = show.ImdbId,
                ImageUrl = show.ImageUrl,
                IsWatched = show.IsWatched,
                Type = show.TitleType,
                NextEpisodeId = show.NextEpisodeId,
                NumberOfEpisodes = show.NumberOfEpisodes,
            };
        }
        public async Task<IEnumerable<ShowDTO>> GetShowByProfileId(int ProfileId)
        {
            var shows = await _showRepository.GetShowByProfileId(ProfileId);
            return shows.Select(x => new ShowDTO
            {
                ShowId = x.ShowId,
                RunningTimeInMinutes = x.RunningTimeInMinutes,
                Title = x.Title,
                ReleasedYear = x.ReleasedYear,
                ImdbId = x.ImdbId,
                ImageUrl = x.ImageUrl,
                IsWatched = x.IsWatched,
                Type = x.TitleType,
                NextEpisodeId = x.NextEpisodeId,
                NumberOfEpisodes = x.NumberOfEpisodes,
            });
        }
        public async Task SaveShow(ShowInformationDTO showInformationDTO)
        {
            await _showRepository.SaveShow(new Show
            {
                ProfileId = showInformationDTO.ProfileId,
                RunningTimeInMinutes = showInformationDTO.RunningTimeInMinutes,
                Title = showInformationDTO.Title,
                ReleasedYear = showInformationDTO.ReleasedYear,
                ImdbId = showInformationDTO.ImdbId,
                ImageUrl = showInformationDTO.ImageUrl,
                TitleType = showInformationDTO.Type,
                NextEpisodeId = showInformationDTO.NextEpisodeId,
                NumberOfEpisodes = showInformationDTO.NumberOfEpisodes,
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
