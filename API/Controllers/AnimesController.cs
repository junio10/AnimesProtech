using Domain.Entities;
using Infraestructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimesController : ControllerBase
{
    private readonly ProtechAnimesContext _context;
    public AnimesController(ProtechAnimesContext context) {
        _context = context;
    }
    public IEnumerable<Anime> Index()
    {
       return _context.Animes.ToList();
    }
}
