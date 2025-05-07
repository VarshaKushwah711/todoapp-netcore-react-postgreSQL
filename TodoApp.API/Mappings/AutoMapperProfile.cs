using AutoMapper;
using TodoApp.API.DTOs.Request;
using TodoApp.API.DTOs.Response;
using TodoApp.API.Models;

namespace TodoApp.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoItem, TodoItemResponseDto>();
            CreateMap<TodoItemRequestDto, TodoItem>();
        }
    }
}
