using BL.DTO;
using BL.Interface;
using DAL.Data;
using DAL.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShowService: IShowService
    {
        private readonly IIMDBApiService _iMDBApiService;
        private readonly IShowRepository _showRepository;
        public ShowService(IShowRepository showRepository, IIMDBApiService iMDBApiService)
        {
            _showRepository = showRepository;
            _iMDBApiService = iMDBApiService;
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
                Year = show.ReleasedYear,
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
                Year = show.ReleasedYear,
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
                Year = x.ReleasedYear,
                ImdbId = x.ImdbId,
                ImageUrl = x.ImageUrl,
                IsWatched = x.IsWatched,
                Type = x.TitleType,
                NextEpisodeId = x.NextEpisodeId,
                NumberOfEpisodes = x.NumberOfEpisodes,
                Episode = x.Episode,
                Season = x.Season,
                ParentImdbId = x.NextEpisodeId,
                ParentTitle = x.ParentTitle,
                ParentTitleType = x.ParentTitleType,
                ParentImageUrl = x.ParentImageUrl,
                ParentReleasedYear = x.ParentReleasedYear,
                EpisodeNumber = x.EpisodeNumber,
            });
        }
        public async Task<string> SaveShow(ShowInformationDTO showInformationDTO)
        {
            var message = string.Empty;
            var existingShow = await _showRepository.GetShowByImdbId(GetImbdId(showInformationDTO.id));
            if (existingShow != null)
            {
                message = await IsShowExisting(existingShow);
                return message;
            }

            await _showRepository.SaveShow(new Show
            {
                ProfileId = showInformationDTO.ProfileId,
                RunningTimeInMinutes = showInformationDTO.RunningTimeInMinutes,
                Title = showInformationDTO.Title,
                ReleasedYear = showInformationDTO.Year,
                ImdbId = GetImbdId(showInformationDTO.id),
                ImageUrl = showInformationDTO.image.url,
                TitleType = showInformationDTO.TitleType,
                NextEpisodeId = string.IsNullOrEmpty(showInformationDTO.NextEpisode)? string.Empty : GetImbdId(showInformationDTO.NextEpisode),
                NumberOfEpisodes = showInformationDTO.NumberOfEpisodes,
                Episode = showInformationDTO.Episode?? null,
                Season = showInformationDTO.Season,
                ParentImdbId = showInformationDTO.NextEpisode,
                ParentTitle = showInformationDTO.ParentTitle.title,
                ParentTitleType = showInformationDTO.ParentTitle.titleType,
                ParentImageUrl = showInformationDTO.ParentTitle.image.url,
                ParentReleasedYear = showInformationDTO.ParentTitle.year,
                EpisodeNumber = showInformationDTO.Episode,
            });
            message = $"{showInformationDTO.Title} saved successfully";
            return message;
        }
        public async Task<bool> DeleteShow(int showId)
        {
            return await _showRepository.DeleteShow(showId);
        }
        public async Task<bool> UpdateShow(int showId, bool isWatched)
        {
            return await _showRepository.UpdateShow(showId, isWatched);
        }

        private static string GetImbdId(string nextEpisode)
        {
            var nextEpisodeId = nextEpisode.Replace("/title/", string.Empty);
            var id = nextEpisodeId.Remove(nextEpisodeId.Length - 1);
            return id;   
        }
        private async  Task<string> IsShowExisting(Show showExist)
        {
            if (showExist.IsWatched == true)
            {
                if (showExist.NextEpisodeId != null)
                {
                    var imdbId = GetImbdId(showExist.NextEpisodeId);
                    var nextepisode = await _iMDBApiService.GetShowsAsync(imdbId);
                    return $"you already added and watched the {showExist.Title}. Please search  the next episode : {nextepisode.FirstOrDefault().title ?? ""}";
                }
                return $"you already added and watched the {showExist.Title}  - {showExist.TitleType}.";
            }

           return $"you already added the {showExist.Title}  - {showExist.TitleType} but not yet watched";

        }

    }
}
