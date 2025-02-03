using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface IPassageService
{
    Task<Result> PayPassagesAsync(long customerId, List<PaidPassageInputModel> passageInputModels);
}