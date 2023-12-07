using newWebAPI;
using AutoMapper;
using newWebAPI.Models;
using newWebAPI.Models.DTOs;

public class BookProfile : Profile
{
	public BookProfile()
	{
	    CreateMap<Book, BookUpdateDTO>().ReverseMap();
    }
}