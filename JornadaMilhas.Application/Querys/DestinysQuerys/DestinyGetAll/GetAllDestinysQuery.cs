using JornadaMilhas.Core.Entities.Destinys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll
{
    public record GetAllDestinysQuery : IRequest<List<Destiny>>{}
}
