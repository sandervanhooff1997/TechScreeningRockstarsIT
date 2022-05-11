using AutoMapper;

namespace Application.Common.Mappings
{
    /// <summary>
    /// Creates a default mapping profile for each implementing member.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}