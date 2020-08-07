using AutoMapper;
using EmailSender.BLL.DTO;
using EmailSender.DAL.Entity;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Recipient, RecipientDTO>();
        CreateMap<Group, GroupDTO>();
    }
}