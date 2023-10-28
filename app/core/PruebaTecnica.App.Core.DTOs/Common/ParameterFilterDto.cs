namespace PruebaTecnica.App.Core.DTOs.Common
{
    public sealed class ParameterFilterDto<T>
    {
        public string ParamString { get; set; } = null!;
        public T Param { get; set; } = default!;
    }
}
