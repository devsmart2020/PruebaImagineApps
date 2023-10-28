using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using PruebaTecnica.App.Core.Application.Services.Interfaces;
using PruebaTecnica.App.Core.Application.UiServiceInterfaces;
using PruebaTecnica.App.Core.DTOs.Common;
using PruebaTecnica.App.Core.DTOs.Transport;
using PruebaTecnica.App.Core.ViewModels.Base;
using PruebaTecnica.App.Core.ViewModels.UiInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.ViewModels.Movies
{
    public sealed class MoviesViewModel : BaseViewModel
    {
        #region Fields
        private IMovieService _moviesService = Ioc.Default.GetRequiredService<IMovieService>();
        private IMessageService _messageService = Ioc.Default.GetRequiredService<IMessageService>();
        private INavigationService _navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        private Guid _id;
        private string _title;
        private string _description;
        private string _genre;
        private decimal _score;
        private DateTime _launchDate;
        private MovieDto _selectedMovie;
        private ObservableCollection<MovieDto> _movieList;
        #endregion

        #region Ctor
        public MoviesViewModel()
        {
            GetAllMoviesCommand = new AsyncRelayCommand(async () => await GetMovies());
            ViewTrailerCommand = new AsyncRelayCommand(async () => await ViewTrailer());
        }
        #endregion

        #region Properties
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string Genre
        {
            get => _genre;
            set => SetProperty(ref _genre, value);
        }

        public decimal Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        public DateTime LaunchDate
        {
            get => _launchDate;
            set => SetProperty(ref _launchDate, value);
        }

        private string _trailerUrl;

        public string TrailerUrl
        {
            get => _trailerUrl;
            set => SetProperty(ref _trailerUrl, value);
        }


        public MovieDto SelectedMovie
        {
            get => _selectedMovie;
            set => SetProperty(ref _selectedMovie, value);
        }

        public ObservableCollection<MovieDto> MovieList
        {
            get => _movieList;
            set => SetProperty(ref _movieList, value);
        }

        private ObservableCollection<MovieDto> _originalMovieList;

        public ObservableCollection<MovieDto> OriginalMovieList
        {
            get => _movieList;
            set => SetProperty(ref _movieList, value);
        }


        private string _search;

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                if (value.Length == 0 && OriginalMovieList != null)
                    GetAllMoviesCommand.Execute(null);

                SearchMovies();
            }
        }


        #endregion

        #region Methods
        private async Task GetMovies()
        {
            IsBusy = true;
            try
            {
                IEnumerable<MovieDto> query = await _moviesService.GetAllMovies();
                if (!query.Any()) return;

                OriginalMovieList = new ObservableCollection<MovieDto>(query);
                MovieList = new ObservableCollection<MovieDto>(query);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
                await _messageService.ViewMessage("Error", Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ViewTrailer()
        {
            IsBusy = true;
            try
            {
                TrailerUrl = "https://www.youtube.com/watch?v=Tzxm7d4DN5I";

                ParameterFilterDto<string> filter = new ParameterFilterDto<string>
                {
                    ParamString = TrailerUrl,
                };

                await _navigationService.NavigatePushAsync<WebVisorViewModel>(filter);

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Message = ex.Message;
                await _messageService.ViewMessage("Error", Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void SearchMovies()
        {
            if (OriginalMovieList is null)
                return;

            MovieList = new ObservableCollection<MovieDto>(OriginalMovieList
                             .Where(x => x.Title.Contains(Search, StringComparison.OrdinalIgnoreCase))
                             .ToList());
        }
        #endregion

        #region Override
        public override Task OnInitializeAsync(object? parameters = null)
        {
            return base.OnInitializeAsync(parameters);
        }
        public override Task OnCloseAsync(object? parameters = null)
        {
            return base.OnCloseAsync(parameters);
        }
        #endregion


        #region Commands
        public IAsyncRelayCommand GetAllMoviesCommand { get; }
        public IAsyncRelayCommand ViewTrailerCommand { get; }
        #endregion

        #region Public Properties

        #endregion

    }
}
