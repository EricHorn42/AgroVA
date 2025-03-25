using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services;

public class ReceiptService : ServiceBase<ReceiptDTO, Receipt, IReceiptRepository>, IReceiptService
{
    public ReceiptService(IReceiptRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}    
