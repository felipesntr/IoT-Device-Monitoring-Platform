using CIoTD.Domain.Abstractions;
using MediatR;

namespace CIoTD.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}