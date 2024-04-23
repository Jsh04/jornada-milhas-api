using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Result;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;

public record GetByIdDestinyQuery(long id) : IRequest<Result<Destiny>>{};



