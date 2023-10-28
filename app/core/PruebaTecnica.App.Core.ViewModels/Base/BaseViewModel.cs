using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.ViewModels.Base
{
    public abstract class BaseViewModel : ObservableObject
    {
        #region Fields
        private bool _isBusy;
        private string _message;
        private bool _isEnabled;
        private bool _isVisible;
        private bool _confirmNavigate;
        private bool _isError;
        #endregion

        #region Ctor
        /// <summary>
        /// Constructor de la clase BaseViewModel.
        /// </summary>
        public BaseViewModel()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Indica si la operación actual está en progreso.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        /// Mensaje asociado a la operación actual.
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        /// <summary>
        /// Indica si el elemento asociado está habilitado o no.
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        /// <summary>
        /// Indica si el elemento asociado es visible o no.
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        /// <summary>
        /// Indica si se debe confirmar antes de navegar.
        /// </summary>
        public bool ConfirmNavigate
        {
            get => _confirmNavigate;
            set => SetProperty(ref _confirmNavigate, value);
        }

        /// <summary>
        /// Indica si se ha producido un error.
        /// </summary>
        public bool IsError
        {
            get => _isError;
            set => SetProperty(ref _isError, value);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Método invocado cuando se inicializa el ViewModel.
        /// </summary>
        /// <param name="parameters">Lista de parámetros opcionales que pueden ser proporcionados al inicializar el ViewModel.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public virtual Task OnInitializeAsync(object? parameters = null)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Método invocado cuando se cierra el ViewModel.
        /// </summary>
        /// <param name="parameters">Lista de parámetros opcionales que pueden ser proporcionados al cerrar el ViewModel.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public virtual Task OnCloseAsync(object? parameters = null)
        {
            return Task.CompletedTask;
        }
        #endregion
    }
}
