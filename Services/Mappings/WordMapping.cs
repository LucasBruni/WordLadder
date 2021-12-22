using AutoMapper;
using Domain.Entities;
using Services.Models;

namespace Services.Mappings
{
    /// <summary>
    /// Word Mapper.
    /// </summary>
    public class WordMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordMapping"/> class.
        /// </summary>
        public WordMapping()
        {
            this.CreateMap<Word, WordModel>()
                .ReverseMap();
        }
    }
}
